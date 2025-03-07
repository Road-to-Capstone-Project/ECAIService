using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Metrics;
using Tensorflow.Operations.Activation;

using Adam = Tensorflow.Keras.Optimizers.Adam;
using CategoricalCrossentropy = Tensorflow.Keras.Losses.CategoricalCrossentropy;
using Embedding = Tensorflow.Keras.Layers.Embedding;
using Sequential = Tensorflow.Keras.Engine.Sequential;
using SparseCategoricalCrossentropy = Tensorflow.Keras.Losses.SparseCategoricalCrossentropy;
using System.Collections.Frozen;
using LSTM = Tensorflow.Keras.Layers.LSTM;
using Castle.DynamicProxy;
using ECAIService.Interceptors;
using System.Buffers;
using System.Reflection;
using static TorchSharp.torch.optim.lr_scheduler.impl;
using Tensorflow.Keras.Callbacks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Dropout = Tensorflow.Keras.Layers.Dropout;
using System.CodeDom;
using static Tensorflow.Keras.Engine.Model;
//using NumSharp;

namespace ECAIService.Services;

public class RNNFactory
{
    private RNNFactory Proxy => this;

    public record Arguments(
        Random Random,
        MemoryManager MemoryManager,
        ProxyGenerator ProxyGenerator,
        ILogger<RNNFactory>? Logger = null,
        ILogger<TrainingInterceptor>? TrainingInterceptorLogger = null);

    const TF_DataType outDType = TF_DataType.TF_FLOAT;
    private readonly Arguments args;

    public RNNFactory(Arguments args)
    {
        this.args = args;
    }

    public ICallback GetTrainingHook(IModel model)
    {
        return args.ProxyGenerator.CreateInterfaceProxyWithoutTarget<ICallback>
            ([
                new TrainingInterceptor(model,                
                args.MemoryManager, 
                "val_loss",
                args.TrainingInterceptorLogger),
                new DefaultValueInterceptor(true)
            ]);
    }

    public readonly record struct Encoders(Func<string, int> TokenToIndex,
                       Func<int, string> IndexToToken,
                       int UniqueItemsCount,
                       int SequenceLength = 3);

    public IModel CreateModel(IEnumerable<IReadOnlyList<string>> inputData,
                                          Encoders arguments,
                                          decimal trainSplit)
    {

        (Func<string, int> tokenToIndex,
        Func<int, string> indexToToken,
        int length,
        int sequenceLength) = arguments;

        var dataTable = inputData.Select(i =>
                Enumerable.Range(0, (i.Count - sequenceLength).Operate(Math.Max, 0))
                .Select(j =>
                    (
                        i.Take(j..(j + sequenceLength)).Select(token => tokenToIndex(token)).ToArray(),
                        tokenToIndex(i[j + sequenceLength])
                    )
                )
            )
            .SelectMany()
            .ToArray();

        args.Random.Shuffle(dataTable);

        var train = dataTable.Take((int)(dataTable.Length * trainSplit)).ToArray();
        var test = dataTable.Skip((int)(dataTable.Length * trainSplit)).ToArray();

        var oneHotTrain = train.Let(it =>
            (
                X: it.Select(i => i.Item1).ToArray().Let(it => OneHotEncode2D(it, length, outDType)),
                y: it.Select(i => i.Item2).ToArray().Let(it => OneHotEncode1D(it, length, outDType))
            )
        );

        var oneHotTest = test.Let(it =>
            (
                X: it.Select(i => i.Item1.ToArray()).ToArray().Let(it => OneHotEncode2D(it, length, outDType)),
                y: it.Select(i => i.Item2).ToArray().Let(it => OneHotEncode1D(it, length, outDType))
            )
        );

        var model = new Sequential(new SequentialArgs()
        {
            Layers = [
                new SimpleRNN(new SimpleRNNArgs
                {
                    Units = 50,
                    InputShape = new Shape(sequenceLength, length),
                    Activation = (Activation)new relu().Activate
                }),
                new Dense(new DenseArgs
                {
                    Units = length,
                    Activation = (Activation)new softmax().Activate
                })
            ]
        });

        model.compile(optimizer: new Adam(), loss: new CategoricalCrossentropy(), metrics: ["accuracy"]);
        model.fit(oneHotTrain.X, oneHotTrain.y, epochs: 100, shuffle: false);

        var eval = model.evaluate(oneHotTest.X, oneHotTest.y);
        args.Logger?.LogInformation("Test loss: {loss}, Test accuracy: {accuracy}", eval["loss"], eval["accuracy"]);

        var predictions = model.predict(oneHotTest.X);
        args.Logger?.LogInformation("Predictions: {predictions}", predictions.numpy());

        return model;
    }


    public int[][] ToDataTable(IEnumerable<IReadOnlyList<string>> inputData, Encoders encoders)
    {
        return inputData.Select(i =>
            i.Select(encoders.TokenToIndex)
            .ToArray()
        ).ToArray();
    }

    public IReadOnlyDictionary<int, int> GetItemFreq(IEnumerable<IEnumerable<int>> dataTable)
    {
        return dataTable.SelectMany().CountBy(i => i).ToFrozenDictionary();
    }

    public (InputsLabelPair trainArray, InputsLabelPair testArray, IReadOnlyDictionary<int, int> itemFreq) PrepareData(IEnumerable<IReadOnlyList<string>> inputData,
                                          Encoders arguments,
                                          decimal trainSplit = 0.2m)
    {
        (Func<string, int> tokenToIndex,
        Func<int, string> indexToToken,
        int length,
        int sequenceLength) = arguments;

        var dataTable = inputData.Select(i =>
        i.Select(tokenToIndex)
        .ToArray()
    ).ToArray();

        var itemFreq = dataTable.SelectMany().CountBy(i => i).ToFrozenDictionary();

        args.Random.Shuffle(dataTable);

        var (train, test) = Split(dataTable, itemFreq, testSize: trainSplit);

        var trainArrays = PreprocessData(train);
        var testArrays = PreprocessData(test);

        return (trainArrays, testArrays, itemFreq);
    }

    public (InputsLabelPair trainArray, InputsLabelPair testArray, IReadOnlyDictionary<int, int> itemFreq) PrepareData2(IEnumerable<IReadOnlyList<string>> inputData,
                                          Encoders arguments,
                                          decimal trainSplit)
    {
        (Func<string, int> tokenToIndex,
        Func<int, string> indexToToken,
        int length,
        int sequenceLength) = arguments;

        var dataTable = inputData.Select(i =>
        i.Select(tokenToIndex)
        .ToArray()
    ).ToArray();

        var itemFreq = dataTable.SelectMany().CountBy(i => i).ToFrozenDictionary();

        args.Random.Shuffle(dataTable);

        var (train, test) = Split(dataTable, itemFreq, testSize: trainSplit);

        var trainArrays = PreprocessData2(train, itemFreq);
        var testArrays = PreprocessData2(test, itemFreq);

        return (trainArrays, testArrays, itemFreq);
    }

    public IModel CompileTransformerModel(IReadOnlyDictionary<int, int> itemFreq, int? embedDim = null, int maxSeqLength = 20)
    {
        return BuildTransformerModel(vocabSize: itemFreq.Count, embedDim: 
            //64
            embedDim ?? itemFreq.Count
            ,
            /* numHeads: 4, ffDim: 128,*/ maxSeqLength: maxSeqLength)
            .Apply(it =>
            //it.compile(optimizer: new Adam(),
            //          loss: new SparseCategoricalCrossentropy(from_logits: true),
            //          metrics: [new SparseCategoricalAccuracy()])
            it.compile(optimizer: new Adam(0.001f), 
            loss:
            //new CategoricalCrossentropy()
            new SparseCategoricalCrossentropy(from_logits: true)
            //tf.nn.softmax_cross_entropy_with_logits_v2()
            , 
            metrics: [
                new SparseCategoricalAccuracy(),
                new SparseTopKCategoricalAccuracy(k: 5),
                //new Accuracy(),
                //new Precision(),
                //new Recall()
                ])
            );
    }

    public IModel BuildTransformerModel2(IReadOnlyDictionary<int, int> itemFreq, int? embedDim = null)
    {
        return BuildTransformerModel2(vocabSize: itemFreq.Count, embedDim: embedDim ?? itemFreq.Count, /* numHeads: 4, ffDim: 128,*/ maxSeqLength: 20)
            .Apply(it =>
                it.compile(optimizer: new Adam(),
                          loss:
                          new CategoricalCrossentropy(),
                          //new SparseCategoricalCrossentropy(from_logits: false),
                          metrics: [
                              new SparseCategoricalAccuracy(),
                              new Accuracy()
                              ])
            //it.compile(optimizer: new Adam(), loss: new CategoricalCrossentropy(), metrics: ["accuracy"])
            );
    }


    public void ValidateData(IModel model, IReadOnlyDictionary<int, int> itemFreq)
    {
        // Ensure labels are valid integers (0 <= label < num_classes)
        var inputArray = new[] { itemFreq.Count };

        var input = np.zeros(new Shape(1, 20), TF_DataType.TF_INT32).Apply(i =>
        i[0] = np.array(inputArray.Concat(Enumerable.Repeat(0, 20 - inputArray.Length)).ToArray()));

        // Clip logits to avoid extreme values
        var logits = model.predict(input).Single();
        ;

        var labels = np.array(new[] { itemFreq.Count - 1 });

        // Use SparseCategoricalCrossentropy with from_logits=True
        var loss = new SparseCategoricalCrossentropy(from_logits: true);
        var lossValue = loss.Call(labels, logits).numpy();

        Console.WriteLine("Loss: " + lossValue);
    }


    public IModel TrainModel(IModel model, (NDArray, NDArray) trainArrays, (NDArray, NDArray) testArrays)
    {



        args.MemoryManager.MayCollectMemory(() => GC.Collect(2, GCCollectionMode.Optimized));


        var callbackParams = new CallbackParams()
        {
            Model = model,
            // Unused in decompiled code of EarlyStopping:
            //Verbose = 1,
            //Epochs = 200,
            //Steps = 100,
        };

        return model.Apply(it => it.fit(trainArrays.Item1,
                                        trainArrays.Item2,
                                        batch_size: 
                                        (int)Math.Pow(2, 4)
                                        //32
                                        //16
                                        ,
                                        epochs: 999,
                                        validation_data: (testArrays.Item1, testArrays.Item2),
                                        callbacks: [
                                            GetTrainingHook(model),
                                            new EarlyStopping(
                                                  callbackParams,
                                                  monitor: "val_loss",
                                                  patience: 5,
                                                  mode: "auto",
                                                  restore_best_weights : true
                                                ),
                                            new History(callbackParams),
                                            //new ProgbarLogger(callbackParams),

                                            //new EarlyStopping(
                                            //      callbackParams,
                                            //      monitor: "loss",
                                            //      patience: 2,
                                            //      mode: "auto",
                                            //      restore_best_weights : true
                                            //    ),
                                        ]

                                        )
        )
            .Apply(_ => args.MemoryManager.MayCollectMemory(() => GC.Collect(2, GCCollectionMode.Optimized)));
    }

    public IModel CreateModel2(IEnumerable<IReadOnlyList<string>> inputData,
                                          Encoders arguments,
                                          decimal trainSplit)
    {
        (Func<string, int> tokenToIndex,
        Func<int, string> indexToToken,
        int length,
        int sequenceLength) = arguments;

        var dataTable = inputData.Select(i =>
        i.Select(tokenToIndex)
        .ToArray()
    ).ToArray();

        var itemFreq = dataTable.SelectMany().CountBy(i => i).ToFrozenDictionary();

        args.Random.Shuffle(dataTable);

        var (train, test) = Split(dataTable, itemFreq, testSize: trainSplit);

        var trainArrays = PreprocessData(train);
        var testArrays = PreprocessData(test);

        var model = BuildTransformerModel(vocabSize: itemFreq.Count, embedDim: 64, /* numHeads: 4, ffDim: 128,*/ maxSeqLength: 20);

        //model.compile(optimizer: new Adam(), loss: new CategoricalCrossentropy(), metrics: ["accuracy"]);
        //model.fit(trainArrays.sequences, trainArrays.labels, epochs: 100, shuffle: false);

        // Step 4: Compile the TFModel
        model.compile(optimizer: new Adam(),
                      loss: new SparseCategoricalCrossentropy(from_logits: true),
                      metrics: [new SparseCategoricalAccuracy()]);

        args.MemoryManager.MayCollectMemory(() => GC.Collect(2, GCCollectionMode.Optimized));

        // Step 5: Train the TFModel
        model.fit(trainArrays.sequences, trainArrays.labels, batch_size: 32, epochs: 10, validation_data: (testArrays.sequences, testArrays.labels));

        args.MemoryManager.MayCollectMemory(() => GC.Collect(2, GCCollectionMode.Optimized));

        // Step 6: Evaluate the TFModel
        //EvaluateModel(model, testArrays.sequences, testArrays.labels, itemFreq, topK: 5);

        return model;
    }

    private NDArray OneHotEncode1D<T>(T[] values, int length, TF_DataType? dataType = null) where T : unmanaged
    {
        var dtype = dataType ?? np.array<T>().dtype;

        return values.Let(it => np.array<T>(it))
                            .Apply(_ => args.MemoryManager.MayCollectMemory(() =>
                            {
                                values = null!;
                                GC.Collect();
                            }))
               .Let(it => tf.one_hot(it, length, dtype: dtype))
               .Apply(_ => args.MemoryManager.MayCollectMemory(() => GC.Collect()))
               .Let(it => it.numpy())
               .Apply(_ => args.MemoryManager.MayCollectMemory(() => GC.Collect()));
    }

    private NDArray OneHotEncode2D<T>(ICollection<T[]> values, int length, TF_DataType? dataType = null) where T : unmanaged
    {
        var inDType = np.array<T>().dtype;
        var outDType = dataType ?? inDType;

        return values.Let(it => np.zeros(new Shape(values.Count, values.First().Length)).astype(inDType)
            .Apply(nd =>
            {
                foreach (var (row, index) in it.Zip(Enumerable.Range(0, values.Count)))
                {
                    nd[index] = np.array<T>(row);
                }
            })
        )
            .Apply(_ => args.MemoryManager.MayCollectMemory(() =>
            {
                values = null!;
                GC.Collect();
            }))
            .Let(it =>
            tf.one_hot(it, length, dtype: outDType))
            .Apply(_ => args.MemoryManager.MayCollectMemory(() => GC.Collect()))
            .Let(it =>
            it.numpy())
            .Apply(_ => args.MemoryManager.MayCollectMemory(() => GC.Collect()));
    }

    public string Predict(IModel model,
                          ICollection<string> inputSequence,
                          Encoders arguments)
    {
        (Func<string, int> tokenToIndex,
        Func<int, string> indexToToken,
        int length,
        int sequenceLength) = arguments;

        if (inputSequence.Count < sequenceLength)
        {
            throw new ArgumentException($"Input sequence of size {inputSequence.Count} is shorter than {nameof(sequenceLength)}: {sequenceLength}.");
        }

        return inputSequence.TakeLast(sequenceLength)
                            .Select(tokenToIndex)
                            //.Select(i => (ushort)i)
                            .ToArray()
                            .Let(i => new int[][] { i })
                            .Let(it => OneHotEncode2D(it, length, outDType))
                            .Let(it => model.predict(it))
                            .Let(it => (int)np.argmax(it.numpy()))
                            .Let(indexToToken);
    }

    public Sequential BuildTransformerModel(int vocabSize, int embedDim, int maxSeqLength)
    {
        return new SequentialArgs
        {
            Name = "transformer",
            Layers =
        [
            // Input Layer
            new InputLayer (new InputLayerArgs { InputShape = new Shape(maxSeqLength) }),

            // Embedding Layer
            new Embedding(new EmbeddingArgs
            {
                MaskZero = true,
                InputDim = vocabSize + 1,
                OutputDim = embedDim,
                InputLength = maxSeqLength
            }),

            // Transformer Encoder Layer (custom)
            new LSTM(new LSTMArgs {
                Units =
                embedDim * 2
                //128
                ,
                //Activation = tf.keras.activations.Relu
                Activation = new Tensorflow.Keras.Activations().Relu,
                RecurrentActivation = new Tensorflow.Keras.Activations().Sigmoid,
                ActivityRegularizer = new Tensorflow.Keras.Regularizers().l2(0.01f),
                //Dropout = 0.2f,
                //RecurrentDropout = 0.2f
            }),

            //new SimpleRNN(new SimpleRNNArgs
            //{
            //    Units = 128,
            //    InputDim = embedDim,
            //    Activation = tf.keras.activations.Relu
            //}),

            // Global Average Pooling
            //new GlobalAveragePooling1D(new GlobalAveragePooling1DArgs()),

            new Dropout(new DropoutArgs { Rate = 0.2f }),

            // Output Layer
            new Dense(new DenseArgs
            {
                Units = 64,
                Activation = tf.keras.activations.Relu,
                KernelRegularizer = new L2(0.01f)
            }),

            new Dropout(new DropoutArgs { Rate = 0.5f }),

            new Dense(new DenseArgs {
                Units = vocabSize,
                Activation = tf.keras.activations.Sigmoid
            })
        ]

        }.Let(it =>
        new Sequential(it))
        ;

    }

    public Sequential BuildTransformerModel2(int vocabSize, int embedDim, int maxSeqLength)
    {
        return new SequentialArgs
        {
            Name = "transformer",
            Layers =
        [

                // Transformer Encoder Layer (custom)
                new SimpleRNN(new SimpleRNNArgs {
                    Units = 128,
                    InputShape = (maxSeqLength, vocabSize),
                    Activation = tf.keras.activations.Relu
                }),

                // Global Average Pooling
                //new GlobalAveragePooling1D(new GlobalAveragePooling1DArgs()),

                // Output Layer
                new Dense(new DenseArgs
                {
                    Units = vocabSize,
                    Activation = tf.keras.activations.Softmax
                })

                //new SimpleRNN(new SimpleRNNArgs
                //{
                //    Units = 50,
                //    InputShape = new Shape(maxSeqLength, vocabSize),
                //    Activation = (Activation)new relu().Activate
                //}),
                //new Dense(new DenseArgs
                //{
                //    Units = vocabSize,
                //    Activation = (Activation)new softmax().Activate
                //})


        ]
        }.Let(it =>
        new Sequential(it))
        ;
    }

    public void Run()
    {
        // Step 1: Generate Synthetic Data
        var (trainData, testData, itemFreq) = GenerateSyntheticData(numSequences: 10000, maxSeqLength: 10, numItems: 100);

        // Step 2: Preprocess Data
        var (trainSequences, trainLabels) = PreprocessData(trainData);
        var (testSequences, testLabels) = PreprocessData(testData);

        // Step 3: Build the Transformer TFModel
        var model = BuildTransformerModel(vocabSize: itemFreq.Count, embedDim: 64, /* numHeads: 4, ffDim: 128,*/ maxSeqLength: 20);

        // Step 4: Compile the TFModel
        model.compile(optimizer: new Adam(),
                      loss: new SparseCategoricalCrossentropy(from_logits: true),
                      metrics: [new SparseCategoricalAccuracy()]);

        // Step 5: Train the TFModel
        model.fit(trainSequences, trainLabels, batch_size: 32, epochs: 10, validation_data: (testSequences, testLabels));

        // Step 6: Evaluate the TFModel
        EvaluateModel(model, testSequences, testLabels, itemFreq, topK: 5);
    }

    // Step 1: Generate Synthetic Data
    public (List<int[]> trainData, List<int[]> testData, Dictionary<int, int> itemFreq) GenerateSyntheticData(int numSequences, int maxSeqLength, int numItems)
    {
        var rnd = args.Random;
        var sequences = new List<int[]>();
        var itemFreq = new Dictionary<int, int>();

        for (int i = 0; i < numSequences; i++)
        {
            var seqLength = rnd.Next(2, maxSeqLength + 1);
            var sequence = new int[seqLength];
            for (int j = 0; j < seqLength; j++)
            {
                var item = rnd.Next(0, numItems);
                sequence[j] = item;
                if (itemFreq.TryGetValue(item, out int value))
                    itemFreq[item] = ++value;
                else
                    itemFreq[item] = 1;
            }
            sequences.Add(sequence);
        }

        // Split into train/test sets
        var splitIdx = (int)(numSequences * 0.8);
        var trainData = sequences.Take(splitIdx).ToList();
        var testData = sequences.Skip(splitIdx).ToList();

        return (trainData, testData, itemFreq);
    }

    // Step 2: Preprocess Data
    public InputsLabelPair PreprocessData(IEnumerable<IReadOnlyList<int>> data)
    {
        var sequences = new List<int[]>();
        var labels = new List<int>();

        foreach (var seq in data)
        {
            for (int i = 1; i < seq.Count; i++)
            {
                // Increment each item in the sequence by 1 to avoid 0s
                sequences.Add(seq.Select(i => i + 1).Take(i).ToArray());
                labels.Add(seq[i]);
            }
        }

        // Pad sequences to the same length
        int maxSeqLength = sequences.Max(x => x.Length);
        var paddedSequences = sequences.Select(seq => seq.Concat(Enumerable.Repeat(0, maxSeqLength - seq.Length)).ToArray()).ToArray();

        var paddedSequencesArray = np.zeros(new Shape(paddedSequences.Length, maxSeqLength), np.array<int>().dtype);
        for (int i = 0; i < paddedSequences.Length; i++)
        {
            for (int j = 0; j < maxSeqLength; j++)
            {
                paddedSequencesArray[i, j] = paddedSequences[i][j];
            }
        }

        return (paddedSequencesArray, np.array(labels.ToArray()));
    }

    public InputsLabelPair PreprocessData2(IEnumerable<IReadOnlyList<int>> data, IReadOnlyDictionary<int, int> itemFreq)
    {
        var sequences = new List<int[]>();
        var labels = new List<int>();

        foreach (var seq in data)
        {
            for (int i = 1; i < seq.Count; i++)
            {
                sequences.Add(seq.Select(i => i + 1).Take(i).ToArray());
                labels.Add(seq[i]);
            }
        }

        // Pad sequences to the same length
        int maxSeqLength = sequences.Max(x => x.Length);
        var paddedSequences = sequences.Select(seq => seq.Concat(Enumerable.Repeat(0, maxSeqLength - seq.Length)).ToArray()).ToArray();

        var paddedSequencesArray = Enumerable.Range(0, paddedSequences.Length)
            .Select(_ => Enumerable.Range(0, maxSeqLength).ToArray()).ToArray();
        for (int i = 0; i < paddedSequences.Length; i++)
        {
            for (int j = 0; j < maxSeqLength; j++)
            {
                paddedSequencesArray[i][j] = paddedSequences[i][j];
            }
        }

        return (OneHotEncode2D(paddedSequencesArray, itemFreq.Count, outDType),
            OneHotEncode1D(labels.ToArray(), itemFreq.Count, outDType));
    }


    // Helper method to bin sequence lengths
    public string GetStratificationKey(IReadOnlyList<int> sequence, IReadOnlyDictionary<int, int> itemFreq)
    {
        // Bin sequence length
        int length = sequence.Count;
        string lengthBin = length switch
        {
            <= 3 => "short",
            <= 6 => "medium",
            _ => "long"
        };

        // Bin next item frequency (last item in the sequence)
        int lastItem = sequence[sequence.Count - 1];
        int freq = itemFreq[lastItem];
        string freqBin = freq switch
        {
            <= 5 => "rare",
            _ => "common"
        };

        return $"{lengthBin}_{freqBin}";
    }

    public (IEnumerable<IReadOnlyList<int>> Train, IEnumerable<IReadOnlyList<int>> Test) Split(IEnumerable<IReadOnlyList<int>> sequences, IReadOnlyDictionary<int, int> itemFreq, decimal testSize = 0.2m)
    {
        // Group sequences by stratification key
        var groups = sequences
            .Select((seq, index) => new { Key = GetStratificationKey(seq, itemFreq), Sequence = seq })
            .GroupBy(x => x.Key)
            .ToList();

        var train = Enumerable.Empty<IReadOnlyList<int>>();
        var test = Enumerable.Empty<IReadOnlyList<int>>();

        foreach (var group in groups)
        {
            var groupSequences = group.Select(x => x.Sequence).ToList();
            int splitIdx = (int)(groupSequences.Count * (1 - testSize));

            // Shuffle to randomize within the group
            var shuffled = groupSequences.OrderBy(x => args.Random.NewGuid()).ToList();

            train = train.Concat(shuffled.Take(splitIdx));
            test = test.Concat(shuffled.Skip(splitIdx));
        }

        // Shuffle the final sets to avoid order bias
        train = train.OrderBy(x => args.Random.NewGuid());
        test = test.OrderBy(x => args.Random.NewGuid());

        return (train, test);
    }

    public IEnumerable<IEnumerable<string>> Predict2(IModel model, IEnumerable<string> inputSequence, Encoders encoders)
    {
        var inputArray = inputSequence
            .Select(encoders.TokenToIndex)
            .Select(i => i + 1)
            .ToArray();

        var predictions =
            np.zeros(new Shape(1, 20), TF_DataType.TF_INT32).Apply(i =>
        i[0] = np.array(inputArray.Concat(Enumerable.Repeat(0, 20 - inputArray.Length)).ToArray()))
            .Let(it =>
                model.predict(
                    it
                )
            )
            .Single()
            [0]
            .numpy()
            ;

        var predictionEnumerable = predictions.Select(i => (float)i);

        

        var predictedIndices = np.argsort(predictions).Select(i => (int)i);

        // Unpadded input
        //var predictions2 = model.predict(np.zeros(new Shape(1, inputArray.Length), TF_DataType.TF_INT32).Apply(i =>
        //i[0] = np.array(inputArray)))
        //    .Single()
        //    [0]
        //    .numpy()
        //    ;

        //var predictedIndices2 = np.argsort(predictions2).Select(i => (float)i);

        return [
            predictedIndices.Select(encoders.IndexToToken)
            ];
    }

    public void EvaluateModel(IModel model, NDArray testSequences, NDArray testLabels, IReadOnlyDictionary<int, int> itemFreq, int topK)
    {
        // Predict probabilities for the test set
        var predictions = model.predict(testSequences).Single();

        // Compute Top-K Accuracy
        int correct = 0;
        for (int i = 0; i < (int)testLabels.size; i++)
        {
            args.MemoryManager.MayCollectMemory(() => GC.Collect(1, GCCollectionMode.Optimized));

            var trueLabel = (int)testLabels[i];
            using var preds = predictions[i];
            var topKIndices = preds.numpy().Let(i => np.argsort(i)).Select(i => (int)i).TakeLast(topK).ToArray();
            if (topKIndices.Contains(trueLabel))
                correct++;
        }
        Console.WriteLine($"Top-{topK} Accuracy: {(float)correct / testLabels.size}");

        args.MemoryManager.MayCollectMemory(() => GC.Collect(1, GCCollectionMode.Optimized));

        // Compute Coverage@K
        var recommendedItems = new HashSet<int>();
        for (int i = 0; i < predictions.shape[0]; i++)
        {
            args.MemoryManager.MayCollectMemory(() => GC.Collect(1, GCCollectionMode.Optimized));

            var preds = predictions[i];
            var topKIndices = preds.numpy().Let(i => np.argsort(i)).Select(i => (int)i).TakeLast(topK).ToArray();
            foreach (var item in topKIndices)
                recommendedItems.Add(item);
        }
        Console.WriteLine($"Coverage@{topK}: {(float)recommendedItems.Count / itemFreq.Count}");

        args.MemoryManager.MayCollectMemory(() => GC.Collect(1, GCCollectionMode.Optimized));
    }
}

public record struct InputsLabelPair(NDArray sequences, NDArray labels)
{
    public static implicit operator (NDArray sequences, NDArray labels)(InputsLabelPair value)
    {
        return (value.sequences, value.labels);
    }

    public static implicit operator InputsLabelPair((NDArray sequences, NDArray labels) value)
    {
        return new InputsLabelPair(value.sequences, value.labels);
    }
}

public sealed class TrainingInterceptor(
    IModel model,
    MemoryManager memoryManager,
    string metric = "val_loss",
    ILogger<TrainingInterceptor>? logger = null) : IInterceptor
{
    private static readonly PropertyInfo historyInfo = typeof(ICallback).GetProperty("history")!;

    Dictionary<string, List<float>> history { get; set; } = [];

    IReadOnlyCollection<NDArray> Weights { get; set; } = [];

    float? MetricValue { get; set; }

    int BestEpoch { get; set; }

    public void Intercept(IInvocation invocation)
    {
        try {
            var concreteMethod = invocation.GetConcreteMethod();

            //logger?.LogInformation("Intercepted method: {method}", concreteMethod.Name);

            if (historyInfo.GetMethod == concreteMethod)
            {
                invocation.ReturnValue = history;
            }
            else
            if (historyInfo.SetMethod == concreteMethod)
            {
                history = (Dictionary<string, List<float>>)invocation.Arguments[0];
            }
            else
            if (concreteMethod.Name == nameof(ICallback.on_train_batch_begin))
            {
                memoryManager.MayCollectMemory(() => GC.Collect(2, GCCollectionMode.Optimized));
            }
            else
            if (concreteMethod.Name == nameof(ICallback.on_epoch_begin))
            {
                //logger?.LogInformation("Starting epoch {epoch}", invocation.Arguments[0]);
            }
            else
            if (concreteMethod.Name == nameof(ICallback.on_epoch_end))
            {
                logger?.LogInformation("Finished epoch {epoch}\n{history}",
                    invocation.Arguments[0],
                    JsonConvert.SerializeObject(invocation.Arguments[1]));

                if (File.Exists("Resources/stop.sig"))
                {
                    model.Stop_training = true;

                    if (MetricValue != null)
                    {
                        model.set_weights(Weights);
                    }
                }

                var log = (IReadOnlyDictionary<string, float>)invocation.Arguments[1];

                if (MetricValue == null)
                {
                    MetricValue = log[metric];
                    Weights = model.get_weights();
                }
                else
                {
                    if (log[metric] >= MetricValue)
                    {
                        //model.set_weights(Weights);
                    }
                    else
                    if (log[metric] < MetricValue)
                    {
                        Weights = model.get_weights();
                        MetricValue = log[metric];
                        BestEpoch = (int)invocation.Arguments[0];
                        logger?.LogInformation("New best epoch: {epoch}", BestEpoch);
                    }
                }

            }

            if (invocation.MethodInvocationTarget != null)
            {
                invocation.Proceed();
            }
        }
        catch (Exception ex)
        {
            model.Stop_training = true;

            if (MetricValue != null)
            {
                model.set_weights(Weights);
            }

            throw;
        }
    }
}
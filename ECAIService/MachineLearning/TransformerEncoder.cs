using Tensorflow.Common.Types;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Operations.Activation;

namespace ECAIService.MachineLearning;

//public class TransformerEncoder : Layer
//{
//    private MultiHeadAttention attention;
//    private Dense ffnDense1;
//    private Dense ffnDense2;
//    private LayerNormalization norm1;
//    private LayerNormalization norm2;

//    public TransformerEncoder(int embedDim, int numHeads, int ffDim)
//        : base(new LayerArgs())
//    {
//        // Multi-Head Attention Layer
//        attention = new MultiHeadAttention(new MultiHeadAttentionArgs
//        {
//            NumHeads = numHeads,
//            KeyDim = embedDim / numHeads
//        });

//        // Feed-Forward Network
//        ffnDense1 = new Dense(new DenseArgs
//        {
//            Units = ffDim,
//            Activation = tf.keras.activations.Relu
//        });

//        ffnDense2 = new Dense(new DenseArgs
//        {
//            Units = embedDim
//        });

//        // Layer Normalization
//        norm1 = new LayerNormalization(new LayerNormalizationArgs());
//        norm2 = new LayerNormalization(new LayerNormalizationArgs());
//    }

//    // Correctly override Call with proper signature
//    protected override Tensors Call(Tensors inputs, Tensors? state = null, bool? training = null, IOptionalArgs? optional_args = null)
//    {
//        // Self-Attention
//        var attnOutput = attention.Apply(new Tensors(inputs, inputs, inputs), training: training)[0];
//        var out1 = norm1.Apply(inputs + attnOutput, training: training)[0];

//        // Feed-Forward Network
//        var ffnOutput = ffnDense1.Apply(out1, training: training)[0];
//        ffnOutput = ffnDense2.Apply(ffnOutput, training: training)[0];
//        var out2 = norm2.Apply(out1 + ffnOutput, training: training)[0];

//        return out2;
//    }
//}

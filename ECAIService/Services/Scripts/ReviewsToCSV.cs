
using System.IO.Compression;
using System.Text.Json;

using Microsoft.ML;
using Microsoft.ML.Data;

namespace ECAIService.Services.Scripts;

public class ReviewsToCSV(MLContext mLContext, JsonSerializerOptions jsonSerializerOptions) : IAsyncScript
{
    record class Review
    {
        [LoadColumn(0)]
        public string? ReviewerID { get; set; }
        [LoadColumn(1)]
        public string? ASIN { get; set; }
        [LoadColumn(2)]
        public string? ReviewerName { get; set; }
        //[LoadColumn(3)]
        //public string[] Helpful { get; set; }
        [LoadColumn(4)]
        public string? ReviewText { get; set; }
        [LoadColumn(5)]
        public double Overall { get; set; }
        [LoadColumn(6)]
        public string? Summary { get; set; }
        [LoadColumn(7)]
        public long UnixReviewTime { get; set; }
        //[LoadColumn(8)]
        //public string? ReviewTime { get; set; }
    }


    public Task<object?> ExecuteAsync()
    {
        using var fileStream = File.OpenRead("D:\\Projects\\CSharp\\ECAIService\\ECAIService\\Resources\\reviews_Video_Games_5.json.gz");

        using var gzipStream = new GZipStream(fileStream, CompressionMode.Decompress);

        IEnumerable<string> streamLines()
        {
            using var streamReader = new StreamReader(gzipStream);
            string? line;
            while ((line = streamReader.ReadLine()) is not null)
            {
                yield return line;
            }
        }

        var lines = streamLines();

        var reviews = lines.Select(i => 
        JsonSerializer.Deserialize<Review>(i, jsonSerializerOptions))
        //.Take(10000)
        ;

        using var writeStream = File.Create("D:\\Projects\\CSharp\\ECAIService\\ECAIService\\Resources\\reviews_Video_Games_5.csv");

        return Task.FromResult<object?>(mLContext.Data.LoadFromEnumerable(reviews)
            .Apply(it => mLContext.Data.SaveAsText(it,
                                                   writeStream,
                                                   headerRow: true,
                                                   schema: false)));
    }
}

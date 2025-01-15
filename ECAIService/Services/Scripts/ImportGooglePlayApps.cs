using System.Collections.Frozen;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

using ECAIService.Data;
using ECAIService.Models;
using ECAIService.PipelineDto;
using ECAIService.Services.Abstractions;

using Microsoft.ML;

using Newtonsoft.Json;

using Tensorflow.Keras.Metrics;

namespace ECAIService.Services.Scripts;

public partial class ImportGooglePlayApps(
        CVOSContext cVOSContext,
        MLContext mLContext,
        IEncodingService encodingService,
        Random random
    ) : IAsyncScript
{

    [GeneratedRegex("[^a-z0-9]")]
    internal static partial Regex SpecialCharsRegex();

    [GeneratedRegex("^-|-$")]
    internal static partial Regex LeadingCharsRegex();
    

    internal static string ToHandle(string it) => it
    .ToLower()
    .Let(it => SpecialCharsRegex().Replace(it, "-"))
    //.Let(it => LeadingCharsRegex().Replace(it, ""))
       ;

    public async Task<object?> ExecuteAsync()
    {
        var apiKey = (await cVOSContext.ApiKeys.FindAsync("google-play")) ?? 
        (await cVOSContext.ApiKeys.AddAsync(new()
        {
            Id = "google-play",
            Token = "google-play",
            Type = "publishable",
            Redacted = "g*****-p***",
            Title = "Google Play"
        })).Entity;

        var data = mLContext.Data.LoadFromTextFile<GooglePlayApp>("Resources/googleplaystoreCleaned.csv",
            separatorChar: '\t',
            hasHeader: true,
            allowQuoting: true,
            allowSparse: true)
           .Let(it => mLContext.Data.CreateEnumerable<GooglePlayApp>(it, false));

        var categories = encodingService.GetCategories(data.Select(i => i.Genres));

        var categoryEntities = (await categories.Select(async category =>
            (await cVOSContext.ProductCategories.AddAsync(new ProductCategory()
            {
                Id = category.Key.Let(ToHandle),
                Name = category.Key,
                Handle = category.Key.Let(ToHandle),
                Description = category.Key,
                Mpath = category.Key,
                IsActive = true,
                Metadata = JsonConvert.SerializeObject(new { GooglePlayApp = true }),
            })).Entity
        ).Let(Task.WhenAll))
        .ToFrozenDictionary(i => i.Name);

        var index = 0;
        List<int> list = [];

        var salesChannel = await cVOSContext.SalesChannels.AddAsync(new()
        {
            Id = "google-play",
            Name = "Google Play",
            Description = "Google Play"
        });

        await cVOSContext.PublishableApiKeySalesChannels.AddAsync(new()
        {
            SalesChannelId = salesChannel.Entity.Id,
            PublishableKeyId = apiKey.Id,
            Id = $"{apiKey.Id}-{salesChannel.Entity.Id}"
        });

        foreach (var item in data)
        {
            if (item.AppName == ""
                || item.Price.Equals("NaN", StringComparison.CurrentCultureIgnoreCase)
                || double.IsNaN(item.Rating))
            {
                throw new ArgumentException($"Something wrong at {index}.");
            }
            else
            {
                var background = random.Next(0, int.Parse("FFF", NumberStyles.HexNumber))
                    .ToString("X");

                var font = random.Next(0, int.Parse("FFF", NumberStyles.HexNumber))
                    .ToString("X");

                var handle = item.AppName.Let(ToHandle);

                var product = await cVOSContext.Products.AddAsync(new()
                {
                    Id = handle,
                    Title = item.AppName,
                    Handle = handle,
                    Description = item.AppName,
                    Subtitle = item.AppName,
                    Thumbnail = $"https://placehold.co/360x450/{background}/{font}?text={HttpUtility.UrlEncode(item.AppName)}",
                    Status = "published",
                    ProductCategories = item.Genres.Split(";").Select(s => categoryEntities[s]).ToArray()
                });

                var variant = await cVOSContext.ProductVariants.AddAsync(new()
                {
                    Id = handle,
                    Title = item.AppName,
                    Product = product.Entity,
                    VariantRank = (item.Rating.Let(it => double.Round(it, 2, MidpointRounding.AwayFromZero)) * 100).Let(it => (int)it),
                });

                static decimal priceParse(string it) => it == "0" ? 0 : decimal.Parse(it.Substring(1));

                const int precision = 20;

                Price priceFunc() => new()
                {
                    Id = Guid.NewGuid().ToString(),
                    CurrencyCode = "usd",
                    Amount = item.Price.Let(priceParse),
                    RawAmount = JsonConvert.SerializeObject(
                            new
                            {
                                value = item.Price.Let(priceParse)
                                .Let(it => decimal.Round(it, precision, MidpointRounding.AwayFromZero))
                                .ToString(
                                    "0." +
                                    Enumerable.Repeat('#', precision)
                                    .Let(it => new string(it.ToArray()))
                                ),
                                precision
                            }),
                };

                var priceSet = await cVOSContext.PriceSets.AddAsync(new()
                {
                    Id = handle,
                    Prices =
                    [
                        priceFunc(),
                        priceFunc().Apply(it => { it.CurrencyCode = "eur"; }),
                    ]
                });

                var pvps =
                    await cVOSContext.ProductVariantPriceSets.AddAsync(new()
                    {
                        VariantId = handle,
                        PriceSetId = handle,
                        Id = handle,
                    });

                var productSalesChannel = await cVOSContext.ProductSalesChannels.AddAsync(new()
                {
                    ProductId = handle,
                    SalesChannelId = salesChannel.Entity.Id,
                    Id = handle
                });
            }
            index++;
        }
        return await cVOSContext.SaveChangesAsync();
    }
}

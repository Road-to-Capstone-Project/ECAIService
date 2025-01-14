using System.Collections.Frozen;
using System.Globalization;
using System.Web;

using ECAIService.Data;
using ECAIService.Models;
using ECAIService.PipelineDto;
using ECAIService.Services.Abstractions;

using Microsoft.ML;

using Newtonsoft.Json;

using Tensorflow.Keras.Metrics;

namespace ECAIService.Services.Scripts;

public class ImportGooglePlayApps
{
    public ImportGooglePlayApps
    (
        CVOSContext cVOSContext,
        MLContext mLContext,
        IEncodingService encodingService,
        Random random
    )
    {
        var data = mLContext.Data.LoadFromTextFile<GooglePlayApp>("Resources/googleplaystoreCleaned.csv",
            separatorChar: '\t',
            hasHeader: true,
            allowQuoting: true,
            allowSparse: true)
           .Let(it => mLContext.Data.CreateEnumerable<GooglePlayApp>(it, false));

        var categories = encodingService.GetCategories(data.Select(i => i.Genres));

        var categoryEntities = categories.Select(category =>
            cVOSContext.ProductCategories.Add(new ProductCategory()
            {
                Id = category.Key,
                Name = category.Key,
                Handle = category.Key,
                Description = category.Key,
                Mpath = category.Key,
                IsActive = true,
                Metadata = JsonConvert.SerializeObject(new { GooglePlayApp = true }),
            }).Entity
        ).ToFrozenDictionary(i => i.Id);

        var index = 0;
        List<int> list = [];

        var salesChannel = cVOSContext.SalesChannels.Add(new()
        {
            Id = "google-play",
            Name = "Google Play",
            Description = "Google Play"
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

                var product = cVOSContext.Products.Add(new()
                {
                    Id = item.AppName,
                    Title = item.AppName,
                    Handle = item.AppName,
                    Description = item.AppName,
                    Subtitle = item.AppName,
                    Weight = (item.Rating.Let(it => double.Round(it, 2, MidpointRounding.AwayFromZero)) * 100).ToString(),
                    Thumbnail = $"https://placehold.co/360x450/{background}/{font}?text={HttpUtility.UrlEncode(item.AppName)}",
                    Status = "published",
                    ProductCategories = item.Genres.Split(";").Select(s => categoryEntities[s]).ToArray()
                });

                var variant = cVOSContext.ProductVariants.Add(new()
                {
                    Id = item.AppName,
                    Title = item.AppName,
                    Product = product.Entity
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

                var priceSet = cVOSContext.PriceSets.Add(new()
                {
                    Id = item.AppName,
                    Prices =
                    [
                        priceFunc(),
                        priceFunc().Apply(it => { it.CurrencyCode = "eur"; }),
                    ]
                });

                var pvps =
                    cVOSContext.ProductVariantPriceSets.Add(new()
                    {
                        VariantId = item.AppName,
                        PriceSetId = item.AppName,
                        Id = item.AppName,
                    });

                var productSalesChannel = cVOSContext.ProductSalesChannels.Add(new()
                {
                    ProductId = item.AppName,
                    SalesChannelId = salesChannel.Entity.Id,
                    Id = item.AppName
                });
            }
            index++;
        }
        Console.WriteLine(list.JoinToString(", "));
        cVOSContext.SaveChanges();
        Console.WriteLine(list.JoinToString(", "));
    }

}

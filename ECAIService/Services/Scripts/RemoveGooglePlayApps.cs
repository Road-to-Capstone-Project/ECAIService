
using ECAIService.Data;
using ECAIService.Models;
using ECAIService.PipelineDto;

using Newtonsoft.Json;

namespace ECAIService.Services.Scripts;

public class RemoveGooglePlayApps(CVOSContext cVOSContext) : IAsyncScript
{

    public async Task<object?> ExecuteAsync()
    {
        var salesChannel = cVOSContext.SalesChannels.Find("google-play");

        if (salesChannel is null)
        {
            return -1;
        }

        var categories = cVOSContext.ProductCategories
            .Where(i => i.Metadata != null)
            .AsEnumerable()
            .Where(i => JsonConvert.DeserializeAnonymousType(i.Metadata!, new { GooglePlayApp = true })!.GooglePlayApp);

        cVOSContext.ProductCategories.RemoveRange(categories);

        var productIds = cVOSContext.ProductSalesChannels.Where(i => i.SalesChannelId == "google-play").ToList();

        cVOSContext.PublishableApiKeySalesChannels.RemoveRange(
            cVOSContext.PublishableApiKeySalesChannels.Where(i => i.SalesChannelId == "google-play")
        );

        cVOSContext.ProductSalesChannels.RemoveRange(productIds);

        foreach (var productId in productIds)
        {
            var product = (await cVOSContext.Products.FindAsync(productId.ProductId))!;

            cVOSContext.RemoveRange(
            cVOSContext.ProductSalesChannels.Where(i => i.ProductId == product.Id)
            );

            var variant = cVOSContext.ProductVariants.Where(i => i.ProductId == product.Id).Single()!;

            var pvps = cVOSContext.ProductVariantPriceSets.Where(i => i.VariantId == variant.Id).Single()!;

            var priceSet = cVOSContext.PriceSets.Where(i => i.Id == pvps.PriceSetId).Single()!;

            cVOSContext.Prices.RemoveRange(priceSet.Prices);
            cVOSContext.PriceSets.Remove(priceSet);
            cVOSContext.ProductVariantPriceSets.Remove(pvps);
            cVOSContext.ProductVariants.Remove(variant);
            cVOSContext.Products.Remove(product);
        }

        cVOSContext.SalesChannels.Remove(salesChannel);

        return await cVOSContext.SaveChangesAsync();
    }
}

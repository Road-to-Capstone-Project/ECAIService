using ECAIService.Data;
using ECAIService.PipelineDto;

using Newtonsoft.Json;

namespace ECAIService.Services.Scripts;

public class RemoveGooglePlayApps
{
    public RemoveGooglePlayApps(CVOSContext cVOSContext)
    {
        var categories = cVOSContext.ProductCategories
            .Where(i => i.Metadata != null)
            .AsEnumerable()
            .Where(i => JsonConvert.DeserializeAnonymousType(i.Metadata!, new { GooglePlayApp = true })!.GooglePlayApp);

        cVOSContext.ProductCategories.RemoveRange(categories);

        var productIds = cVOSContext.ProductSalesChannels.Where(i => i.SalesChannelId == "google-play").ToList();

        cVOSContext.ProductSalesChannels.RemoveRange(productIds);

        foreach(var productId in productIds)
        {
            var product = cVOSContext.Products.Find(productId.ProductId)!;

            var variant = cVOSContext.ProductVariants.Where(i => i.ProductId == product.Id).Single()!;

            var pvps = cVOSContext.ProductVariantPriceSets.Where(i => i.VariantId == variant.Id).Single()!;

            var priceSet = cVOSContext.PriceSets.Where(i => i.Id == pvps.PriceSetId).Single()!;

            cVOSContext.Prices.RemoveRange(priceSet.Prices);
            cVOSContext.PriceSets.Remove(priceSet);
            cVOSContext.ProductVariantPriceSets.Remove(pvps);
            cVOSContext.ProductVariants.Remove(variant);
            cVOSContext.Products.Remove(product);
        }

        cVOSContext.SalesChannels.Remove(cVOSContext.SalesChannels.Find("google-play")!);

        cVOSContext.SaveChanges();
    }
}

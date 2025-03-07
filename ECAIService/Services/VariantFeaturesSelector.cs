using ECAIService.Data;
using ECAIService.Models;

namespace ECAIService.Services;

public class VariantFeaturesSelector
{
    public string Select(ProductVariant variant)
    {
        var product = variant.Product ?? throw new NullReferenceException();

        return string.Join(" ", variant.Product.Title, variant.Product.Description);
    }
}

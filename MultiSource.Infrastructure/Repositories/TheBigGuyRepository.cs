using MultiSource.Domain.Common.Enums;
using MultiSource.Domain.Common.Serialzers;
using MultiSource.Domain.Data.Entities;
using MultiSource.Domain.Data.Providers;
using MultiSource.Domain.Repositories;
using System.Text.Json;

namespace MultiSource.Infrastructure.Repositories;

public class TheBigGuyRepository : ITourRepository
{
    public async Task<IEnumerable<Tour>> GetTours()
    {
        string jsonString = await File.ReadAllTextAsync("TheBigGuy.json");
        TheBigGuyTours theBigGuyTours = JsonSerializer.Deserialize<TheBigGuyTours>(jsonString, JsonSerializerConstants.PropertyNameCaseInsensitive);

        return theBigGuyTours.ProductData.Select(Map);
    }

    private Tour Map(TheBigGuyItem item)
    {
        return new Tour
        {
            Id = item.ProductDetailData.Id,
            Name = item.ProductDetailData.Name,
            Description = item.ProductDetailData.ProductDescription,
            Price = item.Price.Amount * (1 - item.Price.AppliedDiscount),
            Capacity = item.ProductDetailData.Capacity,
            Supplier = SupplierEnum.TheBigGuy,
            Destination = "IS" // Assuming all tours are in Iceland for this supplier
        };
    }
}

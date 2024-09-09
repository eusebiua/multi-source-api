using MultiSource.Domain.Common.Enums;
using MultiSource.Domain.Common.Serialzers;
using MultiSource.Domain.Data.Entities;
using MultiSource.Domain.Data.Providers;
using MultiSource.Domain.Repositories;
using System.Text.Json;

namespace MultiSource.Infrastructure.Repositories;

public class SomeOtherGuyRepository : ITourRepository
{
    public async Task<IEnumerable<Tour>> GetTours()
    {
        string jsonString = await File.ReadAllTextAsync("SomeOtherGuyData.json");
        SomeOtherGuyTours someOtherGuyTours = JsonSerializer.Deserialize<SomeOtherGuyTours>(jsonString, JsonSerializerConstants.PropertyNameCaseInsensitive);

        return someOtherGuyTours.Products.Select(Map);
    }

    private Tour Map(SomeOtherGuyItem item)
    {
        return new Tour
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.ProductDescription,
            Price = item.Price * (1 - item.DiscountPercentage / 100),
            Capacity = item.Capacity,
            Supplier = SupplierEnum.SomeOtherGuy,
            Destination = "TH" // Assuming all tours are in Thailand for this supplier
        };
    }
}

using MultiSource.Domain.Common.Enums;
using MultiSource.Domain.Common.Serialzers;
using MultiSource.Domain.Data.Entities;
using MultiSource.Domain.Data.Providers;
using MultiSource.Domain.Repositories;
using System.Text.Json;

namespace MultiSource.Infrastructure.Repositories;

public class TheTourGuyRepository : ITourRepository
{
    public async Task<IEnumerable<Tour>> GetTours()
    {
        var jsonString = await File.ReadAllTextAsync("TheTourGuyData.json");
        TheTourGuyTours theTourGuyTours = JsonSerializer.Deserialize<TheTourGuyTours>(jsonString, JsonSerializerConstants.PropertyNameCaseInsensitive);

        return theTourGuyTours.Data.Select(Map);
    }

    private Tour Map(TheTourGuyItem item)
    {
        return new Tour
        {
            Id = item.Id,
            Name = item.Title,
            Description = item.Description,
            Price = item.DiscountPrice,
            Capacity = item.MaximumGuests,
            Supplier = SupplierEnum.Internal,
            Destination = "MX" // Assuming all tours are in Mexico for this supplier
        };
    }
}

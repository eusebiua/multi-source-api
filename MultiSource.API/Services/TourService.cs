using MultiSource.Domain.Data.Entities;
using MultiSource.Domain.DTOs;
using MultiSource.Domain.Repositories;
using MultiSource.Domain.Services;

namespace MultiSource.API.Services;

public class TourService : ITourService
{
    private readonly IEnumerable<ITourRepository> _tourRepositories;

    public TourService(IEnumerable<ITourRepository> tourRepositories)
    {
        _tourRepositories = tourRepositories;
    }

    public async Task<TourSearchResponseDto> GetFilteredTours(TourSearchRequestDto requestFilters)
    {
        // Load tours from all repositories in parallel
        IEnumerable<Task<IEnumerable<Tour>>> tourTasks = _tourRepositories.Select(repo => repo.GetTours());
        IEnumerable<Tour>[] allToursArrays = await Task.WhenAll(tourTasks);

        IEnumerable<Tour> filteredTours = allToursArrays.SelectMany(tours => tours);

        filteredTours = FilterTours(requestFilters, filteredTours);

        // Convert to list after all filters have been applied
        List<Tour> finalFilteredTours = filteredTours.ToList();

        int totalResults = finalFilteredTours.Count;
        int totalPages = (int)Math.Ceiling((double)totalResults / requestFilters.PageSize);

        List<Tour> paginatedTours = finalFilteredTours
            .Skip(requestFilters.PageIndex * requestFilters.PageSize)
            .Take(requestFilters.PageSize)
            .ToList();

        return new TourSearchResponseDto
        {
            Tours = paginatedTours,
            TotalResults = totalResults,
            PageSize = requestFilters.PageSize,
            PageIndex = requestFilters.PageIndex,
            TotalPages = totalPages
        };
    }

    private static IEnumerable<Tour> FilterTours(TourSearchRequestDto requestFilters, IEnumerable<Tour> filteredTours)
    {
        if (requestFilters.Guests > 1)
        {
            filteredTours = filteredTours.Where(t => t.Capacity >= requestFilters.Guests);
        }

        if (requestFilters.MaxPrice.HasValue)
        {
            filteredTours = filteredTours.Where(t => t.Price <= requestFilters.MaxPrice.Value);
        }

        if (!string.IsNullOrWhiteSpace(requestFilters.Name))
        {
            filteredTours = filteredTours.Where(t => t.Name.Contains(requestFilters.Name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(requestFilters.Destination))
        {
            filteredTours = filteredTours.Where(t => t.Destination.Equals(requestFilters.Destination, StringComparison.OrdinalIgnoreCase));
        }

        if (requestFilters.Supplier.HasValue)
        {
            filteredTours = filteredTours.Where(t => t.Supplier == requestFilters.Supplier);
        }

        return filteredTours;
    }
}
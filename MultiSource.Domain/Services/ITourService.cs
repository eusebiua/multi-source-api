using MultiSource.Domain.DTOs;

namespace MultiSource.Domain.Services;

public interface ITourService
{
    Task<TourSearchResponseDto> GetFilteredTours(TourSearchRequestDto requestFilters);
}

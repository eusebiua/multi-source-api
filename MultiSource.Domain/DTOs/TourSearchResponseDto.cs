using MultiSource.Domain.Data.Entities;

namespace MultiSource.Domain.DTOs;

public class TourSearchResponseDto
{
    public List<Tour> Tours { get; set; }
    public int TotalResults { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
}

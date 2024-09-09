using MultiSource.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace MultiSource.Domain.DTOs;

public class TourSearchRequestDto
{
    [Range(1, 100, ErrorMessage = "Guests must be at least 1.")]
    public int Guests { get; set; } = 1;

    public string Name { get; set; }

    public string Destination { get; set; }

    public SupplierEnum? Supplier { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Max price must be non-negative.")]
    public decimal? MaxPrice { get; set; }

    [Range(10, 100, ErrorMessage = "Page size must be between 10 and 100.")]
    public int PageSize { get; set; } = 10;

    [Range(0, int.MaxValue, ErrorMessage = "Page index must be non-negative.")]
    public int PageIndex { get; set; } = 0;
}

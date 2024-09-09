using MultiSource.Domain.Common.Enums;

namespace MultiSource.Domain.Data.Entities;

public class Tour
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public SupplierEnum Supplier { get; set; }
    public string Destination { get; set; }
}

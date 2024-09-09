namespace MultiSource.Domain.Data.Providers;

public class SomeOtherGuyTours
{
    public List<SomeOtherGuyItem> Products { get; set; }
}

public class SomeOtherGuyItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProductDescription { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int Capacity { get; set; }
}

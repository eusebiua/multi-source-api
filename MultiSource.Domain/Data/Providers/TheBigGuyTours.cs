namespace MultiSource.Domain.Data.Providers;

public class TheBigGuyTours
{
    public List<TheBigGuyItem> ProductData { get; set; }
}

public class TheBigGuyItem
{
    public TheBigGuyProductDetailData ProductDetailData { get; set; }
    public TheBigGuyPrice Price { get; set; }
}

public class TheBigGuyProductDetailData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProductDescription { get; set; }
    public int Capacity { get; set; }
}

public class TheBigGuyPrice
{
    public decimal Amount { get; set; }
    public decimal AppliedDiscount { get; set; }
}
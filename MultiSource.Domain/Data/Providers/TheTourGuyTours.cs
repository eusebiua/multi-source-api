namespace MultiSource.Domain.Data.Providers;

public class TheTourGuyTours
{
    public List<TheTourGuyItem> Data { get; set; }
}

public class TheTourGuyItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal DiscountPrice { get; set; }
    public int MaximumGuests { get; set; }
}

namespace CleanTemplate.Application.Views.Product;

public class ProductView : BaseView<long>
{
    public decimal? Price { get; set; }
    public int Count { get; set; }
    public string SerialNumber { get; set; }
    public string ImagePath { get; set; }
    public string Type { get; set; }
}

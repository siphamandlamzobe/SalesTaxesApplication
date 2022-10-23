namespace SalesTaxesApplication.Models;

public class GoodsItem
{
    public decimal Price { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public bool IsImported { get; set; }
    public bool IsTaxExempted { get; set; }
}

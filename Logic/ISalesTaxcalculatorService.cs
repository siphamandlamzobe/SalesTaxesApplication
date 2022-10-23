using SalesTaxesApplication.Models;

namespace SalesTaxesApplication.Logic;

public interface ISalesTaxcalculatorService
{
    decimal GetItemTax(GoodsItem goodsItem);
}

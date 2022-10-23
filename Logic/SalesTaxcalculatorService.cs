using SalesTaxesApplication.Models;

namespace SalesTaxesApplication.Logic;

public class SalesTaxcalculatorService : ISalesTaxcalculatorService
{
    const decimal TaxExemption = 0;
    const decimal BasicTax = 10;
    const decimal ImportTax = BasicTax + 5;

    public decimal GetItemTax(GoodsItem item)
    {
        if (item == null)
        {
            //do something
            return 0;
        }

        if (item.IsImported)
        {
            return GetGoodsTax(item.Price, ImportTax);
        }

        if (item.IsTaxExempted)
        {
            return GetGoodsTax(item.Price, TaxExemption);
        }

        return GetGoodsTax(item.Price, BasicTax);
    }

    private decimal GetGoodsTax(decimal itemPrice, decimal taxPercentage)
    {
        return Decimal.Round(itemPrice * (taxPercentage / 100), 2);
    }
}

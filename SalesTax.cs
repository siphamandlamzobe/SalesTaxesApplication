using SalesTaxesApplication.Logic;
using SalesTaxesApplication.Models;

namespace SalesTaxesApplication;

public class SalesTax
{
	private readonly ISalesTaxcalculatorService _salesTaxcalculatorService;

	public SalesTax(ISalesTaxcalculatorService salesTaxcalculatorService)
	{
		_salesTaxcalculatorService = salesTaxcalculatorService;
	}

	public SalesTaxesResults DisplayRecieptDetails(List<GoodsItem> goodsItems)
	{
		var salesTaxes = 0m;
		var itemsTotalPrice = 0m;

		foreach (var goodsItem in goodsItems)
		{
			var itemTax = _salesTaxcalculatorService.GetItemTax(goodsItem);
			var totalPriceInclTax = goodsItem.Price + itemTax;

			salesTaxes += itemTax;
			itemsTotalPrice += totalPriceInclTax;

			Console.WriteLine(string.Format(@"{0} {1}: {2}", goodsItem.Quantity, goodsItem.Name, totalPriceInclTax));
		}

        Console.WriteLine("Sales Taxes: " + salesTaxes + "\nTotal: " + itemsTotalPrice);
		return new SalesTaxesResults()
		{
			SalesTaxes = salesTaxes,
			TotalPrice = itemsTotalPrice
		};
	}
}
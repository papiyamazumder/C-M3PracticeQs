using System;
enum CommodityCategory      // special type of class, once value added cant be modified     // Value type constant      
    {
        // your code goes here
        Furniture,                          // Key: Category , Value: Furniture, Grocery, Service
        Grocery,
        Service   
    }

class Commodity
{
    // your code goes here
    public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)       // Constructor under class
    {
        Category = category;
        CommodityName = commodityName;
        CommodityQuantity = commodityQuantity;
        CommodityPrice = commodityPrice;
    }


    public CommodityCategory Category { get; set; }
    public string CommodityName { get; set; }
    public int CommodityQuantity { get; set; }
    public double CommodityPrice { get; set; }
}

class PrepareBill
{
    // your code goes here
    private readonly IDictionary<CommodityCategory, double> _taxRates;

    public PrepareBill()
    {
        _taxRates = new Dictionary<CommodityCategory, double>();
    }

    public void SetTaxRates(CommodityCategory category, double taxRate)
    {
        //if (!_taxRates.ContainsKey(category))
        //{
        //    _taxRates.Add(category, taxRate);
        //}

        // OR

        if (_taxRates.ContainsKey(category))
        {
            //continue; -> cant be used w/o loop. as it cant break out. 
        }
        else
        {
            _taxRates.Add(category, taxRate);
        }
    }

    public double CalculateBillAmount(IList<Commodity> items)   // items -> name of Commodity Category IList
    {
        //double totalAmount = 0;

        //foreach (var item in items)
        //{
        //    if (_taxRates.TryGetValue(item.Category, out double taxRate))
        //    {
        //        double taxAmount = (taxRate / 100) * item.CommodityPrice;
        //        totalAmount += (item.CommodityPrice + taxAmount) * item.CommodityQuantity;
        //    }
        //    else
        //    {
        //        throw new ArgumentException();
        //    }
        //}

        //return totalAmount;

        // OR
 
        double totalAmount = 0.0;

        foreach (var item in items)
        {
            if (_taxRates.ContainsKey(item.Category))
            {
                double taxRate = _taxRates[item.Category];
                double x = item.CommodityQuantity * item.CommodityPrice;
                double y = (taxRate / 100) * x;
                totalAmount = totalAmount + x + y;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        return totalAmount;
    }
    class Source
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */

            var commodities = new List<Commodity>()
            {
            new Commodity(CommodityCategory.Furniture, "Bed", 2, 50000),
            new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
            new Commodity(CommodityCategory.Service, "Insurance", 8, 8500)
            };                                                           
              
            var prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);

            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine($"{billAmount}");
        }
    }
}

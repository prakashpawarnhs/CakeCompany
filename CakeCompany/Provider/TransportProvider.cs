using CakeCompany.Models;

namespace CakeCompany.Provider;

internal class TransportProvider
{
    public string CheckForAvailability(List<Product> products)
    {
        if (products == null)
            return string.Empty;

        string returnValue = "Ship";

        if (products.Sum(p => p.Quantity) < 1000)
        {
            returnValue = "Van";
        }
        else if (products.Sum(p => p.Quantity) > 1000 && products.Sum(p => p.Quantity) < 5000)
        {
            returnValue = "Truck";
        }

        return returnValue;
    }
}

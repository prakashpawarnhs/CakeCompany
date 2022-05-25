using System.Diagnostics;
using CakeCompany.Models;
using CakeCompany.Models.Transport;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("CakeCompany.UnitTest")]
namespace CakeCompany.Provider;

internal class ShipmentProvider
{
    //private readonly OrderProvider orderProvider;
    private CakeProvider cakeProvider;
    private PaymentProvider payment;
    private List<Order> cancelledOrders;
    private List<Product> products;
    private TransportProvider transportProvider;

    public ShipmentProvider()
    {
        //orderProvider = new OrderProvider();
    }

    public void InitObject()
    {
        cancelledOrders = new List<Order>();
        products = new List<Product>();
        cakeProvider = new CakeProvider();
        payment = new PaymentProvider();
        transportProvider = new TransportProvider();
    }

    public string GetShipment(Order[] orders)
    {
        //Call order to get new orders
        
        if (!orders.Any())
        {
            return "Shipment failed...";
        }
        InitObject();

        foreach (var order in orders)
        {
            if (cakeProvider.Check(order) > order.EstimatedDeliveryTime)
            {
                cancelledOrders.Add(order);
                continue;
            }

            if (!payment.Process(order).IsSuccessful)
            {
                cancelledOrders.Add(order);
                continue;
            }
            products.Add(cakeProvider.Bake(order));
        }

        switch (transportProvider.CheckForAvailability(products))
        {
            case "Van":
                    var van = new Van();
                    van.Deliver(products);
                break;
            case "Truck":
                    var truck = new Truck();
                    truck.Deliver(products);
                break;
            case "Ship":
                    var ship = new Ship();
                    ship.Deliver(products);
                break;
        }
        return "Shipment Successful...";
    }
}

// See https://aka.ms/new-console-template for more information

using CakeCompany.Provider;

var shipmentProvider = new ShipmentProvider();
shipmentProvider.GetShipment(new OrderProvider().GetLatestOrders());

Console.WriteLine("Shipment Details...");

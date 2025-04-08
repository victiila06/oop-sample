using ACME.OOP.Procurement.Domain.Model.Aggregates;
using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.Aggregates;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

var supplierAddress = new Address("123 Main St", "12345","Springfield", "IL", "62701", "USA");
var supplier = new Supplier("SUP123", "ACME Supplies", supplierAddress);

// Create a purchase object
var purchaseOrder = new PurchaseOrder("PO001", new SupplierID(supplier.Identifier), "USD");
purchaseOrder.AddItem(ProductId.New(), 10, 25.99m);
purchaseOrder.AddItem(ProductId.New(), 5, 15.99m);

// Display purchase order details
Console.WriteLine($"Purchase Order ID: {purchaseOrder.OrderNumber} created on {purchaseOrder.OrderDate} for supplier {supplier.Name}");
foreach (var item in purchaseOrder.Items)
{
    var itemSubtotal = item.CalculateSubtotal();
    Console.WriteLine($"Item Subtotal: {itemSubtotal.AsString()}");
}
var total = purchaseOrder.CalculateTotal();
Console.WriteLine($"Total: {total.AsString()}");

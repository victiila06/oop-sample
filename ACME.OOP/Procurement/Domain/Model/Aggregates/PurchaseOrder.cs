using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
/// This class represents a purchase order aggregate root for the procurement bounded context.
/// </summary>
/// <param name="orderNumber">The unique identifier for the purchase order.</param>
/// <param name="supplierId">The unique identifier for the supplier. See <see cref="SupplierId"/></param>
/// <param name="orderDate">The date and time the order was created.</param>
/// <param name="currency"></param>

public class PurchaseOrder(string orderNumber, SupplierID supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = [];
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierID SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) ||
                                      currency.Length != 3
                                      ? throw new ArgumentException("Currency length must be 3 letter ISO code.", nameof(currency))
                                      : currency;
    
    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();
    
    /// <summary>
    /// Constructor for creating a new purchase order with a specified order number, supplier ID, and currency.
    /// <remarks>This constructor initializes the order date to the current UTC times</remarks>
    /// </summary>
    /// <param name="orderNumber">The unique identifier for the purchase order.</param>
    /// <param name="supplierId">The unique identifier for the supplier. See <see cref="SupplierId"/></param>
    /// <param name="currency">The currency in wich the order is placed. Must be a </param>
    
    public PurchaseOrder(string orderNumber, SupplierID supplierId, string currency)
        : this(orderNumber, supplierId, DateTime.UtcNow, currency)
    {
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <param name="unitPriceAmount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId, nameof(productId));
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit Price Amount must be greater than zero.");
        
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
    }
    
    /// <summary>
    /// Calculates the total amount for the purchase order by summing the subtotals of all items
    /// </summary>
    /// <returns>A <see cref="Money"/></returns>

    public Money CalculateTotal()
    {
        var total = _items.Sum(item => item.CalculateSubtotal().Amount);
        return new Money(total, Currency);
    }
}


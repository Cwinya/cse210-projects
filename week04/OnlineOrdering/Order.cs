// Order.cs
public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var product in _products)
        {
            totalPrice += product.GetTotalCost();
        }

        decimal shippingCost = _customer.IsInUSA() ? 5.00m : 35.00m;
        return totalPrice + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in _products)
        {
            label += $"Product: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddressString()}";
    }
}
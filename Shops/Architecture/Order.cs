namespace Shops.Architecture
{
    public class Order
    {
        public Order(string productName, int numberOfProduct)
        {
            ProductName = productName;
            NumberOfProduct = numberOfProduct;
        }

        public string ProductName { get; }
        public int NumberOfProduct { get; }
    }
}
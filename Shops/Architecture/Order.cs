namespace Shops.Architecture
{
    public class Order
    {
        public Order(Product product, int numberOfProduct)
        {
            Product = product;
            NumberOfProduct = numberOfProduct;
        }

        public Product Product { get; }
        public int NumberOfProduct { get; }
    }
}
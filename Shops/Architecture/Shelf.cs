using Shops.Exception;

namespace Shops.Architecture
{
    public class Shelf
    {
        public Shelf(Product product, int numberOfProducts, int cost)
        {
            if (numberOfProducts <= 0 || cost <= 0)
                throw new IncorrectProductSpecificationsShopException();
            ProductInShelf = product;
            NumberOfProducts = numberOfProducts;
            Cost = cost;
        }

        public Product ProductInShelf { get; }
        public int NumberOfProducts { get; set; }
        public int Cost { get; set; }
    }
}
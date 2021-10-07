using Shops.Exception;

namespace Shops.Entities
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

        public override bool Equals(object obj)
        {
            if (obj is Shelf objectType)
            {
                return this.ProductInShelf == objectType.ProductInShelf;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
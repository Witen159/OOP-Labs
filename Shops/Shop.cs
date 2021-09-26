namespace Shops
{
    public class Shop
    {
        private static int _currentShopId = 1;
        public Shop(string shopName, string adress)
        {
            ShopName = shopName;
            Adress = adress;
            ShopId = _currentShopId;
            _currentShopId++;
        }

        public string ShopName { get; }
        public string Adress { get; }
        public int ShopId { get; }

        public void AddProducts()
        {
        }

        public void Buy(Person customer, Product product, int numberOfProducts)
        {
        }
    }
}
namespace Shops
{
    public class Shop
    {
        private static int _currentShopId = 1;
        public Shop(string shopName)
        {
            ShopName = shopName;
            ShopId = _currentShopId;
            _currentShopId++;
        }

        public string ShopName { get; }
        public int ShopId { get; }

        public void AddProducts()
        {
        }

        public void Buy(Person customer)
        {
        }
    }
}
namespace Shops.Entities
{
    public class Product
    {
        private static int _currentProductId = 1;
        public Product(string productName)
        {
            ProductName = productName;
            ProductID = _currentProductId;
            _currentProductId++;
        }

        public string ProductName { get; }
        public int ProductID { get; }

        public override bool Equals(object obj)
        {
            if (obj is Product objectType)
            {
                return this.ProductID == objectType.ProductID;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICheckout
    {
        void Scan(string productId);
        int Total();
    }
    public interface IProduct
    {
        string ProductId { get; set; }
        int Price { get; set; }
    }

    public interface IDiscount
    {
        string ProductId { get; set; }
        int NumOfProducts { get; set; }
        int Deduction { get; set; }
    }

    public class Checkout : ICheckout
    {
        private readonly List<IProduct> _productsFromStore;
        private readonly List<IDiscount> _discounts;
        private readonly List<IProduct> _scannedProducts;

        public Checkout(List<IProduct> products, List<IDiscount> discounts)
        {
            _productsFromStore = products;
            _discounts = discounts;
            _scannedProducts = new List<IProduct>();
        }

        public void Scan(string productId)
        {
            throw new NotImplementedException();
        }

        public int Total()
        {
            return 0;
        }
    }

    public class Product : IProduct
    {
        public string ProductId { get; set; }
        public int Price { get; set; }
    }

    public class Discount : IDiscount
    {
        public string ProductId { get; set; }
        public int NumOfProducts { get; set; }
        public int Deduction { get; set; }
    }
}

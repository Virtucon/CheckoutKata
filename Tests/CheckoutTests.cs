using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Tests
{
    public class CheckoutTests
    {
        private readonly List<IProduct> _products = new List<IProduct>()
        {
            new Product() {ProductId = "A", Price = 50},
            new Product() {ProductId = "B", Price = 30},
            new Product() {ProductId = "C", Price = 20},
            new Product() {ProductId = "D", Price = 15},
        };

        private readonly List<IDiscount> _discounts = new List<IDiscount>()
        {
            new Discount() {ProductId = "A", NumOfProducts = 3, Deduction = 20},
            new Discount() {ProductId = "B", NumOfProducts = 2, Deduction = 15},
        };

        private readonly ICheckout _checkout;

        public CheckoutTests()
        {
            _checkout = new Checkout(_products, _discounts);
        }
    }
}

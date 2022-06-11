using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Xunit;

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

        [Fact]
        public void ReturnsZeroGivenNoItems()
        {
            Assert.Equal(0, _checkout.Total());
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        public void ReturnsCorrectTotalForOneItem(string productId, int expectedTotal)
        {
            _checkout.Scan(productId);

            Assert.Equal(expectedTotal, _checkout.Total());
        }

        [Theory]
        [InlineData("A,B", 80)]
        [InlineData("B,C", 50)]
        [InlineData("C,D", 35)]
        public void ReturnsCorrectTotalForTwoItems(string productId, int expectedTotal)
        {
            _checkout.Scan(productId);

            Assert.Equal(expectedTotal, _checkout.Total());
        }
    }
}

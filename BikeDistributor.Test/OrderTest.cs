using System.Collections.Generic;
using BikeDistributor.ReceiptRenderers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50";
        private const string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $2,000.00
Sub-Total: $2,000.00
Tax: $145.00
Total: $2,145.00";
        private const string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50";

        private const string HtmlResultStatementOneDefy =
            @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";

        private const string HtmlResultStatementOneElite =
            @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        private const string HtmlResultStatementOneDuraAce =
            @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";

        private static readonly Bike Defy = new Bike("Giant", "Defy 1", 1000);
        private static readonly Bike Elite = new Bike("Specialized", "Venge Elite", 2000);
        private static readonly Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", 5000);


        private readonly double TaxRate = .0725d;


        private List<DiscountRule> GetDefaultDiscountRules()
        {
            var discountRules = new List<DiscountRule>();

            discountRules.Add(new DiscountRule(1000, 20, .9d));
            discountRules.Add(new DiscountRule(2000, 10, .8d));
            discountRules.Add(new DiscountRule(5000, 5, .8d));

            return discountRules;
        }

        [TestMethod]
        public void ReceiptOneDefy()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new ReceiptRenderer());
            order.AddRental(new Line(Defy, 1));
            Assert.AreEqual(ResultStatementOneDefy, order.RenderReceipt());
        }

        [TestMethod]
        public void ReceiptOneElite()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new ReceiptRenderer());
            order.AddRental(new Line(Elite, 1));
            Assert.AreEqual(ResultStatementOneElite, order.RenderReceipt());
        }

        [TestMethod]
        public void ReceiptOneDuraAce()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new ReceiptRenderer());
            order.AddRental(new Line(DuraAce, 1));
            Assert.AreEqual(ResultStatementOneDuraAce, order.RenderReceipt());
        }

        [TestMethod]
        public void HtmlReceiptOneDefy()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(Defy, 1));
            Assert.AreEqual(HtmlResultStatementOneDefy, order.RenderReceipt());
        }

        [TestMethod]
        public void HtmlReceiptOneElite()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(Elite, 1));
            Assert.AreEqual(HtmlResultStatementOneElite, order.RenderReceipt());
        }

        [TestMethod]
        public void HtmlReceiptOneDuraAce()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(DuraAce, 1));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.RenderReceipt());
        }

        [TestMethod]
        public void DiscountedDefy()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(Defy, 20));
            double total = order.CalculateTotal();
            Assert.AreEqual(total, (20 * 1000) * .9);
        }

        [TestMethod]
        public void FullPriceDefy()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(Defy, 19));
            double total = order.CalculateTotal();
            Assert.AreEqual(total, (19 * 1000));
        }

        [TestMethod]
        public void FullPriceElite()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(Elite, 9));
            double total = order.CalculateTotal();
            Assert.AreEqual(total, (9 * 2000));
        }

        [TestMethod]
        public void DiscountedElite()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(Elite, 10));
            double total = order.CalculateTotal();
            Assert.AreEqual(total, (10 * 2000) * .8);
        }

        [TestMethod]
        public void FullPriceDuraAce()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(DuraAce, 4));
            double total = order.CalculateTotal();
            Assert.AreEqual(total, (4 * 5000));
        }

        [TestMethod]
        public void DiscountedDuraAce()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, GetDefaultDiscountRules(),
                new HtmlReceiptRenderer());
            order.AddRental(new Line(DuraAce, 5));
            double total = order.CalculateTotal();
            Assert.AreEqual(total, (5 * 5000) * .8);
        }

        [TestMethod]
        public void NoDiscountRules()
        {
            var order = new Order(new Company("Anywhere Bike Shop"), TaxRate, null,
                new HtmlReceiptRenderer());
            order.AddRental(new Line(DuraAce, 1));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.RenderReceipt());
        }
    }
}
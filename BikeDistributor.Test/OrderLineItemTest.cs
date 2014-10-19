using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderLineItemTest
    {
        [TestMethod]
        public void TotalShouldBeNull()
        {
            var lineItem = new OrderLineItem();
            Assert.IsNull(lineItem.Total); 
        }
        [TestMethod]
        public void TotalCorrectNoDiscount()
        {

            var lineItem = new OrderLineItem();

            lineItem.Bike = new Bike("Brand", "Model", 500);
            lineItem.Quantity = 10;
            lineItem.Calculate();
            Assert.AreEqual(5000, lineItem.Total);
            Assert.IsFalse(lineItem.DiscountApplied);

        }
        [TestMethod]
        public void TotalCorrectWithDiscount()
        {

            var lineItem = new OrderLineItem();

            lineItem.Bike = new Bike("Brand", "Model", 500);
            lineItem.Quantity = 10;
            var discountRules = new List<DiscountRule>() { new DiscountRule(500, 10, .5) };
            lineItem.Calculate(discountRules);
            Assert.AreEqual(2500, lineItem.Total);
            Assert.IsTrue(lineItem.DiscountApplied);
            Assert.AreEqual(2500, lineItem.Total);
            Assert.AreEqual(2500, lineItem.DiscountAmount);
        }
    }
}

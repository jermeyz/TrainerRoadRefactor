using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class DiscountRuleTest
    {
        [TestMethod]
        public void DiscountApplied()
        {

            var rule = new DiscountRule(10,5,0);
           
            Assert.IsTrue(rule.DoesDiscountApply(10, 5));
        }
        [TestMethod]
        public void DiscountAppliedGreaterThan()
        {

            var rule = new DiscountRule(10,5,0);
            
            Assert.IsTrue(rule.DoesDiscountApply(10, 10));
        }
        [TestMethod]
        public void DiscountNotApplied()
        {

            var rule = new DiscountRule(10,5,0);
             
            Assert.IsFalse(rule.DoesDiscountApply(9, 5));
        }
        [TestMethod]
        public void DiscountAmountAppliedIsCorrect()
        {

            var rule = new DiscountRule(10,5,.5);
           
            Assert.IsTrue(rule.DoesDiscountApply(10, 10));
            Assert.AreEqual(50, rule.ApplyDiscount(10, 10));
        }
        [TestMethod]
        public void DiscountAmountIsCorrectWhenRuleApplied()
        {

            var rule = new DiscountRule(10,5,.5);
          
            Assert.IsTrue(rule.DoesDiscountApply(10, 10));
            Assert.AreEqual(50,rule.DiscountAmount(10,10));
        }
        [TestMethod]
        public void DiscountAmountIsCorrectWhenRuleNotApplied()
        {

            var rule = new DiscountRule(10,5,.5);
            
            Assert.IsFalse(rule.DoesDiscountApply(10, 3));
            Assert.AreEqual(0, rule.DiscountAmount(10, 3));
        }
    }
}

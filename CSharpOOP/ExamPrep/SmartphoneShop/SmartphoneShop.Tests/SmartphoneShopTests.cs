using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void TestSmartphoneConstructor()
        {
            Smartphone smartphone = new Smartphone("Apple", 100);
            Assert.IsNotNull(smartphone);
            Assert.That(smartphone.MaximumBatteryCharge, Is.EqualTo(100));
            Assert.That(smartphone.ModelName == "Apple");
            Assert.That(smartphone.CurrentBateryCharge == 100);

        }
        [Test]
        public void TestShopConstructor()
        {
            Shop smartphone = new Shop(100);
            Assert.IsNotNull(smartphone);
            Assert.That(smartphone.Capacity, Is.EqualTo(100));
            Assert.That(smartphone.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestCapasity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop smartphone = new Shop(-1);
            }, "Invalid capacity.");
        }
        [Test]
        public void TestCapasityExeption()
        {
          Shop smartphone = new Shop(10);
            Assert.That(smartphone.Capacity == 10);
        }
        [Test]
        public void TestAddMethod()
        {
            Shop shop = new Shop(100);
            shop.Add(new Smartphone("Apple", 100));
            Assert.That(shop.Count == 1);
        }
        [Test]
        public void TestCountMethod()
        {
            Shop shop = new Shop(100);
            Assert.That(shop.Count == 0);
        }
        [Test]
        public void TestAddMethodExceedingCapasity()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("Apple", 100));
            shop.Add(new Smartphone("htv", 100));
            shop.Add(new Smartphone("huawei", 100));
            shop.Add(new Smartphone("samsung", 100));
            shop.Add(new Smartphone("nesk", 100));
            shop.Add(new Smartphone("fdjd", 100));
            shop.Add(new Smartphone("sdjkdj", 100));
            shop.Add(new Smartphone("Afle", 100));
            shop.Add(new Smartphone("Apadfple", 100));
            shop.Add(new Smartphone("Apsdfple", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Apsdfgple", 100));
            }, "The shop is full.");
        }
        [Test]
        public void TestAddMethodWithTheSameName()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("Apple", 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Apple", 100));
            }, "The phone model Apple already exist.");
        }

        [Test]
        public void TestRemoveMethodWithNonExistingPhone()
        {
            Shop shop = new Shop(10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Apple");
            }, "The phone model Apple doesn't exist.");
        }
        [Test]
        public void TestRemoveMethod()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("Apple", 100));
            shop.Remove("Apple");
            Assert.That(shop.Count == 0);
        }
        [Test]
        public void TestTestPhoneMethodWithNonExistingPhone()
        {
            Shop shop = new Shop(10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Apple",50);
            }, "The phone model Apple doesn't exist.");
        }
        [Test]
        public void TestTestPhoneMethodWithLowerBatery()
        {
            Shop shop = new Shop(10);
            shop.Add(new Smartphone("Apple", 99));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Apple", 100);
            }, "The phone model Apple is low on batery.");
        }
        [Test]
        public void TestTestPhoneMethod()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Apple", 100);
            shop.Add(smartphone);
            shop.TestPhone("Apple",99);

            Assert.That(smartphone.CurrentBateryCharge == 1);
            
        }

        [Test]
        public void TestChargePhoneMethod()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Apple", 100);
            shop.Add(smartphone);
            shop.ChargePhone("Apple");

            Assert.That(smartphone.CurrentBateryCharge == 100);

        }
        [Test]
        public void TestChargePhoneMethodWithNonExistingPhone()
        {
            Shop shop = new Shop(10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Apple");
            }, "The phone model Apple doesn't exist.");
        }
    }
}
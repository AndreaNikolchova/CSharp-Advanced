namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void TestContructor()
        {
            Bag bag = new Bag();
            Assert.IsNotNull(bag);
        }
        [Test]
        public void TestCollection()
        {
            Bag bag = new Bag();
            CollectionAssert.AreEqual(bag.GetPresents(), new List<Present>());
            Assert.That(bag.GetPresents().Count, Is.EqualTo(0));
        }
        [Test]
        public void TestCreateWithNullPresent()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            }, "Present is null");

        }


        [Test]
        public void TestCreateWithAlreadyCreatedPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("name", 10);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "This present already exists!");

        }
       [Test]
        public void TestCreate()
        {
            Bag bag = new Bag();
            Present present = new Present("name", 10);
            string result = bag.Create(present);
            CollectionAssert.AreEqual(new List<Present>() { present }, bag.GetPresents());
            Assert.AreEqual(result, $"Successfully added present {present.Name}.");


        }

      
        [Test]
        public void TestRemoveTrue()
        {
            Bag bag = new Bag();
            Present present = new Present("name", 10);
            bag.Create(present);
            bool remove = bag.Remove(present);
            Assert.That(0, Is.EqualTo(bag.GetPresents().Count()));
            Assert.AreEqual(remove, true);

        }
        //[Test]
        //public void RemoveMethod_ReturnsNotSuccessfull()
        //{
        //    Present present = new Present("Cars", 10.5);
        //    Bag bag = new Bag();

        //    Assert.AreEqual(bag.Remove(present), false);
        //}
        [Test]
        public void TestRemoveFalse()
        {
            Bag bag = new Bag();
            Present present = new Present("name", 10);
            bool remove = bag.Remove(present);
            Assert.AreEqual(remove, false);

        }
        [Test]
        public void TestGetPresentWithLeastMagic()
        {
            Present present = new Present("Cars", 10.5);
            Present present2 = new Present("Dolls", 20);
            Present present3 = new Present("RC car", 5);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            Present resultPresent = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(resultPresent, present3);
        }
       

        [Test]
        public void TestFindPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("name", 10);
            bag.Create(present);
            Present smt = bag.GetPresent("name");
            Assert.AreEqual(present,smt);

        }
        [Test]
        public void TestFindPresentNull()
        {
            Bag bag = new Bag();
            Present smt = bag.GetPresent("name");
            Assert.That(smt, Is.Null);

        }
      
    }
}

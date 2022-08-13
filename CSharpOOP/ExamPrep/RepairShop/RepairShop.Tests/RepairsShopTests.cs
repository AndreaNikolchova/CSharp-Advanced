using NUnit.Framework;
using System;

namespace RepairShop.Tests
{

    public class RepairsShopTests
    {
        [Test]
        public void TestConstructor()
        {
            Garage garage = new Garage("garaj", 10);
            Assert.That(garage, Is.Not.Null);
            Assert.That(garage.Name == "garaj");
            Assert.That(garage.CarsInGarage == 0);

        }
        [TestCase("")]
        [TestCase(null)]
        public void TestNameProperty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Garage garage = new Garage(name, 10);

            }, "Invalid garage name.");

        }
        [TestCase("Ache")]
        [TestCase("valid")]
        public void TestNamePropertyValid(string name)
        {

            Garage garage = new Garage(name, 10);
            Assert.That(garage.Name == name);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void TestMechanicProperty(int mech)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Garage garage = new Garage("garaj", mech);

            }, "At least one mechanic must work in the garage.");

        }
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(20)]
        public void TestMechanicPropertyValid(int mech)
        {
            Garage garage = new Garage("garaj", mech);
            Assert.That(garage.MechanicsAvailable == mech);
        }
        [Test]
        public void TestAddCarExeption()
        {
            Garage garage = new Garage("garaj", 1);
            garage.AddCar(new Car("Honda", 5));
            Assert.Throws<InvalidOperationException>(() =>
            {
                garage.AddCar(new Car("Hoda", 9));

            }, "No mechanic available.");
        }
        [Test]
        public void TestAddCar()
        {
            Garage garage = new Garage("garaj", 1);
            garage.AddCar(new Car("Honda", 5));
           Assert.That(garage.CarsInGarage == 1);
        }
        [Test]
        public void TestFixCar()
        {
            Garage garage = new Garage("garaj", 1);
            Car car = new Car("Honda", 5);
            garage.AddCar(car);
            garage.FixCar("Honda");
            Assert.That(car.NumberOfIssues == 0);
            Assert.That(car.IsFixed == true);
        }
        [Test]
        public void TestFixCarNonExistingCar()
        {
            Garage garage = new Garage("garaj", 1);
            Car car = new Car("Honda", 5);
            garage.AddCar(car);
            Assert.Throws<InvalidOperationException>(() =>
            {
            garage.FixCar("Audi");

            }, "The car Audi doesn't exist.");
        }
        [Test]
        public void TestRemoveCarNonExistingCar()
        {
            Garage garage = new Garage("garaj", 1);
            Car car = new Car("Honda", 5);
            garage.AddCar(car);
            Assert.Throws<InvalidOperationException>(() =>
            {
                garage.RemoveFixedCar();

            }, "No fixed cars available.");
        }
        [Test]
        public void TestRemoveCar()
        {
            Garage garage = new Garage("garaj", 1);
            Car car = new Car("Honda", 5);
            garage.AddCar(car);
            garage.FixCar("Honda");
            garage.RemoveFixedCar();
            Assert.That(garage.CarsInGarage == 0);
        }
        [Test]
        public void TestReportMethod()
        {
            Garage garage = new Garage("garaj", 5);
            Car car = new Car("Honda", 5);
            garage.AddCar(car);
            garage.AddCar(new Car("BMW", 1000));
            garage.FixCar("Honda");
            garage.RemoveFixedCar();
            string result = garage.Report();
            Assert.That(result == $"There are {1} which are not fixed: BMW.");
        }



    }

}
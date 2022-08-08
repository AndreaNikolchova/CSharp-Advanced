namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void TestConstructors()
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            //Act
            Car car = new Car(make, model, fuelConsumption, fuel);
            //Assert
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuel));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestMakeProperty_Exeption(string make)
        {
            //Arrange
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                Car car = new Car(make, model, fuelConsumption, fuel);

            },
            //Assert
            "Make cannot be null or empty!");
        }
        [Test]
        public void TestMakeProperty()
        {
            //Arrange
            string make ="Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            //Act
            Car car = new Car(make, model, fuelConsumption, fuel);
            //Assert
            Assert.That(make, Is.EqualTo(car.Make));
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestModelProperty_Exeption(string model)
        {
            //Arrange
            string make = "Honda";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                Car car = new Car(make, model, fuelConsumption, fuel);

            },
            //Assert
            "Model cannot be null or empty!");
        }
        [Test]
        public void TestModelProperty()
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            //Act
            Car car = new Car(make, model, fuelConsumption, fuel);
            //Assert
            Assert.That(model, Is.EqualTo(car.Model));
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void TestFuelConsumptionProperty_Exeption(double fuelConsumption)
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuel = 50.00;
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                Car car = new Car(make, model, fuelConsumption, fuel);

            },
            //Assert
            "Fuel consumption cannot be zero or negative!");
        }
        [Test]
        public void TestFuelConsumpitonProperty()
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            //Act
            Car car = new Car(make, model, fuelConsumption, fuel);
            //Assert
            Assert.That(fuelConsumption, Is.EqualTo(car.FuelConsumption));
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void TestFuelCapasityProperty_Exeption(double fuel)
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                Car car = new Car(make, model, fuelConsumption, fuel);

            },
            //Assert
            "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void TestFuelCapasityProperty()
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            //Act
            Car car = new Car(make, model, fuelConsumption, fuel);
            //Assert
            Assert.That(fuel, Is.EqualTo(car.FuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-23.6)]
        public void TestRefuelMetod_Exeption(double liters)
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            Car car = new Car(make, model, fuelConsumption, fuel);
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                car.Refuel(liters);
            },
            //Assert
            "Fuel amount cannot be zero or negative!");
        }
        [TestCase(1)]
        [TestCase(20)]
        [TestCase(12.5)]
        [TestCase(51.5)]
        public void TestRefuelMetod(double liters)
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuelConsumption = 6.5;
            double fuel = 50.00;
            Car car = new Car(make, model, fuelConsumption, fuel);
            //Act
            car.Refuel(liters);
            //Assert 
            if (car.FuelCapacity <= liters)
                Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
            else
                Assert.That(car.FuelAmount, Is.EqualTo(liters));
        }

        [TestCase(20,10.00,50)]
        [TestCase(200,10.00,50)]
        [TestCase(200, 10.00, 20)]
        public void TestDriveMetod(int distance, double fuelConsumption,double liters)
        {
            //Arrange
            //double fuelNeeded = (distance / 100) * this.FuelConsumption;
            string make = "Honda";
            string model = "Civic";
            double fuel = 50.00;
            Car car = new Car(make, model, fuelConsumption, fuel);
            car.Refuel(liters);
            double fuelNeeded = (distance * car.FuelConsumption)/100;
            double fuelAmount = car.FuelAmount - fuelNeeded;
            //Act
            car.Drive(distance);
            //Assert 
            Assert.That(fuelAmount, Is.EqualTo(car.FuelAmount));
        }

        [TestCase(10,10,0.5)]
        [TestCase(20,10,1.5)]
        public void TestDriveMetod_Exeption(int distance, double fuelConsumption,double litters)
        {
            //Arrange
            string make = "Honda";
            string model = "Civic";
            double fuel = 50.00;
            Car car = new Car(make, model, fuelConsumption, fuel);
            car.Refuel(litters);
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                car.Drive(distance);
            },
            //Assert 
            "You don't have enough fuel to drive!");

        }

    }
}
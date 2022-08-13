namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void TestConstructor()
        {
            Aquarium aquarium = new Aquarium("Name", 10);
            Assert.That(aquarium, Is.Not.Null);
            Assert.That(aquarium.Name, Is.EqualTo("Name"));
            Assert.That(aquarium.Count, Is.EqualTo(0));
            Assert.That(aquarium.Capacity, Is.EqualTo(10));
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestNamePropertyInvalidArguments(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 10);

            }, "Invalid aquarium name!");

        }

        [TestCase("Name")]
        [TestCase("Az")]
        [TestCase(" ")]
        public void TestNamePropertyValidArguments(string name)
        {
            Aquarium aquarium = new Aquarium(name, 10);
            Assert.That(aquarium, Is.Not.Null);
            Assert.That(aquarium.Name, Is.EqualTo(name));

        }
        [Test]
        public void TestCapacityPropertyValidArguments()
        {
            Aquarium aquarium = new Aquarium("Name", 10);
            Assert.That(aquarium, Is.Not.Null);
            Assert.That(aquarium.Capacity, Is.EqualTo(10));

        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void TestCapacityPropInvalidArguments(int capasity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("name", capasity);

            }, "Invalid aquarium capacity!");

        }

        [Test]
        public void TestAddMethodInvalidArguments()
        {
                Aquarium aquarium = new Aquarium("name", 5);
                aquarium.Add(new Fish("kn"));
                aquarium.Add(new Fish("kn"));
                aquarium.Add(new Fish("kn"));
                aquarium.Add(new Fish("kn"));
                aquarium.Add(new Fish("kn"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(new Fish("kn"));


            }, "Aquarium is full!");

        }

        [Test]
        public void TestAddMethodValidArguments()
        {
            Aquarium aquarium = new Aquarium("name", 10);
            aquarium.Add(new Fish("kn"));
            aquarium.Add(new Fish("kn"));
            aquarium.Add(new Fish("kn"));
            aquarium.Add(new Fish("kn"));
            aquarium.Add(new Fish("kn"));
            aquarium.Add(new Fish("kn"));
            Assert.That(aquarium.Count == 6);

        }

        [Test]
        public void TestRemoveMethodInvalidArguments()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Aquarium aquarium = new Aquarium("name", 10);
                aquarium.Add(new Fish("kn"));
                aquarium.RemoveFish("pesho");

            }, $"Fish with the name pesho doesn't exist!");

        }

        [Test]
        public void TestRemoveMethodValidArguments()
        {
            Aquarium aquarium = new Aquarium("name", 10);
            aquarium.Add(new Fish("kn"));
            aquarium.RemoveFish("kn");
            Assert.That(aquarium.Count == 0);

        }

        [Test]
        public void TestSellFishMethodInvalidArguments()
        {
                Aquarium aquarium = new Aquarium("name", 10);
                aquarium.Add(new Fish("kn"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("pesho");



            }, $"Fish with the name pesho doesn't exist!");

        }
        [Test]
        public void TestSellMethodValidArguments()
        {
            Aquarium aquarium = new Aquarium("name", 10);
            Fish fish = new Fish("Az");
            aquarium.Add(fish);
            aquarium.Add(new Fish("kn"));
            Fish soldFish = aquarium.SellFish("Az");
            Assert.That(soldFish, Is.EqualTo(fish));
            Assert.That(fish.Available, Is.False);

        }
        [Test]
        public void TestReportMethod()
        {
            Aquarium aquarium = new Aquarium("name", 10);
            Fish fish = new Fish("Az");
            aquarium.Add(fish);
            aquarium.Add(new Fish("kn"));
            string soldFish = aquarium.Report();
            Assert.That(soldFish == $"Fish available at name: Az, kn");

        }

    }
}

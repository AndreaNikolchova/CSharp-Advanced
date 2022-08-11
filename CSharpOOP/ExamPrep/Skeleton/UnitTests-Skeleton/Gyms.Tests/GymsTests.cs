namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class GymsTests
    {
       [Test]
        public void TestAthleteClass()
        {
            Athlete athlete = new Athlete("Vladimir");
            Assert.That(athlete,Is.Not.Null);
            Assert.That(athlete.FullName, Is.EqualTo("Vladimir"));
            Assert.That(athlete.IsInjured, Is.False);
        }
        [Test]
        public void TestGymConstructor()
        {
            Gym gym = new Gym("Vladi", 10);
            Assert.That(gym.Name == "Vladi");
            Assert.That(gym.Capacity == 10);
            Assert.That(gym.Count == 0);
        }
        [TestCase(null)]
        [TestCase("")]
        public void TestNamePropertyWithInvalidArgument(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 10);
            }, "Name","Invalid gym name.");
        }
        [TestCase(-1)]
        [TestCase(-19)]
        public void TestCapasityPropertyWithInvalidArgument(int capasity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Vladko", capasity);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void TestCountGetter()
        {
            Gym gym = new Gym("Vladi", 10);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            Assert.That(gym.Count == 2);
        }
        [Test]
        public void TestAddAthleteSuccsesfull()
        {
            Gym gym = new Gym("Vladi", 10);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            Assert.That(gym.Count == 4);
        }
        [Test]
        public void TestAddAthleteExeption()
        {
            Gym gym = new Gym("Vladi", 11);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("jaj"));
            }, "The gym is full.");
        }
        [Test]
        public void TestRemoveWithValidArgument()
        {
            Gym gym = new Gym("Vladi", 20);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.RemoveAthlete("Vladko");
            Assert.That(gym.Count, Is.EqualTo(10));
        }
        [Test]
        public void TestRemoveWithInvalidArgument()
        {
            Gym gym = new Gym("Vladi", 20);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("iki");
            }, $"The athlete iki doesn't exist.");
        }
        [Test]
        public void TestInjureAthleteWithInvalidArgument()
        {
            Gym gym = new Gym("Vladi", 20);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("iki");
            }, $"The athlete iki doesn't exist.");
        }
        [Test]
        public void TestInjureAthleteWithValidArguments()
        {
            Gym gym = new Gym("Vladi", 20);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            Athlete athlete = gym.InjureAthlete("Acheto");
            Assert.That(athlete.IsInjured == true);
            Assert.That(athlete.FullName == "Acheto");
            Assert.That(athlete, Is.Not.Null);
        }

        [Test]
        public void TestReport()
        {

            Gym gym = new Gym("Vladi", 20);
            gym.AddAthlete(new Athlete("Vladko"));
            gym.AddAthlete(new Athlete("Acheto"));
            gym.AddAthlete(new Athlete("bla"));
            gym.AddAthlete(new Athlete("tada"));
            gym.InjureAthlete("tada");
            string report = gym.Report();
            Assert.That(report == "Active athletes at Vladi: Vladko, Acheto, bla");

        }

    }
}

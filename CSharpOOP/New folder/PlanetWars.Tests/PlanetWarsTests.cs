using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void TestPlanetConstructor()
            {
                Planet planet = new Planet("..", 100);
                Assert.That(planet,Is.Not.Null);
                Assert.That(planet.Name == "..");
                Assert.That(planet.Budget == 100);  
                Assert.That(planet.Weapons.Count == 0); CollectionAssert.AreEqual(planet.Weapons, new List<Weapon>());
            }
            [Test]
            public void TestNameProperty()
            {
                Planet planet = new Planet("..", 100);
                Assert.That(planet.Name == "..");
            }
            [Test]
            public void TestNamePropertyNull()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 100);

                });
            }
            [Test]
            public void TestNamePropertyEmpty()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("", 100);

                });
            }
            [Test]
            public void TestBudgetInavlid()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("", -1);

                });
            }
            [Test]
            public void TestBudgetValid()
            {
                Planet planet = new Planet("", 100);
                Assert.That(planet.Budget == 100);
            }
            [Test]
            public void TestMilitaryPowerRatio()
            {
                Planet planet = new Planet("...", 100);
                planet.AddWeapon(new Weapon(".", 12, 10));
                planet.AddWeapon(new Weapon("..", 12, 10));
                planet.AddWeapon(new Weapon(".-", 12, 10));
                Assert.That(planet.MilitaryPowerRatio == 30);
            }
            [Test]
            public void TestProfitMethod()
            {
                Planet planet = new Planet("...", 100);
                planet.Profit(30);
                Assert.That(planet.Budget == 130);
            }
            [Test]
            public void TestSuspendFundsMethod()
            {
                Planet planet = new Planet("...", 100);
                planet.SpendFunds(30);
                Assert.That(planet.Budget == 70);
            }
            [Test]
            public void TestSuspendFundsInvalidMethod()
            {
                Planet planet = new Planet("...", 100);
                Assert.Throws<InvalidOperationException>(() =>
                {

                planet.SpendFunds(110);
                });
            }
            [Test]
            public void TestAddInvalidMethod()
            {
                Planet planet = new Planet("...", 100);
                Assert.Throws<InvalidOperationException>(() =>
                {

                    planet.AddWeapon(new Weapon(".", 12, 233));
                    planet.AddWeapon(new Weapon(".", 12, 233));
                });

            }
            [Test]
            public void TestAddMethod()
            {
                Planet planet = new Planet("...", 100);
                Weapon weapon = new Weapon(".", 12, 233);
                planet.AddWeapon(weapon);
                Assert.That(planet.Weapons.Count == 1);
                CollectionAssert.AreEqual(planet.Weapons, new List<Weapon>() { weapon });

            }
            [Test]
            public void TestRemoveMethod()
            {
                Planet planet = new Planet("...", 100);
                planet.AddWeapon(new Weapon(".", 12, 233));
                planet.RemoveWeapon(".");
                Assert.That(planet.Weapons.Count == 0);
                CollectionAssert.AreEqual(planet.Weapons, new List<Weapon>());
            }
            [Test]
            public void TestUpgrateInvalidMethod()
            {
                Planet planet = new Planet("...", 100);
                Assert.Throws<InvalidOperationException>(() =>
                {

                    planet.UpgradeWeapon(".");
                });
            }
            [Test]
            public void TestUpgradeMethod()
            {
                Planet planet = new Planet("...", 100);
                Weapon weapon = new Weapon(".", 12, 2);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(".");
                Assert.That(weapon.DestructionLevel == 3);
                Assert.That(planet.Weapons.First(x=>x.Name == ".").DestructionLevel == 3);

            }
            [Test]
            public void TestDestructOpponentMethod()
            {
                Planet planet = new Planet("...", 100);
                Planet planet1 = new Planet("..", 100);
                Weapon weapon = new Weapon(".", 12, 2);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(".");
                string result = planet.DestructOpponent(planet1);
                Assert.That(result == $".. is destructed!");

            }
            [Test]
            public void TestDestructOpponentInvalidMethod()
            {
                Planet planet = new Planet("...", 100);
                Planet planet1 = new Planet("..", 100);
                Weapon weapon = new Weapon(".", 12, 2);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(".");
                Assert.Throws<InvalidOperationException>(() =>
                {
                planet1.DestructOpponent(planet);

                });
               

            }

        }
    }
}

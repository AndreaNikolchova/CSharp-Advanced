using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PlanetWars.Tests
{
    public class WeaponTests
    {
        [Test]
        public void TestWeaponConstructor()
        {
            Weapon weapon = new Weapon("...", 5.5, 7);
            Assert.That(weapon, Is.Not.Null);
            Assert.That(weapon.Name == "...");
            Assert.That(weapon.Price == 5.5);
            Assert.That(weapon.DestructionLevel == 7);
         
        }
        [Test]
        public void TestNameProp()
        {
            Weapon weapon = new Weapon("...", 5.5, 7);
            Assert.That(weapon.Name == "...");
        }
        [Test]
        public void TestPricePropNotValidArgumets()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Weapon weapon = new Weapon("...", -1, 7);

            }, "Price cannot be negative.");
        }
        [Test]
        public void TestPriceProp()
        {
            Weapon weapon = new Weapon("...", 5.5, 7);
            Assert.That(weapon.Price == 5.5);
        }
        [Test]
        public void TestDestructionProp()
        {
            Weapon weapon = new Weapon("...", 5.5, 7);
            Assert.That(weapon.DestructionLevel == 7);
        }
        [Test]
        public void TestIncreaseDestructionMethod()
        {
            Weapon weapon = new Weapon("...", 5.5, 7);
            weapon.IncreaseDestructionLevel();
            Assert.That(weapon.DestructionLevel == 8);
        }
        [Test]
        public void TestISNuclierTrue()
        {
            Weapon weapon = new Weapon("...", 5.5, 12);

            Assert.That(weapon.IsNuclear == true);
        }
        [Test]
        public void TestISNuclierFalse()
        {
            Weapon weapon = new Weapon("...", 5.5, 10);

            Assert.That(weapon.IsNuclear == false);
        }

    }
}

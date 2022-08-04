using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    
    public class AxeTests
    {
        [Test]
        public void LosesDurability_AfterAttack()
        {
            //Arrange
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(100, 5);
            //Act
            axe.Attack(dummy);
            //Arrange
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability does not change!");
        }
        [Test]
        public void AttackWithABrokenWeapon()
        {
            //Arrange
            Axe axe = new Axe(5, -2);
            Dummy dummy = new Dummy(100, 5);

            Assert.Throws<InvalidOperationException> (() =>
            {   
                //Act
                axe.Attack(dummy);
            }, 
            //Assert
            "Axe is broken.");
        }

    }
}
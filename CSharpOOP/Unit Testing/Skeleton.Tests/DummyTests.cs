using NUnit.Framework;
using System;

namespace Skeleton.Tests
{ 
    public class DummyTests
    {
        [Test]
        public void LossesHealth()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(6);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(4));

        }

        [Test]

        public void IfAttactWhenDead_ThrowsAnExeption()
        {
            //Arrange
            Dummy dummy = new Dummy(-4, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {   
                //Act
                dummy.TakeAttack(2);
            },
            //Assert
            "Dummy is dead.");

        }

        [Test]

        public void IfDead_GivesEXP()
        {
            //Arrange
            Dummy dummy = new Dummy(-4, 10);

            //Act
            int exp = dummy.GiveExperience();
            
            //Assert
            Assert.That(exp,Is.EqualTo(10));

        }

        [Test]

        public void IfAliveDoesNotGiveExp()
        {
            //Arrange
            Dummy dummy = new Dummy(5, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {  
                //Act
                dummy.GiveExperience();
            },
            //Assert
            "Target is not dead.");

        }

    }
}
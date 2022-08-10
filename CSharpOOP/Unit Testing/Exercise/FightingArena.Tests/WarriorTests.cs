namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("Vladi", 50, 100)]
        [TestCase("Acheto", 1, 0)]
        public void TestConstructor(string name, int damage, int hp)
        {
            //Arrange && Act
            Warrior warrior = new Warrior(name, damage, hp);
            //Assert
            Assert.That(name, Is.EqualTo(warrior.Name));
            Assert.That(damage, Is.EqualTo(warrior.Damage));
            Assert.That(hp, Is.EqualTo(warrior.HP));
        }

        [TestCase("Vladi")]
        [TestCase("Acheto")]
        public void TestNamePropertyWitValidArguments(string name)
        {
            Warrior warrior = new Warrior(name, 101, 75);
            Assert.That(name, Is.EqualTo(warrior.Name));
        }

        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("")]
        public void TestNamePropertyWithInvalidArguments(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                Warrior warrior = new Warrior(name, 100, 70);
            },
            //assert
            "Name should not be empty or whitespace!");
        }

        [TestCase(1)]
        [TestCase(100)]
        public void TestDamagePropertyWitValidArguments(int damage)
        {
            Warrior warrior = new Warrior("Vladko", damage, 75);
            Assert.That(damage, Is.EqualTo(warrior.Damage));
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-23)]
        public void TestDamagePropertyWithInvalidArguments(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                Warrior warrior = new Warrior("Vladi", damage, 70);
            },
            //assert
            "Damage value should be positive!");
        }
        [TestCase(0)]
        [TestCase(100)]
        public void TestHpPropertyWitValidArguments(int hp)
        {
            Warrior warrior = new Warrior("Vladko", 101, hp);
            Assert.That(hp, Is.EqualTo(warrior.HP));
        }

        [TestCase(-1)]
        [TestCase(-23)]
        public void TestHpPropertyWithInvalidArguments(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                Warrior warrior = new Warrior("Vladi", 100, hp);
            },
            //assert
            "HP should not be negative!");
        }
        [TestCase(29)]
        [TestCase(30)]
        [TestCase(0)]
        public void TestAttackMetodWithLowerThen30HPAttacker(int currentHp)
        {
            //arrange
            Warrior currentWarrior = new Warrior("Vlachko", 100, currentHp);
            Warrior warrior = new Warrior("Acheto", 100, 70);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //act
                currentWarrior.Attack(warrior);
            },
            //Assert
            "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(29)]
        [TestCase(25)]
        [TestCase(30)]
        public void TestAttackMetodWithLowerThen30HPDeffender(int attackingHp)
        {
            //arrange
            Warrior currentWarrior = new Warrior("Vlachko", 100, 100);
            Warrior warrior = new Warrior("Acheto", 100, attackingHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //act
                currentWarrior.Attack(warrior);
            },
            //Assert
            $"Enemy HP must be greater than 30 in order to attack him!");
        }
        [TestCase(51)]
        [TestCase(60)]
        [TestCase(100)]
        public void TestAttackMetodWithLowerHpThenEnemyAttack(int damage)
        {
            //arrange
            Warrior currentWarrior = new Warrior("Vlachko", 100, 50);
            Warrior warrior = new Warrior("Acheto", damage, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //act
                currentWarrior.Attack(warrior);
            },
            //Assert
           $"You are trying to attack too strong enemy");
        }
        [TestCase(49,100)]
        [TestCase(5,125)]
        public void TestAttackMetod_ValidArguments_DefenceWithHigherHPDefender(int damage,int defenderHp)
        {
            //arrange
            Warrior currentWarrior = new Warrior("Vlachko", 100, 50);
            Warrior warrior = new Warrior("Acheto", damage, defenderHp);
            //Act
            currentWarrior.Attack(warrior);
            //Assert
            Assert.That(defenderHp-100, Is.EqualTo(warrior.HP));
        }

        [TestCase(34)]
        [TestCase(50)]
        [TestCase(99)]
        public void TestAttackMethod_ValidArgument_DefenceWithLowerHPDefender(int defenderHp)
        {
            //arrange
            Warrior currentWarrior = new Warrior("Vlachko", 100, 200);
            Warrior warrior = new Warrior("Acheto", 80, defenderHp);
            int hpCurrentWarrior = currentWarrior.HP;
            //Act
            currentWarrior.Attack(warrior);
            //Assert
            Assert.That(warrior.HP, Is.EqualTo(0));
            
        }
        [TestCase(49, 120)]
        [TestCase(30, 100)]
        [TestCase(5, 101)]
        public void TestAttackMethod_ValidArgument_AttackerOnly(int damage, int defenderHp)
        {
            //arrange
            Warrior currentWarrior = new Warrior("Vlachko", damage, defenderHp);
            Warrior warrior = new Warrior("Acheto", 100, 70);
            //Act
            currentWarrior.Attack(warrior);
            //Assert
            Assert.That(currentWarrior.HP,Is.EqualTo(defenderHp-100));

        }


    }
}
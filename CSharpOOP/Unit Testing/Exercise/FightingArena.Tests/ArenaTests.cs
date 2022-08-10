namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void TestConstructor()
        {
            //Arrange&&Act
            Arena arena = new Arena();
            //Assert
            Assert.That(arena, Is.Not.Null);
            Assert.That(arena.Warriors, Is.Empty);
        }
        [Test]
        public void TestCountGetter()
        {
            //Arrange&&Act
            Arena arena = new Arena();
            //Assert
            Assert.That(arena.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestEnrollWithValidArguments()
        {
            //Arrange
            Arena arena = new Arena();
            //Act
            Warrior warrior = new Warrior("Vladko", 100, 200);
            arena.Enroll(warrior);
            //Assert
            Assert.That(arena.Warriors.Count, Is.EqualTo(1));
        }
        [TestCase("Vladko", 10, 2040)]
        [TestCase("Vladko", 100, 200)]
        [TestCase("Vladko", 556, 10000)]
        public void TestEnrollWithTheSameName(string name,int damage,int hp)
        {
            //Arrange
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Vladko", 100, 200);
            Warrior warriorWithTheSameName = new Warrior(name, damage, hp);
            arena.Enroll(warrior);
            //Act&&Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warriorWithTheSameName);
            },
            "Warrior is already enrolled for the fights!");
        }
        [TestCase("Acheto",758,8769)]
        [TestCase("Bacheto",75,9)]
        public void TestFightMethodWithNonExistingtAttacker(string name, int damage, int hp)
        {
            //Arrange
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Vladko", 100, 200);
            Warrior defender = new Warrior(name, damage, hp);
            arena.Enroll(defender);
            //Act&&Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Vladko", name);
            },
            $"There is no fighter with name Vladko enrolled for the fights!");
        }
        [TestCase("Acheto", 758, 8769)]
        [TestCase("Bacheto", 75, 9)]
        [TestCase("j", 75, 9)]
        public void TestFightMethodWithNonExistingtDeffender(string name, int damage, int hp)
        {
            //Arrange
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Vladko", 100, 200);
            Warrior defender = new Warrior(name, damage, hp);
            arena.Enroll(attacker);
            //Act&&Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Vladko", name);
            },
            $"There is no fighter with name {name} enrolled for the fights!");
        }
        public void TestFightMethodWithValidArguments()
        {
            //Arrange
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Vladko", 100, 200);
            Warrior defender = new Warrior("Acheto", 40, 150);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);
            Assert.That(attacker.HP, Is.EqualTo(160));
            Assert.That(defender.HP, Is.EqualTo(50));
        }
        [Test]
        public void TestFightMethodIfWorkingSuccessfully()
        {
            //Arrange
            Warrior warrior1 = new Warrior("Gosho", 60, 100);
            Warrior warrior2 = new Warrior("Pesho", 50, 200);
            Arena arena = new Arena();

            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Fight("Gosho", "Pesho");

            //Assert
            Assert.That(warrior2.HP, Is.EqualTo(140));
        }

        [Test]
        public void TestFightMethodWithInvalidAttackerNamer_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior warrior1 = new Warrior("Gosho", 20, 100);
                Arena arena = new Arena();

                //Act
                arena.Enroll(warrior1);
                arena.Fight("Peter", "Gosho");
            },
            $"There is no fighter with name Peter enrolled for the fights!");
        }

        [Test]
        public void TestFightMethodWithInvalidDefenderNamer_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Warrior warrior1 = new Warrior("Gosho", 20, 100);
                Arena arena = new Arena();

                //Act
                arena.Enroll(warrior1);
                arena.Fight("Gosho", "Spas");
            },
            $"There is no fighter with name Spas enrolled for the fights!");
        }

        [Test]
        public void TestFightMethodWithInvalidNames_ThrowingException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange
                Arena arena = new Arena();

                //Act
                arena.Fight("Daniel", "Mihail");
            },
            $"There is no fighter with name Mihail enrolled for the fights!");
        }

    }
}

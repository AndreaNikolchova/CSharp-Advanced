namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
      
        [Test]
        public void TestConstructorWithVslidArguments()
        {
            //arrange and act
            Database database = new Database(
                new Person(040595, "Vladi"),
                new Person(023949, "Acheto"),
                new Person(20394, "Him"));
            //Assert
            Assert.That(database.Count, Is.EqualTo(3));
        }
        [Test]
        public void TestConstructorWith0()
        {
            //arrange and act
            Database database = new Database();
            //Assert
            Assert.That(database.Count, Is.EqualTo(0));
        }
        [Test]
        public void TestConstructorWith16Elements()
        {
            //arrange and act
            Database database = new Database(
                new Person(040595, "Vladi"),
                      new Person(1, "Acheto"),
                      new Person(2, "a"),
                      new Person(3, "b"),
                      new Person(4, "c"),
                      new Person(5, "d"),
                      new Person(6, "e"),
                      new Person(7, "f"),
                      new Person(8, "g"),
                      new Person(9, "h"),
                      new Person(10, "i"),
                      new Person(11, "j"),
                      new Person(12, "k"),
                      new Person(13, "l"),
                      new Person(14, "m"),
                      new Person(15, "n"));
            //Assert
            Assert.That(database.Count, Is.EqualTo(16));
        }
        [Test]
        public void TestExeedingCapasityConstructor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(
                      new Person(040595, "Vladi"),
                      new Person(1, "Acheto"),
                      new Person(2, "a"),
                      new Person(3, "b"),
                      new Person(4, "c"),
                      new Person(5, "d"),
                      new Person(6, "e"),
                      new Person(7, "f"),
                      new Person(8, "g"),
                      new Person(9, "h"),
                      new Person(10, "i"),
                      new Person(11, "j"),
                      new Person(12, "k"),
                      new Person(13, "l"),
                      new Person(14, "m"),
                      new Person(15, "n"),
                      new Person(16, "o"));
            }, "Provided data length should be in range [0..16]!");   
        }
        [Test]
        public void TestAddMethodExeedingCapasity()
        {
            Database database = new Database(
               new Person(040595, "Vladi"),
                     new Person(1, "Acheto"),
                     new Person(2, "a"),
                     new Person(3, "b"),
                     new Person(4, "c"),
                     new Person(5, "d"),
                     new Person(6, "e"),
                     new Person(7, "f"),
                     new Person(8, "g"),
                     new Person(9, "h"),
                     new Person(10, "i"),
                     new Person(11, "j"),
                     new Person(12, "k"),
                     new Person(13, "l"),
                     new Person(14, "m"),
                     new Person(15, "n"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "o"));
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void TestAddMethodUserWithTheSameName()
        {
            Database database = new Database(
              new Person(040595, "Vladi"),
                    new Person(1, "Acheto"),
                    new Person(2, "a"),
                    new Person(3, "b"),
                    new Person(4, "c"),
                    new Person(5, "d"),
                    new Person(6, "e"),
                    new Person(7, "f"),
                    new Person(8, "g"),
                    new Person(9, "h"),
                    new Person(10, "i"),
                    new Person(11, "j"),
                    new Person(12, "k"),
                    new Person(13, "l"),
                    new Person(15, "n"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(16, "n"));
            }, "There is already user with this username!");
        }
        [Test]
        public void TestAddMethodWithTheSameID()
        {
            Database database = new Database(
              new Person(040595, "Vladi"),
                    new Person(1, "Acheto"),
                    new Person(2, "a"),
                    new Person(3, "b"),
                    new Person(4, "c"),
                    new Person(5, "d"),
                    new Person(6, "e"),
                    new Person(7, "f"),
                    new Person(8, "g"),
                    new Person(9, "h"),
                    new Person(10, "i"),
                    new Person(11, "j"),
                    new Person(12, "k"),
                    new Person(14, "m"),
                    new Person(15, "n"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(15, "p"));
            }, "There is already user with this Id!");
        }
        [Test]
        public void TestAddMethodSucsessfullyWith15Elements()
        {
            Database database = new Database(
             new Person(040595, "Vladi"),
                   new Person(1, "Acheto"),
                   new Person(2, "a"),
                   new Person(3, "b"),
                   new Person(4, "c"),
                   new Person(5, "d"),
                   new Person(6, "e"),
                   new Person(7, "f"),
                   new Person(8, "g"),
                   new Person(9, "h"),
                   new Person(10, "i"),
                   new Person(11, "j"),
                   new Person(12, "k"),
                   new Person(14, "m"),
                   new Person(15, "n"));
            database.Add(new Person(16, "p"));
            Assert.That(database.Count, Is.EqualTo(16));
        }
        [Test]
        public void TestAddMethodSucsessfullyWith0Elemets()
        {
            Database database = new Database();
            database.Add(new Person(16, "p"));
            Assert.That(database.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestRemoveWithZeroElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database();
                database.Remove();
            });
        }
        [Test]
        public void TestRemoveWithValidElements()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(14));
        }
        [Test]
        public void TestFindByUsernameMethodWithEmptyString()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername("");
            }, "Username parameter is null!");
        }
        [Test]
        public void TestFindByUsernameMethodWithNullString()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            }, "Username parameter is null!");
        }
        [Test]
        public void TestFindByUsernameWithNonPresentName()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Nqkoi");
            }, "No user is present by this username!");
        }
        [Test]
        public void TestFindByUsernameWithValidArguments()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            Person person = database.FindByUsername("Vladi");
            Assert.That(person, Is.Not.Null);
            Assert.That(person.UserName, Is.EqualTo("Vladi"));
            Assert.That(person.Id, Is.EqualTo(040595));
        }
        [Test]
        public void TestFindByIdMethodWithNegativeNumber()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-12345);
            }, "Id should be a positive number!");
        }
        [Test]
        public void TestFindByIdMethodWithNonExistingNumber()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(0);
            }, "No user is present by this ID!");
        }
        [Test]
        public void TestFindByIdWithValidArguments()
        {
            Database database = new Database(
            new Person(040595, "Vladi"),
                  new Person(1, "Acheto"),
                  new Person(2, "a"),
                  new Person(3, "b"),
                  new Person(4, "c"),
                  new Person(5, "d"),
                  new Person(6, "e"),
                  new Person(7, "f"),
                  new Person(8, "g"),
                  new Person(9, "h"),
                  new Person(10, "i"),
                  new Person(11, "j"),
                  new Person(12, "k"),
                  new Person(14, "m"),
                  new Person(15, "n"));
            Person person = database.FindById(040595);
            Assert.That(person, Is.Not.Null);
            Assert.That(person.UserName, Is.EqualTo("Vladi"));
            Assert.That(person.Id, Is.EqualTo(040595));
        }


    }
}
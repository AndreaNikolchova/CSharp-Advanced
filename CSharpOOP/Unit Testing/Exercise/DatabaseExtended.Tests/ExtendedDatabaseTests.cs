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
        public void TestConstructorSuccessfull()
        {
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            //Act
            Database database = new Database(people);
            //Assert
            Assert.That(database.Count, Is.EqualTo(1));

        }

        [Test]
        public void TestIfConstructor_ThrowsExcessingCapacityExeption()
        {
            //Arrange
            Person[] people = new Person[17];
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                Database database = new Database(people);
            },
            //Assert
            "Provided data length should be in range [0..16]!");

        }

        [Test]
        public void TestCountGetter(Person[] people)
        {
            //Arrange
            Database database = new Database(people);
            //Act && Assert
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestAddMethodSuccessfull()
        {
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            //Act
            database.Add(new Person(65980009944, "pesho"));
            //Assert
            Assert.That(people.Length, Is.EqualTo(database.Count - 1));

        }

        [Test]
        public void TestAddMethodAddingTheSameID()
        {
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                database.Add(new Person(129130248, "pesho"));
            },
            //Assert
            "There is already user with this Id!");

        }
        [Test]
        public void TestAddMethodAddingTheSameName()
        {
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                database.Add(new Person(9120934903, "Vladi"));
            },
            //Assert
            "There is already user with this username!");

        }

        [Test]
        public void TestIfAddMethod_ThrowsExcessingCapacityExeption()
        {
            //Arrange
            Person[] people = new Person[]
            {
                new Person(00938499348, "dfg"),
                new Person(00938809348, "Vht"),
                new Person(00968409348, "Vladi"),
                new Person(04938409348, "Vgfh"),
                new Person(00934409348, "Vlfg"),
                new Person(00998409348, "Vsdft"),
                new Person(01238409348, "Vl12"),
                new Person(0093345409348, "gres"),
                new Person(0093409348, "bngr"),
                new Person(00938234348, "ertg"),
                new Person(00938445648, "wrt"),
                new Person(009384050648, "ghtr"),
                new Person(0012348409348, "ntfg"),
                new Person(1234538409348, "Vlsdgdg"),
                new Person(056738409348, "bftgr"),
                new Person(009383459348, "dfvdfi"),

            };
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                database.Add(new Person(00938409348, "Vladi"));
            },
            //Assert
            "Array's capacity must be exactly 16 integers!");

        }

        [Test]
        public void TestIfRemoveMetod_ThrowsExeption()
        {
            //Arrange 
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                database.Remove();
            });
        }

        [Test]
        public void TestRemoveMetodIfSuccessesfull()
        {
            //Arrange 
            Person[] people = new Person[] { new Person(129130248, "Vladi"), new Person(2390809238,"Pesho") };
            Database database = new Database(people);
            //Act
            int countBefore = database.Count;
            database.Remove();
            //Assert
            Assert.That(database.Count, Is.EqualTo(countBefore - 1));
            
        }

        [Test]
        public void TestFindByUsernameSuccessesfull()
        {
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            //Act
            Person wantedPerson = database.FindByUsername("Vladi");
            //Assert
            Assert.That(wantedPerson, Is.EqualTo(people[0]));
        }

        [Test]
        public void TestFindByUsernameWithNonExistendName()
        {
           
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                Person wantedPerson = database.FindByUsername("Pesho");

            },
            //Assert
            "No user is present by this username!");  
        }

        [Test]
        public void TestFindByUsernameWithNullString()
        {
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                Person wantedPerson = database.FindByUsername(null);

            },
            //Assert
            "Username parameter is null!");
        }

        [Test]
        public void TestFindByIdSuccessesfull()
        {
            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            //Act
            Person wantedPerson = database.FindById(129130248);
            //Assert
            Assert.That(wantedPerson, Is.EqualTo(people[0]));
        }
   
        [Test]
        public void TestFindByIDWithNonExistendID()
        {

            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                Person wantedPerson = database.FindById(3674395);

            },
            //Assert
            "No user is present by this ID!");
        }
        [Test]
        public void TestFindByIDWithNegativeID()
        {

            //Arrange
            Person[] people = new Person[] { new Person(129130248, "Vladi") };
            Database database = new Database(people);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                //Act
                Person wantedPerson = database.FindById(-12);

            },
            //Assert
           "Id should be a positive number!");
        }

    }
}
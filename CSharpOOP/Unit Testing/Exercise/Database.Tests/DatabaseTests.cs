namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestConstructorSuccessfully()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 3 };
            Type databaseType = typeof(Database);
            var instance = Activator.CreateInstance(databaseType, new object[] { 1, 2, 3 });

            var field = instance.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(x => x.Name == "data");
            int[] valueOfField = (int[])field.GetValue(instance);

            //Act
            Database database = new Database(array);
            //Assert
            Assert.That(valueOfField.Length, Is.EqualTo(16));

        }

        [Test]
        public void TestIfConstructor_ThrowsAnExeption()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                Database database = new Database(array);
            },
            //Assert
            "Array's capacity must be exactly 16 integers!");

        }

        [Test]
        public void TestIfAddMetod_IsSuccessefull()
        { 
            //Arrange 
            int[] array = new int[] { 1, 2, 34, 4 };
            Database database = new Database(array);
            //Act
            int countBefore = database.Count;
            database.Add(56);
            //Assert
            Assert.That(database.Count, Is.EqualTo(countBefore + 1));
        }

        [Test]
        public void TestIfAddMetod_ThrowsAnExeption()
        {
            //Arrange
            int[] array = new int[16];
            Database database = new Database(array);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                database.Add(5);
            },
            //Assert
            "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void TestCountGetter()
        {
            //Arrange
            Database database = new Database(new int[5]);
            //Act && Assert
            Assert.That(database.Count, Is.EqualTo(5));
        }

        [Test]
        public void TestRemoveMetodIfSuccessesfull()
        {
            //Arrange 
            int[] array = new int[] { 1, 2, 34, 4 };
            Database database = new Database(array);
            //Act
            int countBefore = database.Count;
            database.Remove();
            //Assert
            Assert.That(database.Count, Is.EqualTo(countBefore - 1));
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
            },
            //Assert
            "The collection is empty!");
        }
  
        [Test]
        public void TestFetchMetod()
        {
            //Arrange
            int[] array = new int[3] { 1, 2, 3 };
            Database database = new Database(array);

            //Act
            int[] copyOfArray = database.Fetch();

            //Assert
            Assert.That(array, Is.EqualTo(copyOfArray));

        }

    }
}

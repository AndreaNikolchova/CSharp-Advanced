namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            Book book = new Book("Book","Author");
            Assert.IsNotNull(book);
            Assert.AreEqual(book.BookName, "Book");
            Assert.AreEqual(book.Author, "Author");
            Assert.AreEqual(book.FootnoteCount, 0);
        }
        [TestCase(null)]
        [TestCase("")]
        public void TestBookNameInvalidArgument(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Author");
            });
        }
        [TestCase(null)]
        [TestCase("")]
        public void TestAuthorInvalidArgument(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Book", authorName);
            });
        }
        [Test]
        public void TestAddFootnoteWithExistingFootnote()
        {
            Book book = new Book("Book", "Author");
            book.AddFootnote(10, "Footnote");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(10, "Footnote");
            });
        }
        [Test]
        public void TestAddFootnote()
        {
            Book book = new Book("Book", "Author");
            book.AddFootnote(10, "Footnote");
            Assert.AreEqual(book.FootnoteCount, 1);
        }
        [Test]
        public void TestFindFootnoteWithNonExisting()
        {
            Book book = new Book("Book", "Author");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(10);
            });
        }
        [Test]
        public void TestFindFootnote()
        {
            Book book = new Book("Book", "Author");
            book.AddFootnote(10, "some text");
            string result = book.FindFootnote(10);
            Assert.AreEqual(result, $"Footnote #10: some text");
        }
        [Test]
        public void TestAlterFootnoteWithNonExistingNote()
        {
            Book book = new Book("Book", "Author");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(10,"new text");
            });
        }
        [Test]
        public void TestAlterFootnote()
        {
            Book book = new Book("Book", "Author");
            book.AddFootnote(10, "some text");
            book.AlterFootnote(10, "new text");
            string result = book.FindFootnote(10);
            Assert.AreEqual(result, $"Footnote #10: new text");

        }

    }
}
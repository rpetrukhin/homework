using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_10;

namespace Task_10_Tests
{
    [TestFixture]
    public class BinarySearchTreeTest_String
    {
        [Test]
        public void Insert_Test_String()
        {
            var binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert("d");
            binarySearchTree.Insert("a");
            binarySearchTree.Insert("g");
            binarySearchTree.Insert("b");

            Assert.That(binarySearchTree.Root.Key, Is.EqualTo("d"));
            Assert.That(binarySearchTree.Root.Left.Key, Is.EqualTo("a"));
            Assert.That(binarySearchTree.Root.Right.Key, Is.EqualTo("g"));
            Assert.That(binarySearchTree.Root.Left.Right.Key, Is.EqualTo("b"));
        }

        [Test]
        public void Delete_Test_String()
        {
            var binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert("d");
            binarySearchTree.Insert("a");
            binarySearchTree.Insert("g");
            binarySearchTree.Insert("b");

            binarySearchTree.Delete("d");

            Assert.That(binarySearchTree.Root.Key, Is.EqualTo("g"));
        }

        [Test]
        public void Search_Test_String()
        {
            var binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert("d");
            binarySearchTree.Insert("a");
            binarySearchTree.Insert("g");
            binarySearchTree.Insert("b");

            var leaf = binarySearchTree.Search("a");

            Assert.That(leaf, Is.EqualTo(binarySearchTree.Root.Left));
        }


        [Test]
        public void InOrderTraversal_Test_String()
        {
            var binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert("d");
            binarySearchTree.Insert("a");
            binarySearchTree.Insert("g");
            binarySearchTree.Insert("b");

            var sExpected = new string[] { "a", "b", "d", "g" };

            var s = new string[4];

            int i = 0;
            foreach (string key in binarySearchTree.InOrderTraversal())
            {
                s[i] = key;
                i++;
            }

            Assert.That(s, Is.EqualTo(sExpected));
        }

        [Test]
        public void PreOrderTraversal_Test_String()
        {
            var binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert("d");
            binarySearchTree.Insert("a");
            binarySearchTree.Insert("g");
            binarySearchTree.Insert("b");

            var sExpected = new string[] { "d", "a", "b", "g" };

            var s = new string[4];

            int i = 0;
            foreach (string key in binarySearchTree.PreOrderTraversal())
            {
                s[i] = key;
                i++;
            }

            Assert.That(s, Is.EqualTo(sExpected));
        }

        [Test]
        public void PostOrderTraversal_Test_String()
        {
            var binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert("d");
            binarySearchTree.Insert("a");
            binarySearchTree.Insert("g");
            binarySearchTree.Insert("b");

            var sExpected = new string[] { "b", "a", "g", "d" };

            var s = new string[4];

            int i = 0;
            foreach (string key in binarySearchTree.PostOrderTraversal())
            {
                s[i] = key;
                i++;
            }

            Assert.That(s, Is.EqualTo(sExpected));
        }
    }

    [TestFixture]
    public class BinarySearchTreeTest_Point
    {
        [Test]
        public void Insert_Test_Point()
        {
            var binarySearchTree = new BinarySearchTree<Point>();
            var x = new Point(3, 4);
            var y = new Point(1, 2);
            var z = new Point(5, 6);
            binarySearchTree.Insert(x);
            binarySearchTree.Insert(y);
            binarySearchTree.Insert(z);

            Assert.That(binarySearchTree.Root.Key, Is.EqualTo(x));
            Assert.That(binarySearchTree.Root.Left.Key, Is.EqualTo(y));
            Assert.That(binarySearchTree.Root.Right.Key, Is.EqualTo(z));
        }

        [Test]
        public void Delete_Test_Point()
        {
            var binarySearchTree = new BinarySearchTree<Point>();
            var x = new Point(3, 4);
            var y = new Point(1, 2);
            var z = new Point(5, 6);
            binarySearchTree.Insert(x);
            binarySearchTree.Insert(y);
            binarySearchTree.Insert(z);

            binarySearchTree.Delete(x);

            Assert.That(binarySearchTree.Root.Key, Is.EqualTo(z));
        }

        [Test]
        public void Search_Test_Point()
        {
            var binarySearchTree = new BinarySearchTree<Point>();
            var x = new Point(3, 4);
            var y = new Point(1, 2);
            var z = new Point(5, 6);
            binarySearchTree.Insert(x);
            binarySearchTree.Insert(y);
            binarySearchTree.Insert(z);

            var leaf = binarySearchTree.Search(y);

            Assert.That(leaf, Is.EqualTo(binarySearchTree.Root.Left));
        }

        [Test]
        public void InOrderTraversal_Test_Point()
        {
            var binarySearchTree = new BinarySearchTree<Point>();
            var x = new Point(3, 4);
            var y = new Point(1, 2);
            var z = new Point(5, 6);
            binarySearchTree.Insert(x);
            binarySearchTree.Insert(y);
            binarySearchTree.Insert(z);

            var pExpected = new Point[] { y, x, z };

            var p = new Point[3];

            var i = 0;
            foreach (Point key in binarySearchTree.InOrderTraversal())
            {
                p[i] = key;
                i++;
            }

            Assert.That(p, Is.EqualTo(pExpected));
        }

        [Test]
        public void PreOrderTraversal_Test_Point()
        {
            var binarySearchTree = new BinarySearchTree<Point>();
            var x = new Point(3, 4);
            var y = new Point(1, 2);
            var z = new Point(5, 6);
            binarySearchTree.Insert(x);
            binarySearchTree.Insert(y);
            binarySearchTree.Insert(z);

            var pExpected = new Point[] { x, y, z };

            var p = new Point[3];

            var i = 0;
            foreach (Point key in binarySearchTree.PreOrderTraversal())
            {
                p[i] = key;
                i++;
            }

            Assert.That(p, Is.EqualTo(pExpected));
        }

        [Test]
        public void PostOrderTraversal_Test_Point()
        {
            var binarySearchTree = new BinarySearchTree<Point>();
            var x = new Point(3, 4);
            var y = new Point(1, 2);
            var z = new Point(5, 6);
            binarySearchTree.Insert(x);
            binarySearchTree.Insert(y);
            binarySearchTree.Insert(z);

            var pExpected = new Point[] { y, z, x };

            var p = new Point[3];

            var i = 0;
            foreach (Point key in binarySearchTree.PostOrderTraversal())
            {
                p[i] = key;
                i++;
            }

            Assert.That(p, Is.EqualTo(pExpected));
        }
    }

    [TestFixture]
    public class BinarySearchTreeTest_Book
    {
        [Test]
        public void Insert_Test_Book()
        {
            var binarySearchTree = new BinarySearchTree<Book>();
            var book1 = new Book("Razor Blade", "Efremov");
            var book2 = new Book("Three Comrades", "Remarque");
            var book3 = new Book("Harry Potter and Philosopher's Stone", "Rowling");

            binarySearchTree.Insert(book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);

            Assert.That(binarySearchTree.Root.Key, Is.EqualTo(book1));
            Assert.That(binarySearchTree.Root.Left.Key, Is.EqualTo(book3));
            Assert.That(binarySearchTree.Root.Right.Key, Is.EqualTo(book2));
        }

        [Test]
        public void Delete_Test_Book()
        {
            var binarySearchTree = new BinarySearchTree<Book>();
            var book1 = new Book("Razor Blade", "Efremov");
            var book2 = new Book("Three Comrades", "Remarque");
            var book3 = new Book("Harry Potter and Philosopher's Stone", "Rowling");

            binarySearchTree.Insert(book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);

            binarySearchTree.Delete(book1);

            Assert.That(binarySearchTree.Root.Key, Is.EqualTo(book2));
        }

        [Test]
        public void Search_Test_Book()
        {
            var binarySearchTree = new BinarySearchTree<Book>();
            var book1 = new Book("Razor Blade", "Efremov");
            var book2 = new Book("Three Comrades", "Remarque");
            var book3 = new Book("Harry Potter and Philosopher's Stone", "Rowling");

            binarySearchTree.Insert(book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);

            var leaf = binarySearchTree.Search(book3);

            Assert.That(leaf, Is.EqualTo(binarySearchTree.Root.Left));
        }


        [Test]
        public void InOrderTraversal_Test_Book()
        {
            var binarySearchTree = new BinarySearchTree<Book>();
            var book1 = new Book("Razor Blade", "Efremov");
            var book2 = new Book("Three Comrades", "Remarque");
            var book3 = new Book("Harry Potter and Philosopher's Stone", "Rowling");

            binarySearchTree.Insert(book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);

            var bExpected = new Book[] { book3, book1, book2 };

            var b = new Book[3];

            int i = 0;
            foreach (Book key in binarySearchTree.InOrderTraversal())
            {
                b[i] = key;
                i++;
            }

            Assert.That(b, Is.EqualTo(bExpected));
        }

        [Test]
        public void PreOrderTraversal_Test_Book()
        {
            var binarySearchTree = new BinarySearchTree<Book>();
            var book1 = new Book("Razor Blade", "Efremov");
            var book2 = new Book("Three Comrades", "Remarque");
            var book3 = new Book("Harry Potter and Philosopher's Stone", "Rowling");

            binarySearchTree.Insert(book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);

            var bExpected = new Book[] { book1, book3, book2 };

            var b = new Book[3];

            int i = 0;
            foreach (Book key in binarySearchTree.PreOrderTraversal())
            {
                b[i] = key;
                i++;
            }

            Assert.That(b, Is.EqualTo(bExpected));
        }

        [Test]
        public void PostOrderTraversal_Test_Book()
        {
            var binarySearchTree = new BinarySearchTree<Book>();
            var book1 = new Book("Razor Blade", "Efremov");
            var book2 = new Book("Three Comrades", "Remarque");
            var book3 = new Book("Harry Potter and Philosopher's Stone", "Rowling");

            binarySearchTree.Insert(book1);
            binarySearchTree.Insert(book2);
            binarySearchTree.Insert(book3);

            var bExpected = new Book[] { book3, book2, book1 };

            var b = new Book[3];

            int i = 0;
            foreach (Book key in binarySearchTree.PostOrderTraversal())
            {
                b[i] = key;
                i++;
            }

            Assert.That(b, Is.EqualTo(bExpected));
        }
    }
}
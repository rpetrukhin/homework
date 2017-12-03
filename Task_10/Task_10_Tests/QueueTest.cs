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
    public class QueueTest
    {
        [Test]
        public void Dequeue_Test()
        {
            var queue = new Task_10.Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.That(queue.Dequeue(), Is.EqualTo(10));
            Assert.That(queue.Dequeue(), Is.EqualTo(20));
        }

        [Test]
        public void GetEnumerator_Test()
        {
            var queue = new Task_10.Queue<int>();

            int[] arrayExpected = new int[10] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            int[] array = new int[10];

            for (int i = 0; i < 10; i++)
                queue.Enqueue(i * 10);

            int j = 0;
            foreach(var elem in queue)
            {
                array[j] = elem.Value;
                j++;
            }

            Assert.That(array, Is.EqualTo(arrayExpected));
        }
    }
}
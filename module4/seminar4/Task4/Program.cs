using System;
using System.Collections;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new RandomCollection(10);
            foreach (var r in rnd) Console.WriteLine(r);
        }
    }

    class RandomCollection : IEnumerable<int>, IEnumerator<int>
    {
        public Random random = new Random();
        private int count = 0;
        private int index = 0;

        public RandomCollection()
        {
            count = random.Next(10, 20);
        }

        public RandomCollection(int count)
        {
            this.count = count;
        }

        public int Current
        {
            get
            {
                index++;
                return random.Next();
            }
        }

        object IEnumerator.Current {
            get {
                index++;
                return random.Next();
            }
        }

        public void Dispose()
        {
        }

        public IEnumerator GetEnumerator() => GetEnumerator();

        public bool MoveNext() => count > index;

        public void Reset() => index = 0;

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return random.Next();
            yield break;
        }
    }
}

//    Есть класс RandomCollection, реализующий свою коллекцию из n
//    случайных целых чисел (числа будут разные при каждом обходе).
//    Класс RandomCollection реализует интерфейс IEnumerable. Нам надо
//    предоставить возможность обходить элементы коллекции через foreach.
//    Для того, чтобы это было возможно, необходимо определить закрытый класс RandomEnumerator,
//    реализующий доступ к отдельным элементам коллекции (реализует интерфейс IEnumerator).

//Создать программу, демонстрирующую работу.

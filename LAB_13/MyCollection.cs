using ClassLibrary1;
using LAB_12_2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12_4
{
    public class MyCollection<T> : MyHashTable<T>, ICollection<T>, IEnumerable<T> where T : IInit, ICloneable, new()
    {
        public Random rnd = new Random();
        public MyCollection() : base() { }
        public MyCollection(int size)
        {
            if (size < 0)
            {
                throw new Exception("В хэш-таблице не может быть отрицательное количество элементов");
            }
            else
            {
                tableValue = new T[size];
                tableNextFactor = new bool[size];
                fillRatio = 0.72;
                while (Count != size)
                {
                    T el = new T();
                    el.RandomInit();
                    AddItem(el);
                }
            }
        }
        public MyCollection(MyCollection<T> collection)
        {
            int size = collection.Capacity;
            tableValue = new T[size];
            tableNextFactor = new bool[size];
            fillRatio = 0.72;
            for (int i = 0; i < size; i++)
            {
                if (collection.tableValue[i] != null)
                {
                    AddItem(collection.tableValue[i]);
                }
            }

        }

        public bool IsReadOnly => false;

        public int Length
        {
            get => Capacity;
        }

        public void Add(T item)
        {
            AddItem(item);
        }

        public void Clear()
        {
            for (int i = 0; i < Capacity; i++)
            {
                T el = tableValue[i];
                if (el is not null)
                {
                    RemoveData(el);
                }
            }
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array имеет значение null");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Значение параметра index меньше нуля");
            }
            if (array.Rank != 1)
            {
                throw new ArgumentException("Массив array является многомерным");
            }
            if ((index + Capacity) > array.Length)
            {
                throw new ArgumentException("Число элементов в хэш-таблице больше доуступного места от положения, заданного значением параметра index, до конца массива назначения array");
            }
            int end = index + Capacity;
            for (int i = 0; i < end; i++)
            {
                if (tableValue[i] is null)
                {
                    array[i] = default;
                }
                else
                {
                    array[i] = (T)tableValue[i].Clone();
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        public bool Remove(T item)
        {
            return RemoveData(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class MyEnumerator<T> : IEnumerator<T> where T : IInit, ICloneable, new()
    {
        int currentIndex;
        T[] array;

        public MyEnumerator(MyCollection<T> collection)
        {
            currentIndex = -1;
            array = collection.tableValue;
        }

        public T Current => array[currentIndex];

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (currentIndex + 1 != array.Length)
            {
                currentIndex++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
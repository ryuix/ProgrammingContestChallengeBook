using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpStl
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> buffer;

        public PriorityQueue() { this.buffer = new List<T>(); }

        static void PushHeap(List<T> array, T elem)
        {
            int n = array.Count;
            array.Add(elem);

            while (n != 0)
            {
                int i = (n - 1) / 2;
                if (array[n].CompareTo(array[i]) > 0)
                {
                    (array[n], array[i]) = (array[i], array[n]);
                }
                n = i;
            }
        }

        static void PopHeap(List<T> array)
        {
            int n = array.Count - 1;
            array[0] = array[n];
            array.RemoveAt(n);

            for (int i = 0, j; (j = 2 * i + 1) < n;)
            {
                if ((j != n - 1) && (array[j].CompareTo(array[j + 1]) < 0))
                    j++;
                if (array[i].CompareTo(array[j]) < 0)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                }
                i = j;
            }
        }

        public void Push(T elem)
        {
            PushHeap(this.buffer, elem);
        }

        public void Pop()
        {
            PopHeap(this.buffer);
        }

        public T Top
        {
            get => this.buffer[0];
        }

        public int Count
        {
            get => this.buffer.Count;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpStl
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> buffer;
        bool isDescend;

        public PriorityQueue(bool isDescend = true)
        {
            this.buffer = new List<T>();
            this.isDescend = isDescend;
        }

        static void PushHeap(List<T> array, T elem, bool isDescend)
        {
            int n = array.Count;
            array.Add(elem);
            if (isDescend)
            {
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
            else
            {
                while (n != 0)
                {
                    int i = (n - 1) / 2;
                    if (array[n].CompareTo(array[i]) < 0)
                    {
                        (array[n], array[i]) = (array[i], array[n]);
                    }
                    n = i;
                }
            }
        }

        static void PopHeap(List<T> array, bool isDescend)
        {
            int n = array.Count - 1;
            array[0] = array[n];
            array.RemoveAt(n);
            if (isDescend)
            {
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
            else
            {
                for (int i = 0, j; (j = 2 * i + 1) < n;)
                {
                    if ((j != n - 1) && (array[j].CompareTo(array[j + 1]) > 0))
                        j++;
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                    i = j;
                }
            }
        }

        public void Push(T elem)
        {
            PushHeap(this.buffer, elem, isDescend);
        }

        public void Pop()
        {
            PopHeap(this.buffer, isDescend);
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

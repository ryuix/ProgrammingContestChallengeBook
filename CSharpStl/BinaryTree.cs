using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpStl
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public class Node
        {
            internal T value;
            internal Node? left, right, parent;

            internal Node(T value, Node? parent)
            {
                this.value = value;
                this.parent = parent;
                this.left = this.right = null;
            }

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public Node? Next
            {
                get
                {
                    Node n = this;

                    if (n.right is not null)
                        return n.right.Min;

                    for (; n.parent is not null && n.parent.left != n; n = n.parent) ;
                    return n.parent;
                }
            }

            public Node? Previous
            {
                get
                {
                    Node n = this;

                    if (n.left is not null)
                        return n.left.Max;

                    for (; n.parent is not null && n.parent.right != n; n = n.parent) ;
                    return n.parent;
                }
            }

            internal Node Min
            {
                get
                {
                    Node n = this;

                    for (; n.left is not null; n = n.left) ;
                    return n;
                }
            }

            internal Node Max
            {
                get
                {
                    Node n = this;

                    for (; n.right is not null; n = n.right) ;
                    return n;
                }
            }
        }

        Node? root;

        public BinaryTree()
        {
            this.root = null;
        }

        public Node? Begin
        {
            get
            {
                if (this.root is null)
                {
                    return this.End;
                }
                return this.root.Min;
            }
        }

        public Node? End
        {
            get { return null; }
        }

        public void Add(T item)
        {
            if (this.root is null)
            {
                this.root = new Node(item, null);
            }

            Node? n = this.root;
            Node? p = null;

            while (n is not null)
            {
                p = n;
                if (n.left?.Value.CompareTo(item) > 0) n = n.left;
                else n = n.right;
            }
            n = new Node(item, p);
            if (p.Value.CompareTo(item) > 0) p.left = n;
            else p.right = n;
        }

        public void Remove(Node? n)
        {
            if (n is null) return;

            if (n.left is null) this.Replace(n, n.right);
            else if (n.right is null) this.Replace(n, n.left);
            else
            {
                Node m = n.right.Min;
                n.value = m.value;
                this.Replace(m, m.right);
            }
        }

        public void Remove(T elem)
        {
            this.Remove(this.Find(elem));
        }

        public Node? Find(T elem)
        {
            Node? n = this.root;
            while (n is not null)
            {
                if (n.Value.CompareTo(elem) > 0) n = n.left;
                else if (n.Value.CompareTo(elem) < 0) n = n.right;
                else break;
            }
            return n;
        }

        public bool Contains(T elem)
        {
            return this.Find(elem) != this.End;
        }

        void Replace(Node n, Node? m)
        {
            Node? p = n.parent;
            if (m is not null) m.parent = p;
            if (n == this.root) this.root = m;
            else if (p.left == n) p.left = m;
            else p.right = m;
        }
    }
}

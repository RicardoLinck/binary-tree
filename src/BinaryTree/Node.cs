using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Node<T> : IEnumerable<T>  where T : IComparable
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; }

        public Node(T value)
        {
            Value = value;
        }

        public void Insert(T value)
        {
            var comparison = value.CompareTo(Value);
            if (comparison == 0)
                return;

            if (comparison < 0)
            {
                if (Left != null)
                {
                    Left.Insert(value);
                }
                else
                {
                    Left = new Node<T>(value);
                }
            }
            else
            {
                if (Right != null)
                {
                    Right.Insert(value);
                }
                else
                {
                    Right = new Node<T>(value);
                }
            }
        }

        public bool Contains(T value)
        {
            var comparison = value.CompareTo(Value);
            if (comparison == 0)
                return true;

            if (comparison < 0)
            {
                if (Left == null)
                {
                    return false;
                }
                else
                {
                    return Left.Contains(value);
                }
            }
            else
            {
                if(Right == null)
                {
                    return false;
                }
                else
                {
                    return Right.Contains(value);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(Left != null)
            {
                foreach (var item in Left)
                {
                    yield return item;
                }
            }

            yield return Value;

            if(Right != null)
            {
                foreach (var item in Right)
                {
                    yield return item;
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(",",this);
        }
    }
}
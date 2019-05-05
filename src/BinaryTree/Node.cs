using System;

namespace BinaryTree
{
    public class Node<T> where T : IComparable
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

        public override string ToString()
        {
            var left = Left?.ToString();
            var right = Right?.ToString();

            left += left != null ? "," : "";
            right = right != null ? "," + right : "";
            return $"{left}{Value}{right}";
        }
    }
}
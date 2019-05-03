using System;
using BinaryTree;
using NUnit.Framework;

namespace Tests
{
    public class NodeTests
    {
        [Test]
        public void InsertLesserWithouLeftNode()
        {
            // Arrange
            var sut = new Node<int>(5);

            // Act
            sut.Insert(1);

            // Assert
            Assert.IsNotNull(sut.Left);
            Assert.IsNull(sut.Right);
            Assert.AreEqual(1, sut.Left.Value);
        }

        [Test]
        public void InsertLesserWithLeftNode()
        {
            // Arrange
            var sut = new Node<int>(5);
            sut.Insert(4);

            // Act
            sut.Insert(3);

            // Assert
            Assert.IsNotNull(sut.Left.Left);
            Assert.IsNull(sut.Right);
            Assert.IsNull(sut.Left.Right);
            Assert.AreEqual(3, sut.Left.Left.Value);
        }

        [Test]
        public void InsertGreaterWithRightNode()
        {
            // Act
            var sut = new Node<int>(5);
            sut.Insert(6);

            // Assert
            Assert.IsNotNull(sut.Right);
            Assert.IsNull(sut.Left);
            Assert.AreEqual(6, sut.Right.Value);
        }

        [Test]
        public void InsertGreaterWithoutRightNode()
        {
            // Arrange
            var sut = new Node<int>(5);
            sut.Insert(6);

            // Act
            sut.Insert(7);

            // Assert
            Assert.IsNotNull(sut.Right.Right);
            Assert.IsNull(sut.Left);
            Assert.IsNull(sut.Right.Left);
            Assert.AreEqual(7, sut.Right.Right.Value);
        }

        [Test]
        public void ToStringReturnsElementsInOrder()
        {
            // Arrange
            var sut = new Node<int>(5);
            sut.Insert(6);
            sut.Insert(7);
            sut.Insert(4);
            sut.Insert(3);

            // Act
            var toString = sut.ToString();

            // Assert
            var values = toString.Split(',', 0);
            for (int i = 1; i < values.Length - 1 ; i++)
            {
                Assert.Greater(values[i],values[i-1]);
            }
        }
    }
}
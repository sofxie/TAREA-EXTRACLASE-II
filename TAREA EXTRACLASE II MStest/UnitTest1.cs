using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TAREA_EXTRACLASE_II;
using System;
namespace TAREA_EXTRACLASE_II_MStest
{
    [TestClass]
    public class MergeSortedTests
    {
        [TestMethod] 
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSorted_WithNullListA_ThrowsArgumentNullException()
        {
            // Arrange
            IList<Node> listA = null;
            IList<Node> listB = new List<Node> { new Node(1), new Node(2) };

            // Act
            MergeSorted(listA, listB, SortDirection.Asc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSorted_WithNullListB_ThrowsArgumentNullException()
        {
            // Arrange
            IList<Node> listA = new List<Node> { new Node(1), new Node(2) };
            IList<Node> listB = null;

            // Act
            MergeSorted(listA, listB, SortDirection.Asc);
        }

        [TestMethod]
        public void MergeSorted_WithAscendingDirection_ReturnsMergedListInAscendingOrder()
        {
            // Arrange
            IList<Node> listA = new List<Node> { new Node(1), new Node(3), new Node(5) };
            IList<Node> listB = new List<Node> { new Node(2), new Node(4), new Node(6) };

            // Act
            List<Node> result = MergeSorted(listA, listB, SortDirection.Asc);

            // Assert
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(1, result[0].data);
            Assert.AreEqual(2, result[1].data);
            Assert.AreEqual(3, result[2].data);
            Assert.AreEqual(4, result[3].data);
            Assert.AreEqual(5, result[4].data);
            Assert.AreEqual(6, result[5].data);
        }

        [TestMethod]
        public void MergeSorted_WithDescendingDirection_ReturnsMergedListInDescendingOrder()
        {
            // Arrange
            IList<Node> listA = new List<Node> { new Node(1), new Node(3), new Node(5) };
            IList<Node> listB = new List<Node> { new Node(2), new Node(4), new Node(6) };

            // Act
            List<Node> result = MergeSorted(listA, listB, SortDirection.Desc);

            // Assert
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(6, result[0].data);
            Assert.AreEqual(5, result[1].data);
            Assert.AreEqual(4, result[2].data);
            Assert.AreEqual(3, result[3].data);
            Assert.AreEqual(2, result[4].data);
            Assert.AreEqual(1, result[5].data);
        }

        // The MergeSorted method being tested
        public static List<Node> MergeSorted(IList<Node> listA, IList<Node> listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new ArgumentNullException("List can not be null");
            }
            List<Node> mergedList = new List<Node>();
            int indexA = 0;
            int indexB = 0;

            while (indexA < listA.Count && indexB < listB.Count)
            {
                int comparisonResult = CompareNodes(listA[indexA], listB[indexB]);
                bool shouldInsertA = direction == SortDirection.Asc ? comparisonResult <= 0 : comparisonResult >= 0;
                if (shouldInsertA)
                {
                    mergedList.Add(listA[indexA]);
                    indexA++;
                }
                else
                {
                    mergedList.Add(listB[indexB]);
                    indexB++;
                }
            }
            while (indexA < listA.Count)
            {
                mergedList.Add(listA[indexA]);
                indexA++;
            }

            while (indexB < listB.Count)
            {
                mergedList.Add(listB[indexB]);
                indexB++;
            }
            return mergedList;
        }

        private static int CompareNodes(Node nodeA, Node nodeB)
        {
            return ((int)nodeA.data).CompareTo((int)nodeB.data);
        }
    }
}

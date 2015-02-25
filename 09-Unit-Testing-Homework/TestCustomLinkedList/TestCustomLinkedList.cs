using System;
using CustomLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCustomLinkedList
{
    [TestClass]
    public class TestCustomLinkedList
    {
        private DynamicList<int> dynamicList;
            
        [TestInitialize]
        public void TestInitialize()
        {
            dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void TestDynamicListCountAfterCreatingNewDynamicList()
        {
            Assert.AreEqual(0, dynamicList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestElementAtZeroIndexOfEmptyDynamicList()
        {
            int number = dynamicList[0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementAtZeroIndexOfEmptyDynamicList()
        {
            dynamicList[0] = 10;
        }

        [TestMethod]
        public void TestGettingElementAtIndex()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            Assert.AreEqual(3, dynamicList[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGettingElementAtNegativeIndex()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            int number = dynamicList[-5];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGettingElementAtIndexBiggerThanCount()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            int number = dynamicList[15];
        }

        [TestMethod]
        public void TestSettingElementAtIndex()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            dynamicList[1] = 555;

            Assert.AreEqual(555, dynamicList[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementAtNegativeIndex()
        {
            dynamicList[-10] = 555;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementAtIndexBiggerThenCount()
        {
            dynamicList.Add(5);
            dynamicList[4] = 555;
        }

        [TestMethod]
        public void TestRemovingElementAtIndexByCount()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            dynamicList.RemoveAt(2);

            Assert.AreEqual(2, dynamicList.Count);
        }

        [TestMethod]
        public void TestRemovingElementAtIndexByContent()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            dynamicList.RemoveAt(2);

            string numbersResult = "105";
            string numbersFromDynamicList = "";
            for (int i = 0; i < dynamicList.Count; i++)
            {
                numbersFromDynamicList += dynamicList[i];
            }

            Assert.AreEqual(numbersResult, numbersFromDynamicList);
        }

        [TestMethod]
        public void TestRemovingAllElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            dynamicList.RemoveAt(0);
            dynamicList.RemoveAt(0);
            dynamicList.RemoveAt(0);

            Assert.AreEqual(0, dynamicList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementAtIndexBiggerThanCount()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            dynamicList.RemoveAt(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementAtNegativeIndex()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            dynamicList.RemoveAt(-2);
        }

        [TestMethod]
        public void TestRemovingElementByValue()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            dynamicList.Remove(5);

            string numbersResult = "103";
            string numbersFromDynamicList = "";
            for (int i = 0; i < dynamicList.Count; i++)
            {
                numbersFromDynamicList += dynamicList[i];
            }

            Assert.AreEqual(numbersResult, numbersFromDynamicList);
        }

        [TestMethod]
        public void TestRemovingNonExistingElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            int result = dynamicList.Remove(999);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestIndexOfExistingElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            int index = dynamicList.IndexOf(3);

            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void TestIndexOfNonExistingElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            int index = dynamicList.IndexOf(55);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void TestIfDynamicListContainsElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            bool elementExists = dynamicList.Contains(10);

            Assert.IsTrue(elementExists);
        }

        [TestMethod]
        public void TestIfDynamicListContainsNonExistingElement()
        {
            dynamicList.Add(10);
            dynamicList.Add(5);
            dynamicList.Add(3);

            bool elementExists = dynamicList.Contains(999);

            Assert.IsFalse(elementExists);
        }
    }
}

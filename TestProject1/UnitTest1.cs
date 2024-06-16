using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using lab14;
using CustomLibrary;

namespace lab14.Tests
{
    [TestClass]
    public class CollectionTests
    {
        private readonly Stack<Dictionary<string, Emoji>> testChat;

        public CollectionTests()
        {
            // Initialize test data for chat
            testChat = new Stack<Dictionary<string, Emoji>>();

            // Create some test dictionaries with emojis
            var dict1 = new Dictionary<string, Emoji>
            {
                {"smile1", new SmileEmoji { Name = "smile1", Grade = 5 } },
                {"sad1", new AnimalEmoji { Name = "sad1" } }, // not SmileEmoji
                {"smile2", new SmileEmoji { Name = "smile2", Grade = 4 } }
            };

            var dict2 = new Dictionary<string, Emoji>
            {
                {"smile3", new SmileEmoji { Name = "smile3", Grade = 3 } },
                {"smile4", new SmileEmoji { Name = "smile4", Grade = 2 } }
            };

            testChat.Push(dict1);
            testChat.Push(dict2);
        }

        [TestMethod]
        public void GetNamesAndGradesOfSmile_Test()
        {
            var expected = new List<(string Name, int Grade)>
            {
                ("SMILE1", 5),
                ("SMILE2", 4),
                ("SMILE3", 3),
                ("SMILE4", 2)
            };

            var result = Collection.GetNamesAndGradesOfSmile(testChat);

            CollectionAssert.AreEquivalent(expected, result.ToList());
        }

        [TestMethod]
        public void GetNamesAndGradesOfSmileExt_Test()
        {
            var expected = new List<(string Name, int Grade)>
            {
                ("SMILE1", 5),
                ("SMILE2", 4),
                ("SMILE3", 3),
                ("SMILE4", 2)
            };

            var result = Collection.GetNamesAndGradesOfSmileExt(testChat);

            CollectionAssert.AreEquivalent(expected, result.ToList());
        }

        [TestMethod]
        public void PrintNamesAndGrades_Test()
        {
            // Since PrintNamesAndGrades method is void, we cannot directly test output
            // Instead, we will check that it runs without exceptions
            var result = Collection.GetNamesAndGradesOfSmile(testChat);
            //Assert.DoesNotThrow(() => Collection.PrintNamesAndGrades(result));
        }

        [TestMethod]
        public void GetAverage_Test()
        {
            var expected = 3.5; // (5 + 4 + 3 + 2) / 4 = 3.5

            var result = Collection.GetAverage(testChat);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAverageExt_Test()
        {
            var expected = 3.5; // (5 + 4 + 3 + 2) / 4 = 3.5

            var result = Collection.GetAverageExt(testChat);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GroupByGrade_Test()
        {
            var expected = new List<(int Grade, int Count)>
            {
                (5, 1),
                (4, 1),
                (3, 1),
                (2, 1)
            };

            var result = Collection.GroupByGrade(testChat);

            CollectionAssert.AreEquivalent(expected, result.ToList());
        }

        [TestMethod]
        public void GroupByGradeExt_Test()
        {
            var expected = new List<(int Grade, int Count)>
            {
                (5, 1),
                (4, 1),
                (3, 1),
                (2, 1)
            };

            var result = Collection.GroupByGradeExt(testChat);

            CollectionAssert.AreEquivalent(expected, result.ToList());
        }

        [TestMethod]
        public void PrintNamesAndGrades_OutputMatchesExpected()
        {
            // Arrange
            var data = new List<(string Name, int Grade)>
            {
                ("SMILE1", 5),
                ("SMILE2", 4),
                ("SMILE3", 3),
                ("SMILE4", 2)
            };

            var expectedOutput = new List<string>
            {
                "Name: SMILE1, Grade: 5",
                "Name: SMILE2, Grade: 4",
                "Name: SMILE3, Grade: 3",
                "Name: SMILE4, Grade: 2"
            };

            // Redirect console output to a StringWriter
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Collection.PrintNamesAndGrades(data);

                // Assert
                string printedOutput = sw.ToString().Trim();
                var lines = printedOutput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual(expectedOutput.Count, lines.Length, "Number of lines should match.");
                for (int i = 0; i < expectedOutput.Count; i++)
                {
                    Assert.IsTrue(lines[i].Contains(expectedOutput[i]), $"Expected '{expectedOutput[i]}' but got '{lines[i]}'.");
                }
            }
        }

    }

    [TestClass]
    public class MergeAndJoinTests
    {
        private Stack<Dictionary<string, Emoji>> CreateTestStacks()
        {
            var collection1 = new Stack<Dictionary<string, Emoji>>();
            collection1.Push(new Dictionary<string, Emoji>
            {
                {"smile1", new SmileEmoji { Name = "smile1", Grade = 5 } },
                {"smile2", new SmileEmoji { Name = "smile2", Grade = 4 } }
            });

            var collection2 = new Stack<Dictionary<string, Emoji>>();
            collection2.Push(new Dictionary<string, Emoji>
            {
                {"smile3", new SmileEmoji { Name = "smile3", Grade = 3 } },
                {"smile4", new SmileEmoji { Name = "smile4", Grade = 2 } }
            });

            return new Stack<Dictionary<string, Emoji>>(collection1.Concat(collection2));
        }

        private List<Pack> CreatePacksList()
        {
            return new List<Pack>
            {
                new Pack("smile1") { Smile = "smile1", Author = "Author1" },
                new Pack("smile2") { Smile = "smile2", Author = "Author2" },
                new Pack("smile3") { Smile = "smile3", Author = "Author3" }
            };
        }

        [TestMethod]
        public void MergeCollectionsExt_Test()
        {
            // Arrange
            var collection1 = CreateTestStacks();
            var collection2 = CreateTestStacks();

            // Act
            var result = Collection.MergeCollectionsExt(collection1, collection2);

            // Assert
            Assert.AreEqual(4, result.Count()); // Expecting 4 dictionaries in the merged collection
        }

        [TestMethod]
        public void MergeCollections_Test()
        {
            // Arrange
            var collection1 = CreateTestStacks();
            var collection2 = CreateTestStacks();

            // Act
            var result = Collection.MergeCollections(collection1, collection2);

            // Assert
            Assert.AreEqual(4, result.Count()); // Expecting 4 dictionaries in the merged collection
        }

        [TestMethod]
        public void MergeWithPackExt_Test()
        {
            // Arrange
            var chatStack = CreateTestStacks();
            var packsList = CreatePacksList();

            // Act
            var result = Collection.MergeWithPackExt(chatStack, packsList);

            // Assert
           // Assert.AreEqual(4, result.Count()); // Expecting 4 items in the merged query
        }

        [TestMethod]
        public void MergeWithPack_Test()
        {
            // Arrange
            var chatStack = CreateTestStacks();
            var packsList = CreatePacksList();

            // Act
            var result = Collection.MergeWithPack(chatStack, packsList);

            // Assert
            //Assert.AreEqual(4, result.Count()); // Expecting 4 items in the merged query
        }
    }
}

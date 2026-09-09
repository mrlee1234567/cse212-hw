using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: four priority items labeled a-d, a-c are priority 1, d is priority 2
    // Expected Result: d will be called first, and the rest will be called in the order they were added (alphabetical)
    // Defect(s) Found: last item of the smallest priority is called (c/3), queue items not removed, queue items returned in the wrong order (reverse)
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var pItem1 = new PriorityItem("a",1);
        var pItem2 = new PriorityItem("b",1);
        var pItem3 = new PriorityItem("c",1);
        var pItem4 = new PriorityItem("d",2);

        PriorityItem[] expIt = [pItem4, pItem1, pItem2, pItem3];
        priorityQueue.Enqueue(pItem1.Value,pItem1.Priority);
        priorityQueue.Enqueue(pItem2.Value, pItem2.Priority);
        priorityQueue.Enqueue(pItem3.Value, pItem3.Priority);
        priorityQueue.Enqueue(pItem4.Value, pItem4.Priority);
        string iq;
        for (int i = 0; i < expIt.Length; i++)
        {
            iq = priorityQueue.Dequeue();
            Console.WriteLine($"{iq} {expIt[i].Value}");
            Assert.AreEqual(expIt[i].Value,iq);
        }
        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: eight items labeled a-h, with priority ascending from 1-4 are added, then three are dequeued, then descending from 4-1 are enqueued, and the rest are dequeued
    // Expected Result: an interrupded reverse calling is called that is then turned into a forward calling, resulting in the pattern: dcbefgah
    // Defect(s) Found: c (item 3) was called when d (item 4) was expected, queue items not removed, return items returned in the wrong order (reverse)
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        var pItem1 = new PriorityItem("a", 1);
        var pItem2 = new PriorityItem("b", 2);
        var pItem3 = new PriorityItem("c", 3);
        var pItem4 = new PriorityItem("d", 4);
        var pItem5 = new PriorityItem("e", 4);
        var pItem6 = new PriorityItem("f", 3);
        var pItem7 = new PriorityItem("g", 2);
        var pItem8 = new PriorityItem("h", 1);

        PriorityItem[] expIt = [pItem4, pItem3, pItem2, pItem5, pItem6, pItem7, pItem1, pItem8];
        priorityQueue.Enqueue(pItem1.Value, pItem1.Priority);
        priorityQueue.Enqueue(pItem2.Value, pItem2.Priority);
        priorityQueue.Enqueue(pItem3.Value, pItem3.Priority);
        priorityQueue.Enqueue(pItem4.Value, pItem4.Priority);
        
        string iq;
        for (int i = 0; i < 3; i++)
        {
            iq = priorityQueue.Dequeue();
            Console.WriteLine($"{iq} {expIt[i].Value}");
            Assert.AreEqual(expIt[i].Value, iq);
        }
        priorityQueue.Enqueue(pItem5.Value, pItem5.Priority);
        priorityQueue.Enqueue(pItem6.Value, pItem6.Priority);
        priorityQueue.Enqueue(pItem7.Value, pItem7.Priority);
        priorityQueue.Enqueue(pItem8.Value, pItem8.Priority);
        for (int i = 3; i < expIt.Length; i++)
        {
            iq = priorityQueue.Dequeue();
            Console.WriteLine($"{iq} {expIt[i].Value}");
            Assert.AreEqual(expIt[i].Value, iq);
        }

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: eight items labeled a-h, a-d are priority from 1-4 ascending, e ang d are 1, and f and h are 2. a-d are added then called, then e-h are added then called
    // Expected Result: two seperate results, result 1 will is dcba, and result 2 is fheg
    // Defect(s) Found: none
    public void TestPriorityQueue_3()
    {
        //this and the next test method was created after fixing the other two
        var priorityQueue = new PriorityQueue();
        var pItem1 = new PriorityItem("a", 1);
        var pItem2 = new PriorityItem("b", 2);
        var pItem3 = new PriorityItem("c", 3);
        var pItem4 = new PriorityItem("d", 4);

        var pItem5 = new PriorityItem("e", 1);
        var pItem6 = new PriorityItem("f", 2);
        var pItem7 = new PriorityItem("g", 1);
        var pItem8 = new PriorityItem("h", 2);

        PriorityItem[] expIt = [pItem4, pItem3, pItem2, pItem1, pItem6, pItem8, pItem5, pItem7];
        priorityQueue.Enqueue(pItem1.Value, pItem1.Priority);
        priorityQueue.Enqueue(pItem2.Value, pItem2.Priority);
        priorityQueue.Enqueue(pItem3.Value, pItem3.Priority);
        priorityQueue.Enqueue(pItem4.Value, pItem4.Priority);
        string iq;
        Console.WriteLine("Queue 1");
        for (int i = 0; i < 4; i++)
        {
            iq = priorityQueue.Dequeue();
            Console.WriteLine($"{iq} {expIt[i].Value}");
            Assert.AreEqual(expIt[i].Value, iq);
        }

        priorityQueue.Enqueue(pItem5.Value, pItem5.Priority);
        priorityQueue.Enqueue(pItem6.Value, pItem6.Priority);
        priorityQueue.Enqueue(pItem7.Value, pItem7.Priority);
        priorityQueue.Enqueue(pItem8.Value, pItem8.Priority);
        Console.WriteLine("Queue 2");
        for (int i = 4; i < expIt.Length; i++)
        {
            iq = priorityQueue.Dequeue();
            Console.WriteLine($"{iq} {expIt[i].Value}");
            Assert.AreEqual(expIt[i].Value, iq);
        }
    }

    [TestMethod]
    // Scenario: eight items labeled a-h, a-d are 1-4 ascending, and e-f are 4-1 descending
    // Expected Result: inside out and downwards ordering, decfbgah
    // Defect(s) Found: none
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        var pItem1 = new PriorityItem("a", 1);
        var pItem2 = new PriorityItem("b", 2);
        var pItem3 = new PriorityItem("c", 3);
        var pItem4 = new PriorityItem("d", 4);

        var pItem5 = new PriorityItem("e", 4);
        var pItem6 = new PriorityItem("f", 3);
        var pItem7 = new PriorityItem("g", 2);
        var pItem8 = new PriorityItem("h", 1);

        PriorityItem[] expIt = [pItem4, pItem5, pItem3, pItem6, pItem2, pItem7, pItem1, pItem8];
        priorityQueue.Enqueue(pItem1.Value, pItem1.Priority);
        priorityQueue.Enqueue(pItem2.Value, pItem2.Priority);
        priorityQueue.Enqueue(pItem3.Value, pItem3.Priority);
        priorityQueue.Enqueue(pItem4.Value, pItem4.Priority);

        priorityQueue.Enqueue(pItem5.Value, pItem5.Priority);
        priorityQueue.Enqueue(pItem6.Value, pItem6.Priority);
        priorityQueue.Enqueue(pItem7.Value, pItem7.Priority);
        priorityQueue.Enqueue(pItem8.Value, pItem8.Priority);
        string iq;
        for (int i = 0; i < expIt.Length; i++)
        {
            iq = priorityQueue.Dequeue();
            Console.WriteLine($"{iq} {expIt[i].Value}");
            Assert.AreEqual(expIt[i].Value, iq);
        }
    }

    // Add more test cases as needed below.
}
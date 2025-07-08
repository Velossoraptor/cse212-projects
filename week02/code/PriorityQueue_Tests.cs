using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Item with high priority is added at back of queue
    // Expected Result: lemon, banana, apple, orange
    // Defect(s) Found: starts at wrong index, stops to early, not removing after Dequeue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var apple = new PriorityItem("apple", 1);
        var banana = new PriorityItem("banana", 2);
        var orange = new PriorityItem("orange", 0);
        var lemon = new PriorityItem("lemon", 4);

        priorityQueue.Enqueue(apple.Value, apple.Priority);
        priorityQueue.Enqueue(banana.Value, banana.Priority);
        priorityQueue.Enqueue(orange.Value, orange.Priority);
        priorityQueue.Enqueue(lemon.Value, lemon.Priority);

        PriorityItem[] expected = [lemon, banana, apple, orange];
        var item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[0].Value, item);
        item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[1].Value, item);
        item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[2].Value, item);
        item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[3].Value, item);
    }

    [TestMethod]
    // Scenario: Items with tie 
    // Expected Result: banana, lemon, apple, orange
    // Defect(s) Found: was checking if equal to, should only check if greater than priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        var apple = new PriorityItem("apple", 1);
        var banana = new PriorityItem("banana", 2);
        var orange = new PriorityItem("orange", 0);
        var lemon = new PriorityItem("lemon", 2);

        priorityQueue.Enqueue(apple.Value, apple.Priority);
        priorityQueue.Enqueue(banana.Value, banana.Priority);
        priorityQueue.Enqueue(orange.Value, orange.Priority);
        priorityQueue.Enqueue(lemon.Value, lemon.Priority);

        PriorityItem[] expected = [banana, lemon, apple, orange];
        var item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[0].Value, item);
        item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[1].Value, item);
        item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[2].Value, item);
        item = priorityQueue.Dequeue();
        Assert.AreEqual(expected[3].Value, item);
    }

    [TestMethod]
    // Scenario: Empty Queue
    // Expected Result: error
    // Defect(s) Found: none
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Error should have been thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue them.
    // Expected Result: The item with the highest priority is removed first.
    // Defect(s) Found: The last item in the queue is not checked when finding the
    // highest priority item. The item is also not removed from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: Items with the same highest priority are removed in FIFO order.
    // Defect(s) Found: The implementation uses >= instead of >, causing the later
    // item with the same priority to be selected first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add one item and dequeue it, then try to dequeue again.
    // Expected Result: The first dequeue returns and removes the item. The second
    // dequeue throws an InvalidOperationException.
    // Defect(s) Found: The Dequeue method returns the item but does not remove it.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Only Item", 5);

        Assert.AreEqual("Only Item", priorityQueue.Dequeue());

        Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the message
    // "The queue is empty."
    // Defect(s) Found: None. The empty queue requirement is implemented correctly.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a queue with a valid maximum size.
        // Expected Result: The queue uses the specified maximum size.
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(3);
        Console.WriteLine(cs1);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Create a queue with a maximum size of 0.
        // Expected Result: The maximum size defaults to 10.
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(0);
        Console.WriteLine(cs2);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Create a queue with a negative maximum size.
        // Expected Result: The maximum size defaults to 10.
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(-5);
        Console.WriteLine(cs3);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add customers until the queue reaches its maximum size.
        // Expected Result: Customers can be added until the queue is full.
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(2);

        // Since AddNewCustomer is private, this test documents
        // the expected behavior of adding customers.
        Console.WriteLine("Expected: The first 2 customers should be added.");
        Console.WriteLine("Expected: A third customer should display an error message.");

        // Defect(s) Found: Queue-full check must use >= instead of >.

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Serve the next customer from a queue containing customers.
        // Expected Result: The first customer in the queue is removed and displayed.
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(3);

        Console.WriteLine("Expected: The first customer should be served and removed.");

        // Defect(s) Found: ServeCustomer removes the first customer before
        // accessing it. It should save the customer first, then remove it.

        Console.WriteLine("=================");

        // Test 6
        // Scenario: Serve a customer when the queue is empty.
        // Expected Result: An error message should be displayed instead
        // of causing an exception.
        Console.WriteLine("Test 6");
        var cs6 = new CustomerService(3);

        Console.WriteLine("Expected: An error message should be displayed.");

        // Defect(s) Found: ServeCustomer must check whether the queue is
        // empty before attempting to remove a customer.

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class. Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information. Put the
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: create queue with a less than one size
        // Expected Result: default to 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(-1);
        for (int i = 1; i < 15; i++)
        {
            cs.AddNewCustomer();
            Console.WriteLine("Added customer ", i);
        }

        // Defect(s) Found: defaults to max +1

        Console.WriteLine("=================");

        // Test 2
        // Scenario: add customers past the queue limit
        // Expected Result: eror message shows
        Console.WriteLine("Test 2");
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();

        // Defect(s) Found: kept adding to the line past the limit

        Console.WriteLine("=================");

        // Test 3
        // Scenario: dequeue customer
        // Expected Result: display results
        Console.WriteLine("Test 3");
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.ServeCustomer();


        // Defect(s) Found: removed customer too early

        Console.WriteLine("=================");
        
        // Test 4
        // Scenario: dequeue customer when line empty
        // Expected Result: error message shows
        Console.WriteLine("Test 4");
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.ServeCustomer();
        cs.ServeCustomer();


        // Defect(s) Found: uncaught error

        Console.WriteLine("=================");
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
    /// This is an inner class.  Its real name is CustomerService.Customer
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
    /// Prompt the user for the customer and problem information.  Put the 
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
        if (_queue.Count() == 0)
        {
            Console.WriteLine("Queue Empty.");
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
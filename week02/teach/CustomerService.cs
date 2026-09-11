/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>

/*

The user shall specify the maximum size of the Customer Service Queue when it is created. If the size is invalid (less than or equal to 0) then the size shall default to 10.
The AddNewCustomer method shall enqueue a new customer into the queue.
If the queue is full when trying to add a customer, then an error message will be displayed.
The ServeCustomer function shall dequeue the next customer from the queue and display the details.
If the queue is empty when trying to serve a customer, then an error message will be displayed.

*/
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: input value less than or equal to 0
        // Expected Result: queue of 10
        Console.WriteLine("Test 1");
        CustomerService cs = new CustomerService(0);
        Console.WriteLine(cs.ToString());

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: arbitrary length of a queue with customers added to, then customer is served
        // Expected Result: a queue of n with a length of #customers, then a queue with no customers
        Console.WriteLine("Test 2");
        cs = new CustomerService(5);
        Console.WriteLine(cs.ToString());
        cs.AddNewCustomer();
        Console.WriteLine(cs.ToString());
        cs.ServeCustomer();
        Console.WriteLine(cs.ToString());

        // Defect(s) Found: serve customer removes customer from queue before it can return it

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: arbitrary length of a queue with customers added to until above maximum capacity
        // Expected Result: an error
        Console.WriteLine("Test 3");
        cs = new CustomerService(1);
        Console.WriteLine(cs.ToString());
        cs.AddNewCustomer();
        Console.WriteLine(cs.ToString());
        cs.AddNewCustomer();
        Console.WriteLine(cs.ToString());

        // Defect(s) Found: does not call an error; increases beyond the maximum size!
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
        if (_queue.Count >= _maxSize) {//only was called if it was GREATER than the max size, fixed that
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
    private void ServeCustomer() {//removes from queue too early
        // _queue.RemoveAt(0);
        // var customer = _queue[0];
        // Console.WriteLine(customer);
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
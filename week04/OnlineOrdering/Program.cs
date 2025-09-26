using System;
using System.Collections.Generic;

class Program
{
    // Write a program that has classes for Product, Customer, Address, and Order. The responsibilities of these classes are as follows:

    // Order
    // Contains a list of products and a customer. Can calculate the total cost of the order. Can return a string for the packing label. Can return a string for the shipping label.
    // The total price is calculated as the sum of the total cost of each product plus a one-time shipping cost.
    // This company is based in the USA. If the customer lives in the USA, then the shipping cost is $5. If the customer does not live in the USA, then the shipping cost is $35.
    // A packing label should list the name and product id of each product in the order.
    // A shipping label should list the name and address of the customer
    // Product
    // Contains the name, product id, price, and quantity of each product.
    // The total cost of this product is computed by multiplying the price per unit and the quantity. (If the price per unit was $3 and they bought 5 of them, the product total cost would be $15.)
    // Customer
    // The customer contains a name and an address.
    // The name is a string, but the Address is a class.
    // The customer should have a method that can return whether they live in the USA or not. (Hint this should call a method on the address to find this.)
    // Address
    // The address contains a string for the street address, the city, state/province, and country.
    // The address should have a method that can return whether it is in the USA or not.
    // The address should have a method to return a string all of its fields together in one string (with newline characters where appropriate)
    // Other considerations
    // Make sure that all member variables are private and getters, setters, and constructors are created as needed.

    // Once you have created these classes, write a program that creates at least two orders with a 2-3 products each. Call the methods to get the packing label, the shipping label, and the total price of the order, and display the results of these methods.
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // Create addresses
        Address usaAddress = new Address("123 Main St", "Anytown", "CA", "USA");
        Address nonUsaAddress = new Address("45 Rue de la Paix", "Paris", "Ile-de-France", "France");

        // Create customers
        Customer usaCustomer = new Customer("John Doe", usaAddress);
        Customer nonUsaCustomer = new Customer("Jane Doe", nonUsaAddress);

        // Create products
        Product product1 = new Product("Laptop", "P-101", 1200.50m, 1);
        Product product2 = new Product("Mouse", "P-102", 25.00m, 2);
        Product product3 = new Product("Keyboard", "P-103", 75.25m, 1);
        Product product4 = new Product("Monitor", "P-104", 300.75m, 1);
        Product product5 = new Product("Webcam", "P-105", 50.00m, 1);

        // Create orders
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(nonUsaCustomer);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Order 1 information
        Console.WriteLine("=================== Order 1 ===================");
        Console.WriteLine("\n--- Packing Label ---");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("\n--- Shipping Label ---");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("\n--- Total Price ---");
        Console.WriteLine($"Total Order Price: ${order1.GetTotalPrice():F2}");

        // Display Order 2 information
        Console.WriteLine("\n=================== Order 2 ===================");
        Console.WriteLine("\n--- Packing Label ---");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("\n--- Shipping Label ---");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine("\n--- Total Price ---");
        Console.WriteLine($"Total Order Price: ${order2.GetTotalPrice():F2}");

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21_ADO_NET_PracticeProblem
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Day 21 ADO.NET Practice problem");
            Console.WriteLine("Select any one Option for \n" +
                "1. Add customer details into customer table\n" +
                "2. Get all customers details\n" +
                "3. Delete any one customer from database");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Customer customer = new Customer();
                    Console.WriteLine("Enter Customer Name");
                    customer.Name = Console.ReadLine();
                    Console.WriteLine("Enter Customer City");
                    customer.City = Console.ReadLine();
                    Console.WriteLine("Enter Customer Address");
                    customer.Address = Console.ReadLine();
                    Console.WriteLine("Enter Customer Phone Number");
                    customer.Phone = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter Customer Salary");
                    customer.Salary = Convert.ToInt64(Console.ReadLine());

                    CustomerRepo.AddCustomer(customer);
                    break;

                case 2:
                    CustomerRepo.GetAllCustomer();

                    break;
                case 3:
                    Console.WriteLine("Enter Customer name To delete Customer data");
                    Customer customer1 = new Customer()
                    {
                        Name = Console.ReadLine(),
                    };
                    CustomerRepo.DeleteCustomer(customer1);
                    break;
                default:
                    Console.WriteLine("Please Select Correct Option");
                    break;
            }

        }
    }
}

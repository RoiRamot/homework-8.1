using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApp.Classes;

namespace CustomerApp
{
    class Program
    {
        public static void Display(Customer[] arry)
        {
            foreach (var customer in arry)
            {

                if (customer == null)
                {
                    Console.Write("User is undefiend");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("customer Name:");
                    Console.Write(customer.Name);
                    Console.Write("    customer Id:");
                    Console.Write(customer.Id);
                    Console.Write("   customer Adress:");
                    Console.Write(customer.Name);
                    Console.WriteLine();
                }
            }
        }

        static List<Customer> GetCostumer(List<Customer> list, CostumerFilter filter)
        {
            List<Customer> tempList = new List<Customer>();
            foreach (Customer customer in list)
            {
                if (filter(customer))
                {
                    tempList.Add(customer);
                }
            }
            return tempList;
        }
         
        static void Main(string[] args)
        {
            //Customers generator
            #region 
            string[] nameArry = {"roi", "moti", "yoni", "avi", "jony", "dan", "haim","", null};
            string[] addressArry = { "Tel Aviv", "Yahud", "Yokneam", "Herzelia", "Eilat", "Berlin", "New York","",null };
            int id = 95;
            int generator = 0;
            Customer[] customerArry = new Customer[20];


            //Customers Genarator
            for (int i = 0; i < customerArry.Length; i++)
            {
                Customer customer = new Customer();
                if (generator == 9)
                {
                    generator = 0;
                }
                string name = nameArry[generator];
                string adress = addressArry[generator];

                customer.SetName(name);
                customer.SetAdress(adress);
                customer.SetID(id);
                customerArry[i] = customer;
                id++;
                generator++;
            }
            customerArry[19] = null;

            #endregion


            Display(customerArry);

            Array.Sort(customerArry);

            Console.WriteLine();

            Display(customerArry);

            Array.Sort(customerArry,new AnotherCustomerComparer());

            Console.WriteLine();

            Display(customerArry);
    
            Console.WriteLine();
            Console.WriteLine("filter a-k");
            Console.WriteLine();

            CostumerFilter filter = FilterAK;

            List<Customer> customersList = customerArry.ToList();

            List<Customer> filteredList = GetCostumer(customersList, filter);
            customerArry = filteredList.ToArray();
            Display(customerArry);

            Console.WriteLine();
            Console.WriteLine("filter l-z");
            Console.WriteLine();

            filteredList = GetCostumer(customersList, delegate(Customer customer)
            {
                return FilterByChar(customer, 'l', 'z');
            }); 
            
            customerArry = filteredList.ToArray();
            Display(customerArry);

            Console.WriteLine();
            Console.WriteLine("id less then 100");
            Console.WriteLine();

            filteredList = GetCostumer(customersList, c =>
            {
                if (c!=null && c.Id<=100)
                {
                    return true;
                }
                return false;
            });

            customerArry = filteredList.ToArray();
            Display(customerArry);
            
            Console.ReadLine();
        }

        private static bool FilterAK(Customer customer)
        {
            return FilterByChar(customer, 'a', 'k');

        }

        private static bool FilterByChar(Customer customer, char startChar, char lastChar)
        {
            if (customer ==null)
            {
                return false;
            }
            if (String.IsNullOrEmpty(customer.Name))
            {
                return false;
            }
            char firstChar = customer.Name.ToLowerInvariant()[0];
            if (firstChar >= startChar && firstChar <= lastChar)
            {
                return true;
            }
            return false;
        }
    }
}

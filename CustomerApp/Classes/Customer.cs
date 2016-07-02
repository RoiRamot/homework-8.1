using System;
using System.Collections.Generic;
using System.Data;

namespace CustomerApp.Classes
{
    public delegate bool CostumerFilter(Customer costumer);

    
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Adress { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAdress(string adress)
        {
            Adress = adress;
        }
        public void SetID(int id)
        {
            Id = id;
        }
        public bool Equals(Customer other)
        {
            if (other == null)
            {
                other = new Customer();
                other.Name = "user name is null";
                other.Adress = "user adress is null";
            }

            if (other.Name == Name && other.Id == Id)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Customer other)
        {
            {
                if (other == null)
                {
                    other = new Customer();
                    other.SetName("user name is null");
                    other.SetAdress("user adress is null");
                }
                return String.Compare(other.Name, Name, StringComparison.OrdinalIgnoreCase);
                
            }
        }
    }



    class AnotherCustomerComparer:IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {

            if (x == null || y == null)
            {
                x = new Customer();
                x.SetName("user name is null");
                x.SetAdress("user adress is null");

                y = new Customer();
                y.SetName("user name is null");
                y.SetAdress("user adress is null");
            }
           return x.Id-y.Id;
        }
    }
}

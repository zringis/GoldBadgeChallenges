using _05_Greet_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _05_Greet
{
    public class ProgramUI
    {
        private Greet_Repository _greeting = new Greet_Repository();
        public void Run()
        {
            SeedLists();
            RunMenu();
        }
        #region Main Menu
        public void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine($">Greeting Menu" +
                    $"\n1. Create a New Customer" +
                    $"\n2. See All Customers" +
                    $"\n3. Update a Customer" +
                    $"\n4. Delete a Customer" +
                    $"\n5. Exit");
                string inputAsString = Console.ReadLine();
                int input;
                bool isInt = int.TryParse(inputAsString, out input);
                if(isInt)
                {
                    switch(input)
                    {
                        case 1:
                            AddNewCustomer();
                            break;
                        case 2:
                            SeeAllCustomers();
                            break;
                        case 3:
                            UpdateCustomer();
                            break;
                        case 4:
                            DeleteCustomer();
                            break;
                        case 5:
                            running = false;
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($">Greeting Menu" +
                        $"\n'{inputAsString}' Is Not a Valid Input, Please Input a Number 1-4.");
                }
            }
        }
        #endregion

        #region Create New Customer
        public void AddNewCustomer()
        {
            string firstName;
            string lastName;
            CustomerType type;
            string email;

            Console.Clear();
            Console.WriteLine($">Add a New Customer");
            firstName = GetFirstName();
            lastName = GetLastName();
            type = GetCustomerType();
            email = GetEmail();
        }
        public string GetFirstName()
        {
            string firstName;
            return firstName;
        }
        public string GetLastName()
        {
            string lastName;
            return lastName;
        }
        public CustomerType GetCustomerType()
        {
            
        }
        public string GetEmail()
        {

        }

        #endregion

        #region See All Customers
        public void SeeAllCustomers()
        {
            Console.Clear();
            Console.WriteLine($">See All Customers");

        }
        #endregion

        #region Update a Customer
        public void UpdateCustomer()
        {
            
        }
        #endregion

        #region Delete a Custoemr
        public void DeleteCustomer()
        {

        }
        #endregion

        #region Pre-Load Methods
        public void SeedLists()
        {

        }
        #endregion
    }
}

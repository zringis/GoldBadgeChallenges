using _05_Greet_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _05_Greet
{
    public class ProgramUI
    {
        #region Setup
        private Greet_Repository _greetingRepo = new Greet_Repository();
        private List<Greet> _greetings;

        public ProgramUI()
        {
            _greetings = _greetingRepo.ViewList();
        }

        public void Run()
        {
            SeedLists();
            RunMenu();
        }
        #endregion

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
            Console.Clear();
            Console.WriteLine($">Add a New Customer" +
                $"\nCustomer Added With These Details:" +
                $"\n{firstName} {lastName}, {type} Customer - Message: {email}." +
                $"\n\nPress Enter to Return to the Main Menu");
            Greet greeting = new Greet(firstName, lastName, type, email);
            _greetingRepo.AddToList(greeting);
            Console.ReadLine();
        }
        public string GetFirstName()
        {
            Console.Clear();
            Console.WriteLine($">Add a New Customer");
            Console.WriteLine("Write the First Name of the Customer?");
            string firstName = Console.ReadLine();
            if (firstName == "" || firstName == " ")
            {
                Console.Clear();
                Console.WriteLine($">Add a New Customer" +
                    $"\nThe First Name of '{firstName}' Is Invalid, Press Enter to Retry.");
                Console.ReadLine();
                GetFirstName();
            }
            return firstName;
        }
        public string GetLastName()
        {
            Console.Clear();
            Console.WriteLine($">Add a New Customer");
            Console.WriteLine("Write the Last Name of the Customer?");
            string lastName = Console.ReadLine();
            if (lastName == "" || lastName == " ")
            {
                Console.Clear();
                Console.WriteLine($">Add a New Customer" +
                    $"\nThe Last Name of '{lastName}' Is Invalid, Press Enter to Retry.");
                Console.ReadLine();
                GetFirstName();
            }
            return lastName;
        }
        public CustomerType GetCustomerType()
        {
            CustomerType type;
            Console.Clear();
            Console.WriteLine($">Add a New Customer");
            Console.WriteLine($"What Type of Customer Is This?" +
                $"\n1. Current" +
                $"\n2. Potential" +
                $"\n3. Past");
            string inputAsString = Console.ReadLine();
            int input;
            bool isValid = int.TryParse(inputAsString, out input);
            
            if(!isValid)
            {
                Console.Clear();
                Console.WriteLine($">Add a New Customer");
                Console.WriteLine($"'{inputAsString}' Is Invalid, Press Enter To Try Again...");
                Console.ReadLine();
                GetCustomerType();
                type = CustomerType.Current;
            }
            switch(input)
            {
                case 1:
                    type = CustomerType.Current;
                    break;
                case 2:
                    type = CustomerType.Potential;
                    break;
                case 3:
                    type = CustomerType.Past;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($">Add a New Customer");
                    Console.WriteLine($"'{input}' Is Invalid, Press Enter To Try Again...");
                    Console.ReadLine();
                    GetCustomerType();
                    type = CustomerType.Current;
                    break;
            }
            
            return type;
        }
        public string GetEmail()
        {
            Console.Clear();
            Console.WriteLine($">Add a New Customer");
            Console.WriteLine("Write the Message You'd Like to Send to the Customer?");
            string email = Console.ReadLine();
            if (email == "" || email == " ")
            {
                Console.Clear();
                Console.WriteLine($">Add a New Customer" +
                    $"\nThe First Name of '{email}' Is Invalid, Press Enter to Retry.");
                Console.ReadLine();
                GetEmail();
            }
            return email;
        }

        #endregion

        #region See All Customers
        public void SeeAllCustomers()
        {
            Console.Clear();
            Console.WriteLine($">See All Customers");
            PrintCustomers();
            Console.ReadLine();
        }
        public void PrintCustomers()
        {
            List<Greet> greet = _greetingRepo.ViewList();
            foreach(Greet greeting in greet)
            {
                Console.WriteLine($"{greeting.FirstName} {greeting.LastName}, {greeting.Type} Customer - Message: {greeting.Email}.");
            }
            Console.WriteLine($"\nEnd of List..." +
                $"\nPress Enter to Return to Menu");
        }
        #endregion

        #region Update a Customer
        public void UpdateCustomer()
        {
            string firstName = GetUpdateFirstName();
            string firstNameToLower = firstName.ToLower();
            string lastName = GetUpdateLastName();
            string lastNameToLower = lastName.ToLower();
            int updateNum = GetUpdateNum(firstName, lastName);
            
            switch(updateNum)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine($">Update Customer" +
                        $"\nWhat is {firstName} {lastName}'s New First Name?");
                    string newFirstName = Console.ReadLine();
                    _greetingRepo.UpdateFirstName(firstNameToLower, lastNameToLower, newFirstName);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine($">Update Customer" +
                        $"\nWhat is {firstName} {lastName}'s New Last Name?");
                    string newLastName = Console.ReadLine();
                    _greetingRepo.UpdateLastName(firstNameToLower, lastNameToLower, newLastName);

                    break;
                case 3:
                    int customerTypeAsInt = GetCustomerTypeAsInt(firstName, lastName);
                    switch(customerTypeAsInt)
                    {
                        case 1:
                            _greetingRepo.UpdateCustomerType(firstNameToLower, lastNameToLower, CustomerType.Current);
                            break;
                        case 2:
                            _greetingRepo.UpdateCustomerType(firstNameToLower, lastNameToLower, CustomerType.Potential);
                            break;
                        case 3:
                            _greetingRepo.UpdateCustomerType(firstNameToLower, lastNameToLower, CustomerType.Past);
                            break;
                    }
                    
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine($">Update Customer" +
                        $"\nWhat is {firstName} {lastName}'s New Email Message?");
                    string newEmailMessage = Console.ReadLine();
                    _greetingRepo.UpdateEmail(firstNameToLower, lastNameToLower, newEmailMessage);
                    break;
            }

        }
        public string GetUpdateFirstName()
        {
            string firstName;
            Console.Clear();
            Console.WriteLine($">Update Customer" +
                $"\nWhats the First Name of the Customer You'd Like to Edit?");
            firstName = Console.ReadLine();
            return firstName;
        }
        public string GetUpdateLastName()
        {
            string lastName;
            Console.Clear();
            Console.WriteLine($">Update Customer" +
                $"\nWhats the Last Name of the Customer You'd Like to Edit?");
            lastName = Console.ReadLine();
            return lastName;
        }
        public int GetUpdateNum(string firstName, string lastName)
        {
            int updateNum;
            Console.Clear();
            Console.WriteLine($">Update Customer" +
                $"\nWhat Would You Like to Update On The Customer {firstName} {lastName}?" +
                $"\n1. First Name" +
                $"\n2. Last Name" +
                $"\n3. Customer Type" +
                $"\n4. Email");
            string updateNumAsString = Console.ReadLine();
            bool isValid = int.TryParse(updateNumAsString, out updateNum);
            if(!isValid)
            {
                Console.Clear();
                Console.WriteLine($">Update Customer" +
                    $"\n'{updateNumAsString}' Is Not a Valid Input. Please Input a Number 1-4." +
                    $"\nPress Enter to Retry...");
                Console.ReadLine();
                GetUpdateNum(firstName, lastName);
            }
            return updateNum;
        }
        public int GetCustomerTypeAsInt(string firstName, string lastName)
        {
            Console.Clear();
            Console.WriteLine($">Update Customer" +
                        $"\nWhat is {firstName} {lastName}'s New Customer Type?" +
                        $"\n1. Current" +
                        $"\n2. Potential" +
                        $"\n3. Past");
            string newCustomerTypeAsString = Console.ReadLine();
            int customerTypeAsInt;
            bool isValid = int.TryParse(newCustomerTypeAsString, out customerTypeAsInt);
            if (!isValid && customerTypeAsInt >= 4 && customerTypeAsInt <= 0)
            {
                Console.WriteLine($"'{newCustomerTypeAsString}' Is Not Valid. Please Input 1-3." +
                    $"\nPress Enter to Try Again");
                Console.ReadLine();
                GetCustomerTypeAsInt(firstName, lastName);
            }
            return customerTypeAsInt;
        }
        #endregion

        #region Delete a Custoemr
        public void DeleteCustomer()
        {
            string firstName = DeleteGetFirstName();
            string lastName = DeleteGetLastName();
            DeleteCustomer(firstName, lastName);

        }

        public string DeleteGetFirstName()
        {
            Console.Clear();
            Console.WriteLine($">Delete Menu" +
                $"\nWhat's the First Name of the Person You'd Like to Remove?");
            string firstName = Console.ReadLine().ToLower();
            return firstName;
        }
        public string DeleteGetLastName()
        {
            Console.Clear();
            Console.WriteLine($">Delete Menu" +
                $"\nWhat's the Last Name of the Person You'd Like to Remove?");
            string firstName = Console.ReadLine().ToLower();
            return firstName;
        }
        public void DeleteCustomer(string firstName, string lastName)
        {
            _greetingRepo.DeleteFromList(firstName, lastName);
            Console.Clear();
            Console.WriteLine(">DeleteMenu" +
                $"\n{firstName} {lastName} Has Been Removed" +
                $"\nPress Enter to Return to Main Menu");
            Console.ReadLine();
        }
        #endregion

        #region Pre-Load Methods
        public void SeedLists()
        {
            Greet newGreeting0 = new Greet("Adim", "Zigunus", CustomerType.Potential, "Not sure why you havent joined us yet, what are you waiting for?");
            _greetingRepo.AddToList(newGreeting0);
            Greet newGreeting1 = new Greet("Tom", "Barker", CustomerType.Current, "Thank you for being a customer! Next Month We Will Send You A Coupon!");
            _greetingRepo.AddToList(newGreeting1);
            Greet newGreeting2 = new Greet("James", "Arkin", CustomerType.Past, "For being a past customer, we will offer you lower rates!");
            _greetingRepo.AddToList(newGreeting2);
            Greet newGreeting3 = new Greet("Zachary", "Arkin", CustomerType.Potential, "We have the LOWEST rates on helicopter insurance! Give us a ring!");
            _greetingRepo.AddToList(newGreeting3);
            Greet newGreeting4 = new Greet("Donnovan", "Domino", CustomerType.Current, "Thank you for being a customer! Next Month We Will Send You A Coupon!");
            _greetingRepo.AddToList(newGreeting4);
            Greet newGreeting5 = new Greet("Zdim", "Aigunus", CustomerType.Potential, "Cmonnnnnn you're over paying for insurance. Don't wait! Join Us!");
        }
        #endregion

    }
}

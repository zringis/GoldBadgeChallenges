using _01_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Cafe
{
    public class ProgramUI
    {
        private Cafe_Repository _cafeRepo = new Cafe_Repository();
        private List<Product> _products;
        private bool running = true;
        public ProgramUI()
        {
            _products = _cafeRepo.GetMenu();
        }

        public void Run()
        {
            SeedList();
            RunMenu();
        }

        public void RunMenu()
        {
            //bool running = true;
            while(running)
            {
                Console.Clear();
                Console.WriteLine("\t>Cafe Menu" +
                    "\n>What Would You Like To Do?" +
                    "\n-1. Add To Menu" +
                    "\n-2. Remove From Menu" +
                    "\n-3. See Menu" +
                    "\n-4. Exit");
                    
                string input = Console.ReadLine().ToLower();
                switch(input)
                {
                    case "1":
                    case "add":
                        AddToMenu();
                        break;
                    case "2":
                    case "remove":
                        RemoveFromMenu();
                        break;
                    case "3":
                    case "menu":
                    case "see menu":
                        SeeMenuList();
                        break;
                    case "4":
                    case "exit":
                        running = false;
                        break;
                    default:
                        Console.WriteLine($"'{input}' Is an Invalid Input!" +
                            $"\nPress Enter to Return to the Menu...");
                        Console.ReadLine();
                        break;
                }

            }
        }

        public void AddToMenu()
        {
            Console.Clear();
            Console.WriteLine($">Add To Menu" +
                $"\n-" +
                $"\nWhat's The Meal Number?");
            string mealNumberAsString = Console.ReadLine();
            bool testMealNumber = TestInt(mealNumberAsString);
            if (testMealNumber == true)
            {
                int mealNumber = int.Parse(mealNumberAsString);
                bool success = _cafeRepo.CheckIfExists(mealNumber);
                if (success == true)
                {
                    Console.Clear();
                    Console.WriteLine($">Add To Menu" +
                        $"\n-#{mealNumber}" +
                        $"\nWhat's The Meal Name For The Number {mealNumber}?");
                    string mealName = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine($">Add To Menu" +
                        $"\n-#{mealNumber} - {mealName}" +
                        $"\nGive A Brief Description of the {mealName}.");
                    string description = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine($">Add To Menu" +
                        $"\n-#{mealNumber} - {mealName}, {description}. " +
                        $"\nWhat Ingredients Are In the {mealName}.");
                    string ingredients = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine($">Add To Menu" +
                        $"\n-#{mealNumber} - {mealName}, {description}; Ingredients: {ingredients}" +
                        $"\nWhats The Price of the {mealName}?");
                    string priceAsString = Console.ReadLine();
                    bool testPriceBool = TestBool(priceAsString);
                    if(testPriceBool == true)
                    {
                        double price = double.Parse(priceAsString);

                        Console.Clear();
                        Console.WriteLine($">Added {mealName} To Menu" +
                            $"\n-#{mealNumber} - {mealName}, {description}; Ingredients: {ingredients} for ${price}" +
                            $"\nPress Enter to Return to the Menu...");
                        AddItem(mealNumber, mealName, description, ingredients, price);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($">Add To Menu" +
                        $"\nFailed to Add Item to List; '{priceAsString}' Is Not A Proper Price!" +
                        $"\nPress Enter To Go Back...");
                        Console.ReadLine();
                        AddToMenu();

                    }
//PARSE THE DOUBLE
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($">Add To Menu" +
                        $"\nFailed to Add Item to List; {mealNumber} Already Exists!" +
                        $"\nPress Enter To Go Back...");
                    Console.ReadLine();
                    AddToMenu();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($">Add To Menu" +
                    $"\nInvalid Option Entered! {mealNumberAsString} Is Not A Valid Meal Number!" +
                    $"\nPress Enter to Go Back...");
                Console.ReadLine();
                AddToMenu();

            }
        }

        public void AddItem(int mealNumber, string mealName, string description, string ingredients, double price)
        {
            Product newMenuItem = new Product(mealNumber, mealName, description, ingredients, price);
            _cafeRepo.AddToList(newMenuItem);
        }

        public void RemoveFromMenu()
        {
            Console.Clear();
            Console.WriteLine($">Remove Item");
            PrintSimpleMenuList();
            Console.WriteLine($"What Number Would You Like To Remove?");
            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);
            Console.Clear();
            Console.WriteLine($">Remove Item" +
                $"\n Remove #{input}? (Y/N)");
            string yesorno = Console.ReadLine();
            switch(yesorno)
            {
                case "y":
                case "yes":
                    bool success = _cafeRepo.RemoveProductFromList(input);
                    if (success == true)
                    {
                        Console.Clear();
                        Console.WriteLine(">Remove Item");
                        Console.WriteLine($"Menu #{input} Has Been Removed Sussessfully." +
                            $"\nPress Enter to Return to the Meu");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Remove Item");
                        Console.WriteLine($"Menu #{input} Has Not Been Removed, Either There Was an Error, Or The Menu Number '{input}' Does Not Exist." +
                            $"\nPress Enter to Return to the Meue");
                        Console.ReadLine();
                    }
                    break;
                case "n":
                case "no":
                default:
                    Console.Clear();
                    Console.WriteLine($">Remove Item");
                    Console.WriteLine($"Would You Like To Return To The Menu?");
                    string yesorno2 = Console.ReadLine();
                    switch (yesorno2)
                    {
                        case "n":
                        case "no":
                            Console.Clear();
                            Console.WriteLine($">Remove Item" +
                                $"\nPress Enter to Return to the Remove Menu...");
                            Console.ReadLine();
                            RemoveFromMenu();
                            break;
                        case "y":
                        case "yes":
                        default:
                            Console.Clear();
                            Console.WriteLine($">Remove Item" +
                                $"\nPress Enter to Return to the Menu...");
                            Console.ReadLine();
                            break;
                    }
                    break;
            }
        }

        public void SeeMenuList()
        {
            Console.Clear();
            Console.WriteLine($">See Menu");
            PrintMenuList();
            Console.WriteLine($"Press Enter to Return to the Menu...");
            Console.ReadLine();
        }

        public void PrintMenuList()
        {
            foreach (Product prod in _products)
            {
                Console.WriteLine($"#{prod.MealNumber} - {prod.MealName} ${prod.Price}, {prod.Description}; Ingredients: {prod.Ingredients}.");
            }
        }
        public void PrintSimpleMenuList()
        {
            foreach (Product prod in _products)
            {
                Console.WriteLine($"#{prod.MealNumber} - {prod.MealName}");
            }
        }

        public bool TestInt(string input)
        {
            int number;
            bool success = int.TryParse(input, out number);
            return success;
        }

        public bool TestBool(string input)
        {
            double number;
            bool success = double.TryParse(input, out number);
            return success;
        }

        public void SeedList()
        {
            AddItem(1, "Hamburger", "Simple, yet succulent", "Bun, and burger", 6.00d);
        }

    }
}

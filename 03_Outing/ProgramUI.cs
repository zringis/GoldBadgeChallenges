using _03_Outing_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Outing
{
    public class ProgramUI
    {
        private Outing_Repository _outingRepo = new Outing_Repository();
        private List<Outing> _outings;
        private bool running = true;

        public ProgramUI()
        {
            _outings = _outingRepo.GetOutingList();
        }
        public void Run()
        {
            SeedList();
            RunMenu();
        }
        public void RunMenu()
        {
            
            while(running)
            {
                Console.Clear();
                Console.WriteLine(">Outing Events");
                Console.WriteLine("1. Add New Outing" +
                    "\n2. Outing List" +
                    "\n3. Outing Calculations" +
                    "\n4. Exit");
                string menuChoiceAsString = Console.ReadLine();
                int number;
                bool actuallyAnInt = int.TryParse(menuChoiceAsString, out number);
                if(actuallyAnInt)
                {
                    int menuChoice = int.Parse(menuChoiceAsString);
                    switch (menuChoice)
                    {
                        case 1:
                            Console.Clear();
                            Menu_AddNewOuting();
                            break;
                        case 2:
                            ListOutings();
                            break;
                        case 3:
                            ShowCombinedOutings();
                            break;
                        case 4:
                            running = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($">Outing Events" +
                        $"\n'{menuChoiceAsString}' Is Not A Proper Input." +
                        $"\nPlease Insert A Number 1-4." +
                        $"\nPress Enter to Go Back to the Menu.");
                }
            }
        }

        public void ListOutings()
        {
            //show list of all outings
            Console.Clear();
            Console.WriteLine(">Outing List");
            PrintOutings();
            Console.ReadLine();
        }
        public void PrintOutings()
        {
            foreach (Outing outing in _outings)
            {
                Console.WriteLine($"Outing Type: {outing.OutingEvent}, {outing.NumberAttended} Attendees at ${outing.CostPerPerson} For a Total Cost of ${outing.TotalCostOfEvent} on {outing.DateOfOuting}.");
            }
            Console.WriteLine("\nPress Enter to Return to Main Menu...");
        }

        public void Menu_AddNewOuting()
        {
            Console.Clear();
            Console.WriteLine($">Add New Outing" +
                $"\n-" +
                $"\nWhat Type of Outing Is Being Held?" +
                $"\n1. Golf" +
                $"\n2. Bowling" +
                $"\n3. Amusement Park" +
                $"\n4. Concert");
            string outingChoiceAsString = Console.ReadLine();
            int number;
            OutingType outingType;
            bool isOutingCorrect = int.TryParse(outingChoiceAsString, out number);
            if(isOutingCorrect && int.Parse(outingChoiceAsString) >= 1 && int.Parse(outingChoiceAsString) <= 4)
            {
                int outingTypeAsInt = int.Parse(outingChoiceAsString);
                outingType = (OutingType)int.Parse(outingChoiceAsString);
                switch(outingTypeAsInt)
                {
                    case 1:
                        outingChoiceAsString = "Golf";
                        break;
                    case 2:
                        outingChoiceAsString = "Bowling";
                        break;
                    case 3:
                        outingChoiceAsString = "Amusement Park";
                        break;
                    case 4:
                        outingChoiceAsString = "Concert";
                        break;
                    default:
                        outingChoiceAsString = "Error";
                        break;
                }
                Console.Clear();
                Console.WriteLine($">Add New Outing" +
                $"\n-Event Type: {outingChoiceAsString}" +
                $"\nHow Many People Attended?");
                string numberAttendedAsString = Console.ReadLine();
                bool isAttendedCorrect = int.TryParse(numberAttendedAsString, out number);
                if(isAttendedCorrect && int.Parse(numberAttendedAsString) >= 0)
                {
                    int numberAttended = int.Parse(numberAttendedAsString);
                    Console.Clear();
                    Console.WriteLine($">Add New Outing" +
                    $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees" +
                    $"\nWhat Was The Year of The Outing?" +
                    $"\n(yyyy) (Year Must Be Between 2000 and 2050)");
                    string yearAsString = Console.ReadLine();
                    bool isYearValid = int.TryParse(yearAsString, out number);
                    if(isYearValid && int.Parse(yearAsString) >= 2000 && int.Parse(yearAsString) <= 2050)
                    {
                        int year = int.Parse(yearAsString);
                        Console.Clear();
                        Console.WriteLine($">Add New Outing" +
                        $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees, Date: {year}/" +
                        $"\nWhat Was The Month of The Outing?" +
                        $"\n(mm) (Month Must Be Between 1 and 12)");
                        string monthAsString = Console.ReadLine();
                        bool isMonthValid = int.TryParse(monthAsString, out number);
                        if(isMonthValid && int.Parse(monthAsString) >= 1 && int.Parse(monthAsString) <= 12)
                        {
                            int month = int.Parse(monthAsString);
                            Console.Clear();
                            Console.WriteLine($">Add New Outing" +
                            $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees, Date: {year}/{month}/" +
                            $"\nWhat Was The Day of The Outing?" +
                            $"\n(dd) (Day Must Be Between 1 and 30)");
                            string dayAsString = Console.ReadLine();
                            bool isDayValid = int.TryParse(dayAsString, out number);
                            if(isDayValid && int.Parse(dayAsString) >= 1 && int.Parse(dayAsString) <= 30)
                            {
                                int day = int.Parse(dayAsString);
                                DateTime dateOfOuting = new DateTime(year, month, day);
                                Console.Clear();
                                Console.WriteLine($">Add New Outing" +
                                $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees, Date: {year}/{month}/{day}" +
                                $"\nWhat Was the Cost Per Person?" +
                                $"\n(x.xx) (Must Be Greater or Equal to 0.00)");
                                string costPerPersonAsString = Console.ReadLine();
                                double numberD;
                                bool isCostValid = double.TryParse(costPerPersonAsString, out numberD);
                                if (isCostValid && double.Parse(costPerPersonAsString) >= 0.00d)
                                {
                                    double costPerPerson = double.Parse(costPerPersonAsString);
                                    double totalCostOfEvent = CalculateCost(numberAttended, costPerPerson, outingTypeAsInt);
                                    Console.Clear();
                                    Console.WriteLine($">Add New Outing" +
                                    $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees, Date: {year}/{month}/{day}. Each Person Costed {costPerPerson}, For A Total of ${totalCostOfEvent}" +
                                    $"\nOuting Successfully Added!" +
                                    $"\nPress Enter to Return to the Main Menu...");
                                    AddOutingToList(outingType, numberAttended, dateOfOuting, costPerPerson, totalCostOfEvent);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine(">Add New Outing" +
                                        $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees, Date: {year}/{month}/{day}");
                                    Console.WriteLine($"'{costPerPersonAsString}' Is Not A Valid Input." +
                                        $"\nPlease Input a Valid Cost Greater Than or Equal To 0.00." +
                                        $"\nPress Enter to Return to the Add Menu...");
                                    Console.ReadLine();
                                    Menu_AddNewOuting();
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(">Add New Outing" +
                                    $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees, Date: {year}/{month}/");
                                Console.WriteLine($"'{dayAsString}' Is Not A Valid Input." +
                                    $"\nPlease Input a Valid Day Between 1 and 32." +
                                    $"\nPress Enter to Return to the Add Menu...");
                                Console.ReadLine();
                                Menu_AddNewOuting();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(">Add New Outing" +
                                $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees, Date: {year}/");
                            Console.WriteLine($"'{yearAsString}' Is Not A Valid Input." +
                                $"\nPlease Input a Valid Month Between 1 and 12." +
                                $"\nPress Enter to Return to the Add Menu...");
                            Console.ReadLine();
                            Menu_AddNewOuting();
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Add New Outing" +
                            $"\n-Event Type: {outingChoiceAsString}, {numberAttended} Attendees");
                        Console.WriteLine($"'{yearAsString}' Is Not A Valid Input." +
                            $"\nPlease Input a Valid Year Between 2000 and 2050." +
                            $"\nPress Enter to Return to the Add Menu...");
                        Console.ReadLine();
                        Menu_AddNewOuting();
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Add New Outing" +
                        $"\n-Event Type: {outingChoiceAsString}");
                    Console.WriteLine($"'{numberAttendedAsString}' Is Not A Valid Input." +
                        $"\nPlease Input a Valid Number Greater Than 0." +
                        $"\nPress Enter to Return to the Add Menu...");
                    Console.ReadLine();
                    Menu_AddNewOuting();
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Add New Outing" +
                    "\n-");
                Console.WriteLine($"\n'{outingChoiceAsString}' Is Not A Valid Input." +
                    $"\nPlease Input a Number 1-4." +
                    $"\nPress Enter to Return to the Add Menu...");
                Console.ReadLine();
                Menu_AddNewOuting();
            }
        }
        public void ShowCombinedOutings()
        {
            /*Calculations
             They'd like to see a display for the combined cost for all outings
             theyd like to see a display of outing costs by type
                (for example) all bowling outings costed 2000 and all concerts were 50000*/
            Console.Clear();
            Console.WriteLine(">Outing Calculations" +
                "\n What Totals Are You Looking For?");
            Console.WriteLine("1. Golf" +
                "\n2. Bowling" +
                "\n3. Amusement Park" +
                "\n4. Concert" +
                "\n5. All Outings");
            string outingCalcInput = Console.ReadLine();
            int number;
            bool isCalcOutputTrue = int.TryParse(outingCalcInput, out number);
            if(isCalcOutputTrue)
            {
                int outingChoice = int.Parse(outingCalcInput);
                switch(outingChoice)
                {
                    //double outingTotalForEventType = _outingRepo.ViewTotalOutingCostByType(outing);
                    case 1:
                        double outingTotalForEventType = _outingRepo.ViewTotalOutingCostByType(OutingType.Golf);
                        Console.Clear();
                        Console.WriteLine($">Outing Calculations" +
                            $"\nThe Total Cost For Golfing Events Comes To: ${outingTotalForEventType}");
                        Console.WriteLine("Press Enter To Return To The Main Menu");
                        Console.ReadLine();
                        break;
                    case 2:
                        double outingTotalForEventType2 = _outingRepo.ViewTotalOutingCostByType(OutingType.Bowling);
                        Console.Clear();
                        Console.WriteLine($">Outing Calculations" +
                            $"\nThe Total Cost For Bowling Events Comes To: ${outingTotalForEventType2}");
                        Console.WriteLine("Press Enter To Return To The Main Menu");
                        Console.ReadLine();
                        break;
                    case 3:
                        double outingTotalForEventType3 = _outingRepo.ViewTotalOutingCostByType(OutingType.AmusementPark);
                        Console.Clear();
                        Console.WriteLine($">Outing Calculations" +
                            $"\nThe Total Cost For Amusement Parks Comes To: ${outingTotalForEventType3}");
                        Console.WriteLine("Press Enter To Return To The Main Menu");
                        Console.ReadLine();
                        break;
                    case 4:
                        double outingTotalForEventType4 = _outingRepo.ViewTotalOutingCostByType(OutingType.Concert);
                        Console.Clear();
                        Console.WriteLine($">Outing Calculations" +
                            $"\nThe Total Cost For Concerts Comes To: ${outingTotalForEventType4}");
                        Console.WriteLine("Press Enter To Return To The Main Menu");
                        Console.ReadLine();
                        break;
                    case 5:
                        double outingTotalForEventType5 = _outingRepo.ViewTotalOutingCostForAll();
                        outingTotalForEventType = _outingRepo.ViewTotalOutingCostByType(OutingType.Golf);
                        outingTotalForEventType2 = _outingRepo.ViewTotalOutingCostByType(OutingType.Bowling);
                        outingTotalForEventType3 = _outingRepo.ViewTotalOutingCostByType(OutingType.AmusementPark);
                        outingTotalForEventType4 = _outingRepo.ViewTotalOutingCostByType(OutingType.Concert);
                        Console.Clear();
                        Console.WriteLine($">Outing Calculations" +
                            $"\nThe Total Cost For All Events Comes To: ${outingTotalForEventType5}" +
                            $"\n\nThe Total Costs For Golfing Comes To: ${outingTotalForEventType}" +
                            $"\nThe Total Costs For Bowling Comes To: ${outingTotalForEventType2}" +
                            $"\nThe Total Costs For Amusement Parks Comes To: ${outingTotalForEventType3}" +
                            $"\nThe Total Costs For Concerts Comes To: ${outingTotalForEventType4}\n");
                        Console.WriteLine("Press Enter To Return To The Main Menu");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($">Outing Calculations" +
                    $"\n'{outingCalcInput}' Is Not A Proper Input." +
                    $"\nPlease Insert A Number 1-5." +
                    $"\nPress Enter to Go Back to the Menu.");
                Console.ReadLine();
            }
            //
        }
        public void SeedList()
        {
            AddOutingToList(OutingType.AmusementPark, 200, new DateTime(19, 01, 22), 100d, CalculateCost(200, 100d, 3));
            AddOutingToList(OutingType.Bowling, 10, new DateTime(2019, 01, 22), 5.50, CalculateCost(10, 5.50d, 2));
            AddOutingToList(OutingType.Golf, 200, new DateTime(2019, 01, 22), 100d, CalculateCost(200, 100d, 1));
            AddOutingToList(OutingType.Concert, 200, new DateTime(2019, 01, 22), 100d, CalculateCost(200, 100d, 4));
        }
        public double CalculateCost(int numberAttended, double costPerPerson, int outingType)
        {
            double amusementParkCost = 200.00;
            double bowlingCost = 25.00;
            double golfCost = 250.00;
            double concertCost = 5.00;
            double totalCost;
            double rentCost;

            if(outingType == 1)
            {
                rentCost = golfCost;
                totalCost = numberAttended * costPerPerson + rentCost;
                return totalCost;
            }
            else if(outingType == 2)
            {
                rentCost = bowlingCost;
                totalCost = numberAttended * costPerPerson + rentCost;
                return totalCost;
            }
            else if(outingType == 3)
            {
                rentCost = amusementParkCost;
                totalCost = numberAttended * costPerPerson + rentCost;
                return totalCost;
            }
            else
            {
                rentCost = concertCost;
                totalCost = numberAttended * costPerPerson + rentCost;
                return totalCost;
            }


        }
        public void AddOutingToList(OutingType outingType, int numberAttended, DateTime dateOfOuting, double costPerPerson, double totalCostOfEvent)
        {
            Outing newOuting = new Outing(outingType, numberAttended, dateOfOuting, costPerPerson, totalCostOfEvent);
            _outingRepo.AddToList(newOuting);
        }

    }
}

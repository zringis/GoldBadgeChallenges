using _02_Claim_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02_Claim
{
    #region Main Class
    public class ProgramUI
    {
        public int managerPass = 0000;
        private Claim_Repository _claimRepo = new Claim_Repository();

        public ProgramUI()
        {

        }

        public void Run()
        {
            SeedList();
            RunMenu();
        }
        #region Main Menu
        public void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine($">Claims Menu" +
                    $"\n1. See All Claims" +
                    $"\n2. Take Care Of Next Claim" +
                    $"\n3. Add New Claim" +
                    $"\n4. Manager Options" +
                    $"\n5. Exit");

                string menuInputAsString = Console.ReadLine();
                int menuInput;
                bool menuInputIsValid = int.TryParse(menuInputAsString, out menuInput);
                if (menuInputIsValid && menuInput >= 1 && menuInput <= 5)
                {
                    switch (menuInput)
                    {
                        case 1:
                            SeeAllClaims();
                            break;
                        case 2:
                            TakeCareOfNextClaim();
                            break;
                        case 3:
                            AddClaim();
                            break;
                        case 4:
                            TryManagerOptions();
                            break;
                        case 5:
                            running = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($">Claims Menu" +
                                $"\nWell... This Is Embarrassing, Unknown Error Occurred, Press Enter to Return to Menu and Try Again...");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($">Claims Menu" +
                        $"\nInput '{menuInputAsString}' Is Invalid." +
                        $"\nInput Must Be Between Numbers 1-4.");
                    Console.ReadLine();
                }
            }//EndOfRunning
        }
        #endregion

        #region See All Claims
        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<ClaimContent> claimQueue = _claimRepo.GetClaimQueue();
            string[] headers = new string[] { "ClaimID", "Type", "Description of Accident", "Amount", "Date of Accident", "Date of Claim", "IsValid" };
            UI_Format ConsoleFormatter = new UI_Format(1, UI_Format.Align.Left, headers);

            #region DATA
            //List<ClaimContent>
            List<string[]> claimInfo = new List<string[]>();
            foreach (var claim in claimQueue)
            {
                claimInfo.Add(new string[] { $"{claim.ClaimNumber}", $"{claim.ClaimType}", $"{claim.ClaimDescription}", $"${claim.ClaimAmount}", $"{claim.DateOfAccident}", $"{claim.DateOfClaim}", $"{claim.IsValid}" });
            }

            //foreach (ClaimContent content in claimQueue)
            //{
                string[][] data = claimInfo.ToArray();
                //string[][] data =
                //    new string[][] {
                //        new string[] {
                //            $"{content.ClaimNumber}", $"{content.ClaimType}", $"{content.ClaimDescription}", $"${content.ClaimAmount}", $"{content.DateOfAccident}",$"{content.DateOfClaim}",$"{content.IsValid}"},

                //};

                #endregion

                ArrayList arr = new ArrayList(data);
                ConsoleFormatter.RePrint(arr); //Get data variable from the link in the description
                Console.WriteLine();

            //}



            //Console.Clear();
            //Console.WriteLine($"\t>See All Claims");
            //Console.WriteLine($"ClaimID\tType\tDescription\t\tAmount\tDate of Accident\tDate of Claim\tIs Valid");
            //foreach (ClaimContent content in claimQueue)
            //{

            //    Console.WriteLine($"\n{content.ClaimNumber}\t{content.ClaimType}\t{content.ClaimDescription}\t${content.ClaimAmount}\t{content.DateOfAccident}\t{content.DateOfClaim}\t{content.IsValid}");

            //}
            Console.WriteLine($"\n\nEnd of Claims..." +
                $"\n Press Enter To Return To Menu...");
            Console.ReadLine();
        }
        #endregion

        #region Take Care Of Claims
        public void TakeCareOfNextClaim()
        {
            if (_claimRepo.HasContent())
            {
                Console.Clear();
                Console.WriteLine(">Take Care of Next Claim");
                //public ClaimContent content =_claimRepo.DealWithClaim();
                ClaimContent content = _claimRepo.ViewNextClaim();

                string[] headers = new string[] { "ClaimID", "Type", "Description of Accident", "Amount", "Date of Accident", "Date of Claim", "IsValid" };
                UI_Format ConsoleFormatter = new UI_Format(1, UI_Format.Align.Left, headers);

                #region DATA
                //List<ClaimContent>

                string[][] data = new string[][] {
                new string[] {
                $"{content.ClaimNumber}", $"{content.ClaimType}", $"{content.ClaimDescription}", $"${content.ClaimAmount}", $"{content.DateOfAccident}",$"{content.DateOfClaim}",$"{content.IsValid}"},

                };

                #endregion
                ArrayList arr = new ArrayList(data);
                ConsoleFormatter.RePrint(arr); //Get data variable from the link in the description

                Console.WriteLine($">Would You Like to Deal With This Claim? (Y/N)");
                string nextClaimInput = Console.ReadLine().ToLower();
                switch (nextClaimInput)
                {
                    case "y":
                    case "yes":
                        if (content.IsValid)
                        {
                            TakeCareOfClaimIsValid(content.ClaimType);
                        }
                        else
                        {
                            TakeCareOfClaimIsInValid(content.ClaimType);
                        }
                        break;
                    case "n":
                    case "no":
                        CancelTakingCareOfClaim(content.ClaimType);
                        break;
                    default:
                        ErrorOnMainClaimScreen(nextClaimInput);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($">Take Care of Next Claim" +
                    $"\nGood Work! All Claims Have Been Dealt With!" +
                    $"\nLet's Work on Adding New Claims to Deal With!" +
                    $"\nPress Enter to Return to the Main Menu...");
                Console.ReadLine();
            }
        }
        public void TakeCareOfClaimIsValid(string claimType)
        {
            Console.Clear();
            Console.WriteLine($">Take Care of Next Claim" +
                $"\nThe {claimType} Claim Has Been Delt With" +
                $"\nPress Enter to Return to the Main Menu...");
            Console.ReadLine();
            _claimRepo.DealWithClaim();
        }
        public void TakeCareOfClaimIsInValid(string claimType)
        {
            Console.Clear();
            Console.WriteLine($">Take Care of Next Claim" +
                $"\nThe {claimType} Claim Cannot Be Delt With! Seek a Manager To Remove It Before Continuing" +
                $"\nPress Enter to Return to the Main Menu...");
            Console.ReadLine();
        }
        public void CancelTakingCareOfClaim(string claimType)
        {
            Console.Clear();
            Console.WriteLine(">Take Care of Next Claim");
            Console.WriteLine($"No Worries, We Can Take Care of the {claimType} Claim Later" +
                $"\nPress Enter to Return to the Main Menu");
            Console.ReadLine();
        }
        public void ErrorOnMainClaimScreen(string error)
        {
            Console.Clear();
            Console.WriteLine(">Take Care of Next Claim");
            Console.WriteLine($"'{error}' Is Not A Valid Input... Please Enter 'Y' or 'N'" +
                $"\nPress Enter to Go Back To The Deal With Claim Memu");
            Console.ReadLine();
            TakeCareOfNextClaim();
        }
        #endregion

        #region Add Claims
        public void AddClaim()
        {

            int claimNumber = (_claimRepo.GetClaimNumber());
            Console.Clear();
            Console.WriteLine($">Add New Claim" +
                $"\nClaim #{claimNumber}:");
            string claimType = GetClaimType();
            Console.Clear();
            Console.WriteLine($">Add New Claim" +
                $"\nClaim #{claimNumber}: {claimType} Claim");
            string claimDescription = GetClaimDescription();
            Console.Clear();
            Console.WriteLine($">Add New Claim" +
                $"\nClaim #{claimNumber}: {claimType} Claim - {claimDescription}.");
            double claimAmount = GetClaimAmount();
            Console.Clear();
            Console.WriteLine($">Add New Claim" +
                $"\nClaim #{claimNumber}: {claimType} Claim - {claimDescription}. Claim Amount - ${claimAmount}");
            DateTime dateOfAccident = GetDateOfAccident();
            Console.Clear();
            Console.WriteLine($">Add New Claim" +
                $"\nClaim #{claimNumber}: {claimType} Claim - {claimDescription}. Claim Amount - ${claimAmount} Happened on: {dateOfAccident}");
            DateTime dateOfClaim = GetDateOfClaim();
            Console.Clear();
            Console.WriteLine($">Add New Claim" +
                $"\nClaim #{claimNumber}: {claimType} Claim - {claimDescription}. Claim Amount - ${claimAmount} Happened on: {dateOfAccident} - Claimed on: {dateOfClaim}");
            bool isValid = GetIsValid();
            Console.Clear();
            Console.WriteLine($">Add New Claim" +
                $"\nClaim #{claimNumber}: {claimType} Claim - {claimDescription}. Claim Amount - ${claimAmount} Happened on: {dateOfAccident} - Claimed on: {dateOfClaim} - Valid: {isValid} Has Been Added!" +
                $"\nPress Enter to Return to Main Menu...");
            ClaimContent claim = new ClaimContent(claimNumber, claimType, claimDescription, claimAmount, dateOfAccident, dateOfClaim, isValid);
            _claimRepo.AddToQueue(claim);
            Console.ReadLine();
        }
        public string GetClaimType()
        {
            string claimType;
            Console.WriteLine($"Insert The Claim Type (EX: House, Car, Theft)");
            claimType = Console.ReadLine();
            switch(claimType)
            {
                case "":
                case " ":
                    Console.Clear();
                    Console.WriteLine(">Add New Claim");
                    Console.WriteLine($"'{claimType}' Is an Invalid Input, Please Input A Valid Claim Type..." +
                        $"\nPress Enter to Try Again");
                    Console.ReadLine();
                    GetClaimType();
                    break;
                default:
                    break;
            }
            return claimType;
        }
        public string GetClaimDescription()
        {
            string claimDescription;
            Console.WriteLine($"Insert a Breif Description of the Claim (EX: Car Crash on I-465)");
            claimDescription = Console.ReadLine();
            switch (claimDescription)
            {
                case "":
                case " ":
                    Console.Clear();
                    Console.WriteLine(">Add New Claim");
                    Console.WriteLine($"'{claimDescription}' Is an Invalid Input, Please Input A Valid Description..." +
                        $"\nPress Enter to Try Again");
                    Console.ReadLine();
                    GetClaimType();
                    break;
                default:
                    break;
            }
            return claimDescription;
        }
        public double GetClaimAmount()
        {
            double claimAmount;
            Console.WriteLine($"Insert The Amount of the Claim (EX: 500.50)");
            string claimAmountAsString = Console.ReadLine();
            bool isValid = double.TryParse(claimAmountAsString, out claimAmount);
            if(isValid)
            {
                claimAmount = int.Parse(claimAmountAsString);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Add New Claim");
                Console.WriteLine($"'{claimAmountAsString}' Is an Invalid Input, Please Input A Valid Amount Type..." +
                    $"\nPress Enter to Try Again");
                Console.ReadLine();
                GetClaimAmount();
            }
            return claimAmount;
        }
        public DateTime GetDateOfAccident()
        {
            DateTime dateOfAccident;
            int year;
            int month;
            int day;
            Console.WriteLine($"Insert the Year of the Accident (2015 - {DateTime.Now.Year})");
            string yearAsString = Console.ReadLine();
            bool yearValidInt = int.TryParse(yearAsString, out year);
            Console.WriteLine($"Insert The Month of the Accident (1-12)");
            string monthAsString = Console.ReadLine();
            bool monthValidInt = int.TryParse(monthAsString, out month);
            Console.WriteLine($"Insert The Day of the Accident (1-30)");
            string dayAsString = Console.ReadLine();
            bool dayValidInt = int.TryParse(dayAsString, out day);
            if (yearValidInt && monthValidInt && dayValidInt && year >= 2015 && year <= DateTime.Now.Year && month >= 1 && month <= 12 && day >= 1 && day <= 30)
            {
                
                dateOfAccident = new DateTime(year, month, day);
                return dateOfAccident;

            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Add New Claim");
                Console.WriteLine($"'{year}/{month}/{day}' Is an Invalid Input, Please Input Valid Dates..." +
                    $"\nPress Enter to Try Again");
                dateOfAccident = DateTime.Now;
                GetDateOfAccident();
                return dateOfAccident;
            }
        }
        public DateTime GetDateOfClaim()
        {
            DateTime dateOfClaim;
            int year;
            int month;
            int day;
            Console.WriteLine($"Insert the Year of the Claim (2015 - {DateTime.Now.Year})");
            string yearAsString = Console.ReadLine();
            bool yearValidInt = int.TryParse(yearAsString, out year);
            Console.WriteLine($"Insert The Month of the Claim (1-12)");
            string monthAsString = Console.ReadLine();
            bool monthValidInt = int.TryParse(monthAsString, out month);
            Console.WriteLine($"Insert The Day of the Claim (1-30)");
            string dayAsString = Console.ReadLine();
            bool dayValidInt = int.TryParse(dayAsString, out day);
            if (yearValidInt && monthValidInt && dayValidInt && year >= 2015 && year <= DateTime.Now.Year && month >= 1 && month <= 12 && day >= 1 && day <= 30)
            {

                dateOfClaim = new DateTime(year, month, day);
                Console.Clear();
                Console.WriteLine(">Add New Claim");
                Console.WriteLine($"'{year}/{month}/{day}' is Set as the Day of Claim");
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadLine();
                return dateOfClaim;

            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Add New Claim");
                Console.WriteLine($"'{year}/{month}/{day}' Is an Invalid Input, Please Input Valid Dates..." +
                    $"\nPress Enter to Try Again");
                Console.ReadLine();
                GetDateOfClaim();
                dateOfClaim = DateTime.Now;
                return dateOfClaim;
            }
        }
        public bool GetIsValid()
        {
            bool isValid;
            Console.WriteLine("Is the Claim Valid?" +
                "\n1. Yes" +
                "\n2. No");
            string inputAsString = Console.ReadLine();
            int input;
            bool isValidInput = int.TryParse(inputAsString, out input);
            switch(input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(">Add New Claim" +
                        "\nClaim is Set to Valid" +
                        "\nPress Enter to Continue...");
                    isValid = true;
                    Console.ReadLine();
                    break;
                case 2:
                    isValid = false;

                    Console.Clear();
                    Console.WriteLine(">Add New Claim" +
                        "\nClaim is Set to Invalid" +
                        "\nPress Enter to Continue...");
                    Console.ReadLine();
                    break;
                default:
                    isValid = false;
                    Console.Clear();
                    Console.WriteLine(">Add New Claim");
                    Console.WriteLine($"'{inputAsString}' Is an Invalid Input, Please Input Valid Number 1 or 2..." +
                        $"\nPress Enter to Try Again");
                    Console.ReadLine();
                    GetIsValid();
                    break;
            }
            return isValid;
        }
        #endregion

        #region Manager Options
        //This requires a manager password to allow edits
        public void TryManagerOptions()
        {
            if(managerPass != 0000)
            {
                Console.Clear();
                Console.WriteLine($">Manager Options" +
                    $"\nInput the Manager PIN");
                string managerPassTest = Console.ReadLine();
                int managerTestPin;
                bool managerPinValidNumber = int.TryParse(managerPassTest, out managerTestPin);
                if(managerPinValidNumber)
                {
                    AttemptLogin(managerTestPin);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($">Manager Options" +
                        $"\n'{managerPassTest}' Is Not a Valid PIN," +
                        $"\nPress Enter to Return to the Password Menu...");
                    Console.ReadLine();
                    TryManagerOptions();
                }
            }
            else if(managerPass == 0000)
            {
                SetManagerPassword();
            }
            else
            {
                MPError();
            }
        }
        public void SetManagerPassword()
        {
            Console.Clear();
            Console.WriteLine($">Manager Options" +
                $"\nThere Is Currently No Password For Manager Options;" +
                $"\nLet's Set One!" +
                $"\n\n\t-Please Insert a 4-Digit PIN (1000-9999)");
            string managerPinAsString = Console.ReadLine();
            int managerTestPin;
            bool managerPinValid = int.TryParse(managerPinAsString, out managerTestPin);
            if(managerPinValid && managerTestPin >= 1000 && managerTestPin <= 9999)
            {
                managerPass = managerTestPin;
                Console.Clear();
                Console.WriteLine($">Manager Options" +
                    $"\n'{managerPass}' Is the New PIN to Enter Manager Options" +
                    $"\n\n\t-Please Enter to Continue to Manager Options");
                Console.ReadLine();
                ManagerOptions();

            }
            else
            {
                Console.Clear();
                Console.WriteLine($">Manager Options" +
                $"\n'{managerPinAsString}' Is Not A Valid Pin." +
                $"\nPIN Must Be Between (1000-9999)" +
                $"\nPress Enter to Retry...");
                Console.ReadLine();
                SetManagerPassword();
            }
        }
        public void MPError()
        {
            Console.Clear();
            Console.WriteLine("This Is Embarrassing. There Was An Error With The Manager Pass" +
                "\nPress Enter to Return to the Menu and Try Again...");
            Console.ReadLine();
        }
        public void AttemptLogin(int managerNumber)
        {
            Console.Clear();
            Console.WriteLine($">Manager Options");
            if(managerNumber == managerPass)
            {
                ManagerOptions();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($">Manager Options" +
                    $"\n'{managerNumber}' Is Incorrect, Press Enter to Return to Main Menu...");
                Console.ReadLine();
            }
        }
        public void ManagerViewClaims()
        {
            Console.Clear();
            Queue<ClaimContent> claimQueue = _claimRepo.GetClaimQueue();
            string[] headers = new string[] { "ClaimID", "Type", "Description of Accident", "Amount", "Date of Accident", "Date of Claim", "IsValid" };
            UI_Format ConsoleFormatter = new UI_Format(1, UI_Format.Align.Left, headers);

            #region DATA
            List<string[]> claimInfo = new List<string[]>();
            foreach (var claim in claimQueue)
            {
                claimInfo.Add(new string[] { $"{claim.ClaimNumber}", $"{claim.ClaimType}", $"{claim.ClaimDescription}", $"${claim.ClaimAmount}", $"{claim.DateOfAccident}", $"{claim.DateOfClaim}", $"{claim.IsValid}" });
            }

            string[][] data = claimInfo.ToArray();

            #endregion

            ArrayList arr = new ArrayList(data);
            ConsoleFormatter.RePrint(arr); //Get data variable from the link in the description
            Console.WriteLine();

            Console.WriteLine($"\n\nEnd of Claims..." +
                $"\n Press Enter To Return To Manager Menu...");
            Console.ReadLine();
            ManagerOptions();
        }
        public void ManagerDealWithClaim()
        {
            if (_claimRepo.HasContent())
            {
                Console.Clear();
                Console.WriteLine(">Take Care of Next Claim");
                //public ClaimContent content =_claimRepo.DealWithClaim();
                ClaimContent content = _claimRepo.ViewNextClaim();

                string[] headers = new string[] { "ClaimID", "Type", "Description of Accident", "Amount", "Date of Accident", "Date of Claim", "IsValid" };
                UI_Format ConsoleFormatter = new UI_Format(1, UI_Format.Align.Left, headers);

                #region DATA
                //List<ClaimContent>

                string[][] data = new string[][] {
                new string[] {
                $"{content.ClaimNumber}", $"{content.ClaimType}", $"{content.ClaimDescription}", $"${content.ClaimAmount}", $"{content.DateOfAccident}",$"{content.DateOfClaim}",$"{content.IsValid}"},

                };

                #endregion
                ArrayList arr = new ArrayList(data);
                ConsoleFormatter.RePrint(arr); //Get data variable from the link in the description

                Console.WriteLine($">Would You Like to Deal With This Claim? (Y/N)");
                string nextClaimInput = Console.ReadLine().ToLower();
                switch (nextClaimInput)
                {
                    case "y":
                    case "yes":
                        ManagerRemoveOrDealAnyClaim(content.ClaimType);
                        break;
                    case "n":
                    case "no":
                        CancelTakingCareOfManagerClaim(content.ClaimType);
                        break;
                    default:
                        ErrorOnMainClaimScreen(nextClaimInput);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($">Take Care of Next Claim" +
                    $"\nGood Work! All Claims Have Been Dealt With!" +
                    $"\nLet's Work on Adding New Claims to Deal With!" +
                    $"\nPress Enter to Return to the Manager Menu...");
                Console.ReadLine();
                ManagerOptions();
            }
        }
        public void CancelTakingCareOfManagerClaim(string claimType)
        {
            Console.Clear();
            Console.WriteLine(">Take Care of Next Claim");
            Console.WriteLine($"No Worries, We Can Take Care of the {claimType} Claim Later" +
                $"\nPress Enter to Return to the Manager Menu");
            Console.ReadLine();
            ManagerOptions();
        }
        public void ManagerRemoveOrDealAnyClaim(string claimType)
        {
            Console.Clear();
            Console.WriteLine($">Take Care of Next Claim" +
                $"\nThe {claimType} Claim Has Been Delt With" +
                $"\nPress Enter to Return to the Main Menu...");
            Console.ReadLine();
            _claimRepo.DealWithClaim();
            ManagerOptions();
        }

        public void ManagerOptions()
        {
            Console.Clear();
            Console.WriteLine($">Manager Options" +
                $"\n1. View Claims" +
                $"\n2. Deal With Any Claim" +
                $"\n3. Return to Menu");
            string managerOptionInputAsString = Console.ReadLine();
            int managerOptionInput;
            bool isValidManagerOption = int.TryParse(managerOptionInputAsString, out managerOptionInput);
            if(isValidManagerOption)
            {
                switch(managerOptionInput)
                {
                    case 1:
                        ManagerViewClaims();
                        break;
                    case 2:
                        ManagerDealWithClaim();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($">Manager Options" +
                            $"\nLogging Out;" +
                            $"\nPress Enter to Return to Main Menu...");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($">Manager Options" +
                    $"\n'{managerOptionInputAsString}' Is an Invalid Input, Input Must Be Numbers 1-3" +
                    $"\nPress Enter to Go Back");
                Console.ReadLine();
                ManagerOptions();
            }
        }
        #endregion

        #region PreMenu Actions
        public void SeedList()
        {
            ClaimContent claim1 = new ClaimContent(1, "House", "Tree Fell on Roof", 500.00d, new DateTime(2019, 01, 22), new DateTime(2019, 01, 24), true);
            _claimRepo.AddToQueue(claim1);

            ClaimContent claim2 = new ClaimContent(2, "Car", "Car Accident on I-69", 250.00d, new DateTime(2019, 02, 23), new DateTime(2019, 03, 01), true);
            _claimRepo.AddToQueue(claim2);

            ClaimContent claim3 = new ClaimContent(3, "Theft", "Stolen Pancakes", 4.00d, new DateTime(2019, 03, 20), new DateTime(2019, 03, 22), false);
            _claimRepo.AddToQueue(claim3);
        }
        #endregion

    }
    #endregion

    #region Seperate Classes
    class UI_Format
    {
        public enum Align { Left, Right };
        private string[] headers;
        private Align CellAlignment = Align.Left;
        private int tableYStart = 0;
        /// <summary>
        /// The last line of the table (gotton from Console.CursorTop). -1 = No printed data
        /// </summary>
        public int LastPrintEnd = -1;

        /// <summary>
        /// Helps create a table
        /// </summary>
        /// <param name="TableStart">What line to start the table on.</param>
        /// <param name="Alignment">The alignment of each cell\'s text.</param>
        public UI_Format(int TableStart, Align Alignment, string[] headersi)
        {
            headers = headersi;
            CellAlignment = Alignment;
            tableYStart = TableStart;
        }
        public void ClearData()
        {
            //Clear Previous data
            if (LastPrintEnd != -1) //A set of data has already been printed
            {
                for (int i = tableYStart; i < LastPrintEnd; i++)
                {
                    //ClearLine(i);
                }
            }
            LastPrintEnd = -1;
        }
        public void RePrint(ArrayList data)
        {
            //Set buffers
            if (data.Count > Console.BufferHeight)
                Console.BufferHeight = data.Count;
            //Clear Previous data
            ClearData();

            Console.CursorTop = tableYStart;
            Console.CursorLeft = 0;
            if (data.Count == 0)
            {
                Console.WriteLine("No Records");
                LastPrintEnd = Console.CursorTop;
                return;
            }

            //Get max lengths on each column
            int ComWidth = ((string[])data[0]).Length * 2 + 1;
            int[] ColumnLengths = new int[((string[])data[0]).Length];

            foreach (string[] row in data)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i].Length > ColumnLengths[i])
                    {
                        ComWidth -= ColumnLengths[i];
                        ColumnLengths[i] = row[i].Length;
                        ComWidth += ColumnLengths[i];
                    }
                }
            }
            //Don't forget to check headers
            for (int i = 0; i < headers.Length; i++)
            {
                if (headers[i].Length > ColumnLengths[i])
                {
                    ComWidth -= ColumnLengths[i];
                    ColumnLengths[i] = headers[i].Length;
                    ComWidth += ColumnLengths[i];
                }
            }


            if (Console.BufferWidth < ComWidth)
                Console.BufferWidth = ComWidth + 1;
            PrintLine(ComWidth);
            //Print Data
            bool first = true;
            foreach (string[] row in data)
            {
                if (first)
                {
                    //Print Header
                    PrintRow(headers, ColumnLengths);
                    PrintLine(ComWidth);
                    first = false;
                }
                PrintRow(row, ColumnLengths);
                PrintLine(ComWidth);
            }
            LastPrintEnd = Console.CursorTop;
        }

        private void ClearLine(int line)
        {
            int oldtop = Console.CursorTop;
            Console.CursorTop = line;
            int oldleft = Console.CursorLeft;
            Console.CursorLeft = 0;
            int top = Console.CursorTop;

            while (Console.CursorTop == top)
            { Console.Write(" "); }
            Console.CursorLeft = oldleft;
            Console.CursorTop = oldtop;
        }

        private void PrintLine(int width)
        {
            Console.WriteLine(new string('-', width));
        }

        private void PrintRow(string[] row, int[] Widths)
        {
            string s = "|";
            for (int i = 0; i < row.Length; i++)
            {
                if (CellAlignment == Align.Left)
                    s += row[i] + new string(' ', Widths[i] - row[i].Length + 1) + "|";
                else if (CellAlignment == Align.Right)
                    s += new string(' ', Widths[i] - row[i].Length + 1) + row[i] + "|";
            }
            if (s == "|")
                throw new Exception("PrintRow input must not be empty");

            Console.WriteLine(s);
        }
    }
    #endregion


}

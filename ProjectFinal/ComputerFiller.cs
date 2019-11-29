using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFinal
{
    class ComputerFiller
    {
        internal Program Program
        {
            get => default;
            set
            {
            }
        }

        public static string GiveName()
        {
            Console.WriteLine("Name: ");
            return Console.ReadLine();
        }
        public static double GivePrice()
        {
            while (true)
            {
                double aPrice =0;
                Console.WriteLine("Give price in euros: ");
                Console.WriteLine("Max price is 50000");
                try
                {
                    aPrice = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (aPrice > 0 && aPrice < 50000)
                {
                    return aPrice;
                }
            }
        }
        public static int GiveStoragesize()
        {
            while (true)
            {
                int aStorageSize = 0;
                Console.WriteLine("Storage size in gigabytes: ");
                Console.WriteLine("Max value is 10000");
                try
                {
                    aStorageSize = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (aStorageSize > 0 && aStorageSize < 10001)
                {
                    return aStorageSize;
                }

            }
        }
        public static int GiveComputerUse()
        {
            //Array to store uses of the computer     
            string[] uses = new string[] { "1 - Business", "2 - Editing", "3 - Basic", "4 - Gaming" };

            while (true)
            {
                int aComputerUse = 0;
                Console.WriteLine("Computer use: ");

                //Print different uses from array
                foreach (var item in uses)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    aComputerUse = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
                //Program wont allow values that are smaller than one or values that are higher than lenght of the array
                if (aComputerUse >= 1 && aComputerUse <= uses.Length)
                {
                    return aComputerUse;
                }
            }
        }
        public static int GiveStorageType()
        {
            //Array to store different storagetypes
            string[] storagetypes = new string[] { "1 - HDD", "2 - SSD", "3 - M2 SSD" };
            int aStorageType = 0;
            while (true)
            {
                Console.WriteLine("Storage type: ");
                foreach (var item in storagetypes)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    aStorageType = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
                //Program wont allow values that are smaller than one or values that are higher than lenght of the array
                if (aStorageType >= 1 && aStorageType <= storagetypes.Length)
                {
                    return aStorageType;
                }
            }
        }
        public static int GiveOperatingSystem()
        {
            //Array to store different operatingsystems
            string[] operatingsystem = new string[] { "1 - Windows", "2 - IOS", "3 - Else" };
            int aComputerOs = 0;
            while (true)
            {
                Console.WriteLine("Operating system: ");
                //Print different operatingsystems
                foreach (var item in operatingsystem)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    aComputerOs = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
                //Program wont allow values that are smaller than one or values that are higher than lenght of the array
                if (aComputerOs >= 1 && aComputerOs <= operatingsystem.Length)
                {
                    return aComputerOs;
                }
            }
        }
        public static int GiveBatteryCapacity()
        {
            //Asking the batterycapacity
            //If computer is desktop -> User must enter 0, else computer is defined as laptop
            int aBatteryCapacity;
            do
            {
                
                while (true)
                {
                    Console.WriteLine("Battery Capacity ");
                    try
                    {
                        aBatteryCapacity = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("If computer is desktop, please enter 0 ");
                        continue;
                    }
                    return aBatteryCapacity;
                }
            } while (aBatteryCapacity < 0);
        }

        public static int AskUseForSql()
        {
            while (true)
            {
                string[] uses = new string[] { "1 - Business", "2 - Editing", "3 - Basic", "4 - Gaming" };
                int useComputer = 0;
                Console.WriteLine("Computer use: ");

                //Print different uses from array
                foreach (var item in uses)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    useComputer = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
                if (useComputer >= 1 && useComputer <= 4)
                {
                    return useComputer;
                }
            }
        }

        public static int AskBudgetForSql()
        {
            int Budget;
            //Asking the budget
            do
            {   
                while (true)
                {
                    Console.WriteLine("Budget: ");
                    try
                    {
                        Budget = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    return Budget;
                }
            } while (Budget < 0);
        }

        public static void DeleteFromSql()
        {
            //First we print all the computers
            SqlQuery.Connection();
            SqlQuery.GetDesktops();
            SqlQuery.GetLaptops();
            //Ask user which computer they want to delete, user must enter ID in numbers
            Console.WriteLine("Insert the id which one you want to delete. ");
            int id = int.Parse(Console.ReadLine());
            //Confirmation that user wants to delete computer, if input is y/Y -> Delete, else break
            Console.WriteLine("Are you sure that you want to delete this computer? y/n");
            ConsoleKeyInfo cnf = Console.ReadKey();
            if (cnf.Key.ToString() == "y" || cnf.Key.ToString() == "Y")
            {
                SqlQuery.DeleteFromSql(id);
            }
            else
            {
            Console.WriteLine($"Computer with id {id} wasn't found in the database");
            }
        }       
    }    
}

using System;
using System.Collections.Generic;
using Npgsql;

namespace ProjectFinal
{
    class Program
    {
        public Computer Computer
        {
            get => default;
            set
            {
            }
        }

        static void Main(string[] args)
        {
            
                //Int input to be used on switch case
                int input;


            //While loop to run program until user selects "6 - quit"
            bool loopBreak = true;
            while (loopBreak == true) 
            {
                //Start menu
                Console.WriteLine(" 1 - Add new Computer "); 
                Console.WriteLine(" 2 - Search a laptop "); 
                Console.WriteLine(" 3 - Search a desktop "); 
                Console.WriteLine(" 4 - Show a list of all computers ");
                Console.WriteLine(" 5 - Delete computer from the database");
                Console.WriteLine(" 6 - Quit "); 
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    // Case1 : Adding new computer to database by user values
                    case 1:
                        
                            string aName = Methods.GiveName();
                            double aPrice = Methods.GivePrice();
                            int aStorageSize = Methods.GiveStoragesize();
                            int aStorageType = Methods.GiveStorageType();
                            int aComputerOs = Methods.GiveOperatingSystem();
                            int aComputerUse = Methods.GiveComputerUse();
                            int aBatteryCapacity = Methods.GiveBatteryCapacity();

                        //Connecting to database
                        SqlQuery.Connection();
                        //If batterycapacity is 0 -> Computer is defined as Desktop, else as Laptop
                        if(aBatteryCapacity == 0)
                        {
                            //Creating new Laptop
                            Laptop computer = new Laptop(aName, aPrice, aStorageSize, aBatteryCapacity, aComputerUse, aStorageType, aComputerOs);
                            //Adding Laptop to database
                            SqlQuery.StoreToSql(computer);
                        }
                        else
                        {
                            //Creating new Desktop
                            Laptop computer = new Laptop(aName, aPrice, aStorageSize, aBatteryCapacity, aComputerUse, aStorageType, aComputerOs);
                            //Adding Desktop to database
                            SqlQuery.StoreToSql(computer);
                        }                 
                    break;

                    //Searching Laptop from the database
                    case 2:
                            int useLaptop = Methods.AskUseForSql();
                            int budgetLaptop = Methods.AskBudgetForSql();
                            //Connecting to database
                            SqlQuery.Connection();
                            //Method called to import and print Laptops that suit to search criteria
                            SqlQuery.GetFromSqlLaptop(useLaptop, budgetLaptop);

                    break;

                    //Searching Desktop from the database
                    case 3:
                    
                            int useDesktop = Methods.AskUseForSql();
                            int budgetDesktop = Methods.AskBudgetForSql();
                            //Connecting to database
                            SqlQuery.Connection();
                            //Method called to import and print Laptops that suit to search criteria
                            SqlQuery.GetFromSqlLaptop(useDesktop, budgetDesktop);
                            //Connecting to database
                            SqlQuery.Connection();
                            //Method called to import and print Desktops that suit to search criteria
                            SqlQuery.GetFromsqlDesktop(useDesktop, budgetDesktop);

                    break;

                    //Print every computer from the database
                    case 4:
                        
                        //Connection to database
                        SqlQuery.Connection();
                        //Import laptops from the database
                        Console.WriteLine("All laptops in the database: ");
                        SqlQuery.GetLaptops();
                        //Import desktops from the database
                        Console.WriteLine("All desktops in the database ");
                        SqlQuery.GetDesktops();

                    break;

                    //Delete computer from the sql
                    case 5:
                        Methods.DeleteFromSql();

                    break;

                    //Exiting program 
                    case 6:    
                        loopBreak = false;
  
                    break;
                }
            }
        }
    }
}

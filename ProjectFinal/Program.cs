﻿using System;
using System.Collections.Generic;
using Npgsql;

namespace ProjectFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Desktop> desktops = new List<Desktop>();
            List<Laptop> laptops = new List<Laptop>();

            //int input switch casen käyttöön
            int input;

            //Aloitusvalikko
            Console.WriteLine(" 1 - Add new Computer ");
            Console.WriteLine(" 2 - Search a laptop ");
            Console.WriteLine(" 3 - Search a desktop ");
            Console.WriteLine(" 4 - Show a list of computers ");
            Console.WriteLine(" 5 - Quit ");
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                // Case 1 Uuden tietokoneen lisääminen tietokantaan
                case 1:
                    Console.WriteLine("Give name: ");
                    string aName = Console.ReadLine();

                    Console.WriteLine("Give price: ");
                    double aPrice = double.Parse(Console.ReadLine());

                    Console.WriteLine("Storage size ");
                    int aStorageSize = int.Parse(Console.ReadLine());

                    //Käyttötarkoituksen vaihtoehdot metodeina
                    Console.WriteLine("Use of computer ");
                    Methods.Use();
                    string aComputerUse = (Console.ReadLine());

                    //Muistityppin vaihtoehdot metodeina
                    Console.WriteLine("Storage type: ");
                    Methods.StorageType();
                    string aStorageType = (Console.ReadLine());

                    //Käyttöjärjestelmän vaihtoehdot metodeina
                    Console.WriteLine("Operating system: ");
                    Methods.OperatingSystem();
                    string aComputerOs = (Console.ReadLine());
 
                    Console.WriteLine("Battery Capacity ");
                    int aBatteryCapacity = int.Parse(Console.ReadLine());

                    Console.WriteLine($"nimi : {aBatteryCapacity}");

                    //Batterycapacityn mukaan lisätään joko listaan Laptop tai Desktop
                    if (aBatteryCapacity < 0)
                    {
                        
                        laptops.Add(new Laptop(aName, aPrice, aStorageSize, aBatteryCapacity, aComputerUse, aStorageType, aComputerOs));
                    }



                    break;

                //case 2
                //break;

                case 4:
                    //Yhteys tietokantaan
                    SqlQuery.Connection();
                    //Kannettavien tuonti tietokannasta
                    SqlQuery.GetLaptops();
                    //Desktopien tuonti tietokannasta
                    SqlQuery.GetDesktops();

                    break;

            }



        }






    }
}

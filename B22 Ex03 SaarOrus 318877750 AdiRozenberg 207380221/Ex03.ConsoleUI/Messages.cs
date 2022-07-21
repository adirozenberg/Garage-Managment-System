using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class Messages
    {
        internal static void PrintReturnToMenuMassage()
        {
            Console.WriteLine("\n Press any key to continue to main menu \n");
        }

        internal static void PrintWelcomeMassage()
        {
            Console.WriteLine("*****WELCOME TO ADI AND SAAR'S GARAGE SYSTEM!*****" + "\n");
        }

        internal static void PresentMainMenuOptions()
        {
            StringBuilder messagesToPrint = new StringBuilder();

            messagesToPrint.AppendLine("Choose one of the following options:");
            messagesToPrint.AppendLine("1. Add new vehicle to the garage.");
            messagesToPrint.AppendLine("2. Present all vehicle in garage by license number.");
            messagesToPrint.AppendLine("3. Change status of vehicle in garage.");
            messagesToPrint.AppendLine("4. Inflate air in wheels to maximum.");
            messagesToPrint.AppendLine("5. Refuel vehicle. ");
            messagesToPrint.AppendLine("6. Recharge vehicle.");
            messagesToPrint.AppendLine("7. Present full details of vehicle by license number.");
            messagesToPrint.AppendLine("8. Exit.");

            Console.WriteLine(messagesToPrint);
        }

        internal static void PrintMessageGoodBye()
        {
            Console.WriteLine("THANK YOU, GOOD BYE! :)");
        }

        internal static void PrintMessageOfVehicleTypes()
        {
            StringBuilder printedMessage = new StringBuilder();

            printedMessage.AppendLine("Please choose your type of vehicle: ");
            printedMessage.AppendLine("1. Fuel Motorcycle");
            printedMessage.AppendLine("2. Electric Motorcycle");
            printedMessage.AppendLine("3. Fuel Car");
            printedMessage.AppendLine("4. Electric Car");
            printedMessage.AppendLine("5. Truck");

            Console.WriteLine(printedMessage);
        }

        internal static void MessageForVehicleStatusSortOption()
        {
            StringBuilder printedMessage = new StringBuilder();

            printedMessage.AppendLine("Please enter vehicle status sort option: ");
            printedMessage.AppendLine("1. In repair");
            printedMessage.AppendLine("2. Fixed");
            printedMessage.AppendLine("3. Paid up");
            printedMessage.AppendLine("Press any other number for non sorted list of vehicles");

            Console.WriteLine(printedMessage);
        }

        internal static void PresentStatusOptions()
        {
            StringBuilder printedMessage = new StringBuilder();

            printedMessage.AppendLine("Please enter new vehicle status: ");
            printedMessage.AppendLine("1. In repair");
            printedMessage.AppendLine("2. Fixed");
            printedMessage.AppendLine("3. Paid up");

            Console.WriteLine(printedMessage);
        }

        internal static void PrintFuelTypesOptions()
        {
            StringBuilder printedMessage = new StringBuilder();

            printedMessage.AppendLine("Please enter fuel type");
            printedMessage.AppendLine("1. Soler");
            printedMessage.AppendLine("2. Octan95");
            printedMessage.AppendLine("3. Octan96");
            printedMessage.AppendLine("4. Octan98");
            Console.WriteLine(printedMessage);
        }

        internal static void PrintCorrectMessageWhenListIsEmpty(string correctMessage)
        {
            Console.WriteLine(correctMessage);
        }
    }
}
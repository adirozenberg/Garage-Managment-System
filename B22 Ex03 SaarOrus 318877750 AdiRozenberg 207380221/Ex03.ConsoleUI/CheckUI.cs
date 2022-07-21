using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class CheckUI
    {
        public static int                             CheckRangeAndFormatValidationForIntInput(int i_MinValue, int I_MaxValue)
        {
            int correctInput = 0;
            string chosenOption;
            bool checkInput = false;

            while (!checkInput)
            {
                try
                {
                    chosenOption = Console.ReadLine();
                    checkInput = Ex03.GarageLogic.CheckLogic.CheckIfIntInputAndInRange(chosenOption, out correctInput, i_MinValue, I_MaxValue);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return correctInput;
        }

        public static float                           CheckRangeAndFormatValidationForFloatInput(float i_MinValue, float I_MaxValue)
        {
            float correctInput = 0;
            string chosenOption;
            bool checkInput = false;

            while (!checkInput)
            {
                try
                {
                    chosenOption = Console.ReadLine();
                    checkInput = Ex03.GarageLogic.CheckLogic.CheckIfFloatInputAndInRange(chosenOption, out correctInput, i_MinValue, I_MaxValue);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return correctInput;
        }

        public static int                             CheckIfInputIsIntTypeAndPositive()
        {
            int correctInput = 0;
            bool checkInput = false;
            string userInput = null;

            while (!checkInput)
            {
                try
                {
                    userInput = Console.ReadLine();
                    correctInput = Ex03.GarageLogic.CheckLogic.CheckIfInputIsInt(userInput);
                    Ex03.GarageLogic.CheckLogic.IsInputPositiveInt(correctInput);
                    checkInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return correctInput;
        }

        public static string                          CheckIfAllCharactersAreLetters()
        {
            string correctInput = null;
            bool checkInput = false;
            string userInput = null;

            while (!checkInput)
            {
                try
                {
                    userInput = Console.ReadLine();
                    correctInput = Ex03.GarageLogic.CheckLogic.CheckIfInputIsOnlyLetters(userInput);
                    Ex03.GarageLogic.CheckLogic.IsEmptyString(correctInput);
                    checkInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return correctInput;
        }

        public static Ex03.GarageLogic.eVehicleStatus CheckProperTransitionBetweenVehicleStatuses(Ex03.GarageLogic.eVehicleStatus i_CurrentStatus, int i_MinValue, int i_MaxValue)
        {
            string checkedString = null;
            int nextStatus = 0;
            bool checkInput = false;
            Ex03.GarageLogic.eVehicleStatus correctNextStatus = 0;

            while (!checkInput)
            {
                try
                {
                    checkedString = Console.ReadLine();
                    Ex03.GarageLogic.CheckLogic.CheckIfIntInputAndInRange(checkedString, out nextStatus, i_MinValue, i_MaxValue);
                    correctNextStatus = (Ex03.GarageLogic.eVehicleStatus)nextStatus;
                    Ex03.GarageLogic.CheckLogic.CheckIfProperStatusTransition(i_CurrentStatus, correctNextStatus);
                    checkInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return correctNextStatus;
        }

        public static Ex03.GarageLogic.eFuelType      GetAndCheckVehicleFuelType(Ex03.GarageLogic.eFuelType i_CorrectFuelType)
        {
            string checkedNumber;
            Ex03.GarageLogic.eFuelType fuelTypeInput = 0;
            bool isFuelTypeValid = false;

            while (!isFuelTypeValid)
            {
                try
                {
                    checkedNumber = Console.ReadLine();
                    fuelTypeInput = (Ex03.GarageLogic.eFuelType)Ex03.GarageLogic.CheckLogic.CheckIfInputIsInt(checkedNumber);
                    Ex03.GarageLogic.CheckLogic.CheckValidFuelType(fuelTypeInput, i_CorrectFuelType);
                    isFuelTypeValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return fuelTypeInput;
        }

        public static Ex03.GarageLogic.Vehicle        FindAndCheckVehicle(List<Ex03.GarageLogic.Vehicle> i_ListOfVehicles, bool i_IsFuelEngine, bool i_IsElectricEngine)
        {
            bool isValidVehicle = false;
            Ex03.GarageLogic.Vehicle correctVehicle = null;

            while (!isValidVehicle)
            {
                try
                {
                    string licenseNumber = Console.ReadLine();
                    Ex03.GarageLogic.CheckLogic.CheckIfVehicleExistsInGarage(i_ListOfVehicles, out correctVehicle, licenseNumber);
                    if (i_IsFuelEngine)
                    {
                        Ex03.GarageLogic.CheckLogic.CheckValidFuelVehicle(correctVehicle);
                    }

                    if (i_IsElectricEngine)
                    {
                        Ex03.GarageLogic.CheckLogic.CheckValidElectricVehicle(correctVehicle);
                    }

                    isValidVehicle = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter new license number.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter new license number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter new license number.");
                }
            }

            return correctVehicle;
        }

        public static string                          CheckAndGetIfStringInputIsNotEmpty()
        {
            bool checkInput = false;
            string userInput = null;

            while (!checkInput)
            {
                try
                {
                    userInput = Console.ReadLine();
                    Ex03.GarageLogic.CheckLogic.IsEmptyString(userInput);
                    checkInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return userInput;
        }

        public static float                           CheckIfInputIsFloatTypeAndPositive()
        {
            float correctInput = 0;
            bool checkInput = false;
            string userInput = null;

            while (!checkInput)
            {
                try
                {
                    userInput = Console.ReadLine();
                    correctInput = Ex03.GarageLogic.CheckLogic.CheckIfInputIsFloat(userInput);
                    Ex03.GarageLogic.CheckLogic.IsInputPositiveFloat(correctInput);
                    checkInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return correctInput;
        }

        public static bool                            CheckIfInputStringIsYesOrNo()
        {
            bool checkInput = false;
            string userInput = null;

            while (!checkInput)
            {
                try
                {
                    userInput = Console.ReadLine();
                    checkInput = Ex03.GarageLogic.CheckLogic.CheckIfInputIsYesOrNo(userInput);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return userInput.Equals("YES");
        }
    }
}

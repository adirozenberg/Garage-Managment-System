using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CheckLogic
    {
        public static bool   CheckIfVehicleExistsInGarage(List<Vehicle> i_ListOfVehicles, out Vehicle io_FoundVehicle, string i_LicenseNumber)
        {
            bool isVehicleFound = false;
            io_FoundVehicle = null;

            foreach (Vehicle vehicle in i_ListOfVehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    io_FoundVehicle = vehicle;
                    isVehicleFound = true;
                }
            }

            if (!isVehicleFound)
            {
                throw new ArgumentException("INVALID INPUT - please enter a exist license number ");
            }

            return isVehicleFound;
        }

        public static int    CheckIfInputIsInt(string i_UserInput)
        {
            int intInputResult;

            if (!int.TryParse(i_UserInput, out intInputResult))
            {
                throw new FormatException("The entered number is not integer");
            }

            return intInputResult;
        }

        public static float  CheckIfInputIsFloat(string i_UserInput)
        {
            float floatInputResult;

            if (!float.TryParse(i_UserInput, out floatInputResult))
            {
                throw new FormatException("The entered number is not a decimal number");
            }

            return floatInputResult;
        }

        public static void   CheckValidFuelVehicle(Vehicle i_currentVehicle)
        {
            if (!(i_currentVehicle.EngineType is FuelEngine))
            {
                throw new ArgumentException("The vehicle has no fuel engine");
            }
        }

        public static void   CheckValidElectricVehicle(Vehicle i_currentVehicle)
        {
            if (!(i_currentVehicle.EngineType is ElectricEngine))
            {
                throw new ArgumentException("The vehicle has no electric engine");
            }
        }

        public static void   CheckValidFuelType(eFuelType i_FuelTypeInput, eFuelType i_FuelType)
        {
            if (i_FuelTypeInput != i_FuelType)
            {
                throw new ArgumentException(string.Format("Wrong Fuel Type, this engine runs on {0}, but you entered {1}", i_FuelType, i_FuelTypeInput));
            }
        }

        public static bool   CheckIfFloatInputAndInRange(string i_UserInput, out float io_CorrectFloatNumber, float i_MinValue, float i_MaxValue)
        {
            io_CorrectFloatNumber = CheckIfInputIsFloat(i_UserInput);

            if (!(io_CorrectFloatNumber >= i_MinValue && io_CorrectFloatNumber <= i_MaxValue))
            {
                throw new ValueOutOfRangeException(io_CorrectFloatNumber, i_MinValue, i_MaxValue);
            }

            return true;
        }

        public static bool   CheckIfIntInputAndInRange(string i_UserInput, out int io_CorrectIntNumber, int i_MinValue, int i_MaxValue)
        {
            io_CorrectIntNumber = CheckIfInputIsInt(i_UserInput);

            if (!(io_CorrectIntNumber >= i_MinValue && io_CorrectIntNumber <= i_MaxValue))
            {
                throw new ValueOutOfRangeException(io_CorrectIntNumber, i_MinValue, i_MaxValue);
            }

            return true;
        }

        public static bool   CheckIfProperStatusTransition(eVehicleStatus i_CurrentStatus, eVehicleStatus i_NextStatus)
        {
            if (!((i_CurrentStatus == eVehicleStatus.InRepair && i_NextStatus == eVehicleStatus.Fixed) ||
                (i_CurrentStatus == eVehicleStatus.Fixed && i_NextStatus == eVehicleStatus.PaidUp)))
            {
                throw new ArgumentException("Wrong Transition between statuses.");
            }

            return true;
        }

        public static string CheckIfInputIsOnlyLetters(string i_UserInput)
        {
            foreach (char c in i_UserInput)
            {
                if (!char.IsLetter(c))
                {
                    throw new FormatException("The string doesn't contain only letters.");
                }
            }

            return i_UserInput;
        }

        public static bool   IsEmptyString(string i_UserInput)
        {
            if (string.IsNullOrEmpty(i_UserInput))
            {
                throw new FormatException("The string is empty.");
            }

            return true;
        }

        public static bool   IsInputPositiveInt(int i_CheckInt)
        {
            if (i_CheckInt < 0)
            {
                throw new FormatException("The number is negative.");
            }

            return true;
        }

        public static bool   IsInputPositiveFloat(float i_CheckFloat)
        {
            if (i_CheckFloat < 0)
            {
                throw new FormatException("The number is negative.");
            }

            return true;
        }

        public static bool   CheckIfInputIsYesOrNo(string i_UserInput)
        {
            if (!i_UserInput.Equals("YES") && !i_UserInput.Equals("NO"))
            {
                throw new FormatException("The input is not YES or NO.");
            }

            return true;
        }
    }
}

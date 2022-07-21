using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public enum eMenuOption
    {
        AddVehicle = 1,
        PresentVehicles,
        ChangeStatus,
        InflateAir,
        Refuel,
        Recharge,
        PresentDetails,
        Exit
    }

    public class GarageMenu
    {
        private readonly Ex03.GarageLogic.GarageSystem r_GarageSystem;
        private readonly Ex03.GarageLogic.VehicleFactory r_VehicleFactory;
        private bool m_ExitGarageSystem, m_ListOfFuelEngineIsEmpty, m_ListOfElectricEngineIsEmpty;

        public GarageMenu()
        {
            r_GarageSystem = new Ex03.GarageLogic.GarageSystem();
            r_VehicleFactory = new Ex03.GarageLogic.VehicleFactory();
            m_ExitGarageSystem = false;
            m_ListOfElectricEngineIsEmpty = true;
            m_ListOfFuelEngineIsEmpty = true;
        }

        public void RunGarage()
        {
            int chosenOption;

            while (!m_ExitGarageSystem)
            {
                Messages.PrintWelcomeMassage();
                Messages.PresentMainMenuOptions();
                CheckIfListOfVehiclesIsEmptyByEngineType();
                chosenOption = CheckUI.CheckRangeAndFormatValidationForIntInput(1, 8);

                switch (chosenOption)
                {
                    case (int)eMenuOption.AddVehicle:
                        AddVehicleIfNew();
                        break;
                    case (int)eMenuOption.PresentVehicles:
                        if (!CheckAndPrintIfTheGarageIsEmpty())
                        {
                            PresentAllOrSortedVehicles();
                        }

                        break;
                    case (int)eMenuOption.ChangeStatus:
                        if (!CheckAndPrintIfTheGarageIsEmpty())
                        {
                            ChangeVehicleStatus();
                        }

                        break;
                    case (int)eMenuOption.InflateAir:
                        if (!CheckAndPrintIfTheGarageIsEmpty())
                        {
                            InflatingWheels();
                        }

                        break;
                    case (int)eMenuOption.Refuel:
                        if (!CheckAndPrintIfThereIsNoFuelEngine())
                        {
                            RefuelingVehicle();
                        }

                        break;
                    case (int)eMenuOption.Recharge:
                        if (!CheckAndPrintIfThereIsNoElectricEngine())
                        {
                            ChargingVehicle();
                        }

                        break;
                    case (int)eMenuOption.PresentDetails:
                        if (!CheckAndPrintIfTheGarageIsEmpty())
                        {
                            PresentFullDetails();
                        }

                        break;
                    case (int)eMenuOption.Exit:
                        m_ExitGarageSystem = true;
                        break;
                }

                if (!m_ExitGarageSystem)
                {
                    Messages.PrintReturnToMenuMassage();
                    Console.ReadLine();
                }

                Console.Clear();
            }

            // exit was entered
            Messages.PrintMessageGoodBye();
        }

        public void AddVehicleIfNew()
        {
            Ex03.GarageLogic.Vehicle newVehicleToAdd, exsitsVehicle;
            string modelName, chosenOwnerName, licenseNumber;
            int chosenOwnerPhoneNumber;
            Ex03.GarageLogic.eVehicleType chosenTypeVehicle;

            Console.WriteLine("Please enter license number.");
            licenseNumber = CheckUI.CheckAndGetIfStringInputIsNotEmpty();

            if (!r_GarageSystem.CheckIfVehicleInGarage(licenseNumber, out exsitsVehicle))
            {
                Messages.PrintMessageOfVehicleTypes();
                chosenTypeVehicle = (Ex03.GarageLogic.eVehicleType)CheckUI.CheckRangeAndFormatValidationForIntInput(1, 5);

                Console.WriteLine("Please enter model name");
                modelName = CheckUI.CheckAndGetIfStringInputIsNotEmpty();

                Console.WriteLine("Please enter your private name");
                chosenOwnerName = CheckUI.CheckIfAllCharactersAreLetters();

                Console.WriteLine("Please enter your phone number (only digits) ");
                chosenOwnerPhoneNumber = CheckUI.CheckIfInputIsIntTypeAndPositive();

                Ex03.GarageLogic.VehicleOwnerDetails ownerDetails = new Ex03.GarageLogic.VehicleOwnerDetails(chosenOwnerName, chosenOwnerPhoneNumber);

                newVehicleToAdd = r_VehicleFactory.CreateNewVehicle(chosenTypeVehicle, licenseNumber, modelName, ownerDetails);

                CheckTypeOfVehicleAndGetDetails(chosenTypeVehicle, newVehicleToAdd);

                CheckEngineAndGetDetails(chosenTypeVehicle, newVehicleToAdd);

                CheckAndGetWheelsDetails(chosenTypeVehicle, newVehicleToAdd);

                // once we have all correct details of vehicle, add it to vehicles ing garage list
                r_GarageSystem.VehiclesInGarage.Add(newVehicleToAdd);
            }
            else
            {
                Console.WriteLine("The vehicle with the license number " + licenseNumber + " is already exists");
                exsitsVehicle.VehicleStatus = Ex03.GarageLogic.eVehicleStatus.InRepair;
            }
        }

        public void CheckEngineAndGetDetails(Ex03.GarageLogic.eVehicleType i_ChosenTypeVehicle, Ex03.GarageLogic.Vehicle i_NewVehicleToAdd)
        {
            switch (i_ChosenTypeVehicle)
            {
                case Ex03.GarageLogic.eVehicleType.FuelMotorcycle:
                    UpdateFuelEngineDetails(Ex03.GarageLogic.VehicleFactory.k_MaxAmountOfFuelInLitersMotorcycle, i_NewVehicleToAdd);
                    break;

                case Ex03.GarageLogic.eVehicleType.ElectricMotorcycle:
                    UpdateElectricEngineDetails(Ex03.GarageLogic.VehicleFactory.k_MaxBatteryTimeInHoursMotorcycle, i_NewVehicleToAdd);
                    break;

                case Ex03.GarageLogic.eVehicleType.FuelCar:
                    UpdateFuelEngineDetails(Ex03.GarageLogic.VehicleFactory.k_MaxAmountOfFuelInLitersCar, i_NewVehicleToAdd);
                    break;

                case Ex03.GarageLogic.eVehicleType.ElectricCar:
                    UpdateElectricEngineDetails(Ex03.GarageLogic.VehicleFactory.k_MaxBatteryTimeInHoursCar, i_NewVehicleToAdd);
                    break;

                case Ex03.GarageLogic.eVehicleType.Truck:
                    UpdateFuelEngineDetails(Ex03.GarageLogic.VehicleFactory.k_MaxAmountOfFuelInLitersTruck, i_NewVehicleToAdd);
                    break;
            }
        }

        public void UpdateFuelEngineDetails(float i_MaxCurrentAmountOfFuel, Ex03.GarageLogic.Vehicle io_NewVehicleToAdd)
        {
            float currentAmountOfFuelInLiters;

            Console.WriteLine("Please enter current amount of fuel in liters");
            currentAmountOfFuelInLiters = CheckUI.CheckRangeAndFormatValidationForFloatInput(0, i_MaxCurrentAmountOfFuel);
            Ex03.GarageLogic.FuelEngine fuelEngineVehicle = io_NewVehicleToAdd.EngineType as Ex03.GarageLogic.FuelEngine;
            fuelEngineVehicle.CurrentAmountOfFuelInLiters = currentAmountOfFuelInLiters;
        }

        public void UpdateElectricEngineDetails(float i_MaxBatteryTime, Ex03.GarageLogic.Vehicle io_NewVehicleToAdd)
        {
            float remainingBatteryTimeInHours;
            Console.WriteLine("Please enter remaining battery time in hours");
            remainingBatteryTimeInHours = CheckUI.CheckRangeAndFormatValidationForFloatInput(0, i_MaxBatteryTime);

            Ex03.GarageLogic.ElectricEngine electricEngineVehicle = io_NewVehicleToAdd.EngineType as Ex03.GarageLogic.ElectricEngine;
            electricEngineVehicle.RemainingBatteryTimeInHours = remainingBatteryTimeInHours;
        }

        public void CheckAndGetWheelsDetails(Ex03.GarageLogic.eVehicleType i_ChosenTypeVehicle, Ex03.GarageLogic.Vehicle io_NewVehicleToAdd)
        {
            string manufacturerName = null;
            float currentAirPressure = 0;

            Console.WriteLine("Please enter all wheel's manufacturer name");
            manufacturerName = CheckUI.CheckIfAllCharactersAreLetters();

            Console.WriteLine("Please enter all wheel's current air pressure");

            switch (i_ChosenTypeVehicle)
            {
                /// motorcycle
                case Ex03.GarageLogic.eVehicleType.FuelMotorcycle:
                case Ex03.GarageLogic.eVehicleType.ElectricMotorcycle:
                    currentAirPressure = CheckUI.CheckRangeAndFormatValidationForFloatInput(0, 31f);
                    break;
                /// car
                case Ex03.GarageLogic.eVehicleType.FuelCar:
                case Ex03.GarageLogic.eVehicleType.ElectricCar:
                    currentAirPressure = CheckUI.CheckRangeAndFormatValidationForFloatInput(0, 29f);
                    break;
                /// truck
                case Ex03.GarageLogic.eVehicleType.Truck:
                    currentAirPressure = CheckUI.CheckRangeAndFormatValidationForFloatInput(0, 24f);
                    break;
            }

            foreach (Ex03.GarageLogic.Wheel wheel in io_NewVehicleToAdd.CollectionOfWheels)
            {
                wheel.CurrentAirPressure = currentAirPressure;
                wheel.ManufacturerName = manufacturerName;
            }
        }

        public void CheckTypeOfVehicleAndGetDetails(Ex03.GarageLogic.eVehicleType i_ChosenTypeVehicle, Ex03.GarageLogic.Vehicle i_NewVehicleToAdd)
        {
            switch (i_ChosenTypeVehicle)
            {
                /// motorcycle
                case Ex03.GarageLogic.eVehicleType.FuelMotorcycle:
                case Ex03.GarageLogic.eVehicleType.ElectricMotorcycle:
                    GetLicenseTypeAndEngineVolumeOfMotorcycle(i_NewVehicleToAdd);
                    break;
                /// car
                case Ex03.GarageLogic.eVehicleType.FuelCar:
                case Ex03.GarageLogic.eVehicleType.ElectricCar:
                    GetColorAndDoorsAmountOfCar(i_NewVehicleToAdd);
                    break;
                /// truck
                case Ex03.GarageLogic.eVehicleType.Truck:
                    GetCargoVolumAndRefrigeratedDetailsOfTruck(i_NewVehicleToAdd);
                    break;
            }
        }

        public void GetLicenseTypeAndEngineVolumeOfMotorcycle(Ex03.GarageLogic.Vehicle io_NewVehicleToAdd)
        {
            Ex03.GarageLogic.eLicenseType licenseType;
            int engineVolumeInCC;

            Console.WriteLine("Please enter license type: ");
            Console.WriteLine("1. A" + '\n' + "2. A1" + '\n' + "3. B1" + '\n' + "4. BB");
            licenseType = (Ex03.GarageLogic.eLicenseType)CheckUI.CheckRangeAndFormatValidationForIntInput(1, 4);

            Console.WriteLine("Please enter engine volume in cc");
            engineVolumeInCC = CheckUI.CheckIfInputIsIntTypeAndPositive();

            Ex03.GarageLogic.Motorcycle motorcycle = io_NewVehicleToAdd as Ex03.GarageLogic.Motorcycle;
            motorcycle.LicenseType = licenseType;
            motorcycle.EngineVolumeInCC = engineVolumeInCC;
        }

        public void GetColorAndDoorsAmountOfCar(Ex03.GarageLogic.Vehicle io_NewVehicleToAdd)
        {
            Ex03.GarageLogic.eCarColor carColor;
            Ex03.GarageLogic.eDoorsAmount amountOfDoors;

            Console.WriteLine("Please enter car color: ");
            Console.WriteLine("1. Red" + '\n' + "2. White" + '\n' + "3. Green" + '\n' + "4. Blue");
            carColor = (Ex03.GarageLogic.eCarColor)CheckUI.CheckRangeAndFormatValidationForIntInput(1, 4);

            Console.WriteLine("Please enter amount of doors in car (2,3,4 or 5)");
            amountOfDoors = (Ex03.GarageLogic.eDoorsAmount)CheckUI.CheckRangeAndFormatValidationForIntInput(2, 5);

            Ex03.GarageLogic.Car car = io_NewVehicleToAdd as Ex03.GarageLogic.Car;
            car.CarColor = carColor;
            car.AmountOfDoorsInCar = amountOfDoors;
        }

        public void GetCargoVolumAndRefrigeratedDetailsOfTruck(Ex03.GarageLogic.Vehicle io_NewVehicleToAdd)
        {
            float cargoVolume;
            bool isDrivesRefrigeratedContents;

            Console.WriteLine("Please enter if drives refrigerated contents ('YES' or 'NO')");
            isDrivesRefrigeratedContents = CheckUI.CheckIfInputStringIsYesOrNo();

            Console.WriteLine("Please enter cargo volume ");
            cargoVolume = CheckUI.CheckIfInputIsFloatTypeAndPositive();

            Ex03.GarageLogic.Truck truck = io_NewVehicleToAdd as Ex03.GarageLogic.Truck;
            truck.DrivesRefrigeratedContents = isDrivesRefrigeratedContents;
            truck.CargoVolume = cargoVolume;
        }

        public void PresentAllOrSortedVehicles()
        {
            int chosenSortOption;
            StringBuilder listOfVehicles;

            Messages.MessageForVehicleStatusSortOption();
            chosenSortOption = CheckUI.CheckIfInputIsIntTypeAndPositive();
            listOfVehicles = r_GarageSystem.CreateListOfLicenseNumberInGarage(chosenSortOption);
            Console.WriteLine(listOfVehicles);
        }

        public void ChangeVehicleStatus()
        {
            Ex03.GarageLogic.Vehicle vehicleToChange;
            Ex03.GarageLogic.eVehicleStatus currentVehicleStatus = 0, newVehicleStatus = 0;

            Console.WriteLine("Please enter license number.");
            vehicleToChange = CheckUI.FindAndCheckVehicle(r_GarageSystem.VehiclesInGarage, false, false);
            Messages.PresentStatusOptions();
            currentVehicleStatus = vehicleToChange.VehicleStatus;
            newVehicleStatus = CheckUI.CheckProperTransitionBetweenVehicleStatuses(currentVehicleStatus, 1, 3);
            r_GarageSystem.ChangeStatusOfVehicleInGarage(vehicleToChange, (Ex03.GarageLogic.eVehicleStatus)newVehicleStatus);
        }

        public void InflatingWheels()
        {
            Ex03.GarageLogic.Vehicle currentVehicle;

            Console.WriteLine("Please enter license number.");
            currentVehicle = CheckUI.FindAndCheckVehicle(r_GarageSystem.VehiclesInGarage, false, false);
            r_GarageSystem.InflatingWheelsOfVehicleToMaximum(currentVehicle);
        }

        public void RefuelingVehicle()
        {
            Ex03.GarageLogic.Vehicle currentVehicle;
            Ex03.GarageLogic.eFuelType correctFuelType;
            Ex03.GarageLogic.FuelEngine currentFuelEngine;
            float amountOfFuelToFill, maxAmountOfFuelToFill = 0;

            Console.WriteLine("Please enter license number.");
            currentVehicle = CheckUI.FindAndCheckVehicle(r_GarageSystem.VehiclesInGarage, true, false);
            currentFuelEngine = currentVehicle.EngineType as Ex03.GarageLogic.FuelEngine;
            Messages.PrintFuelTypesOptions();
            correctFuelType = CheckUI.GetAndCheckVehicleFuelType(currentFuelEngine.FuelType);
            maxAmountOfFuelToFill = currentFuelEngine.MaxAmountOfFuelInLiters - currentFuelEngine.CurrentAmountOfFuelInLiters;
            Console.WriteLine("Please enter amount of fuel to fill");
            amountOfFuelToFill = CheckUI.CheckRangeAndFormatValidationForFloatInput(0, maxAmountOfFuelToFill);
            r_GarageSystem.RefuelingRegularVehicle(currentFuelEngine, amountOfFuelToFill);
        }

        public void CheckIfListOfVehiclesIsEmptyByEngineType()
        {
            foreach (Ex03.GarageLogic.Vehicle vehicle in r_GarageSystem.VehiclesInGarage)
            {
                if (vehicle.EngineType is Ex03.GarageLogic.FuelEngine)
                {
                    m_ListOfFuelEngineIsEmpty = false;
                }

                if (vehicle.EngineType is Ex03.GarageLogic.ElectricEngine)
                {
                    m_ListOfElectricEngineIsEmpty = false;
                }
            }
        }

        public void ChargingVehicle()
        {
            Ex03.GarageLogic.Vehicle currentVehicle;
            Ex03.GarageLogic.ElectricEngine currentElectricEngine;
            float amountOfMinutesToFill;

            Console.WriteLine("Please enter license number.");
            currentVehicle = CheckUI.FindAndCheckVehicle(r_GarageSystem.VehiclesInGarage, false, true);
            currentElectricEngine = currentVehicle.EngineType as Ex03.GarageLogic.ElectricEngine;
            Console.WriteLine("Please enter amount of minutes to fill");
            amountOfMinutesToFill = CheckUI.CheckRangeAndFormatValidationForFloatInput(0, currentElectricEngine.RemainingBatteryTimeInHours);
            r_GarageSystem.ChargingElectricVehicle(currentElectricEngine, amountOfMinutesToFill);
        }

        public void PresentFullDetails()
        {
            Ex03.GarageLogic.Vehicle currentVehicle = null;
            StringBuilder printedMessage;

            Console.WriteLine("Please enter license number.");
            currentVehicle = CheckUI.FindAndCheckVehicle(r_GarageSystem.VehiclesInGarage, false, false);
            printedMessage = r_GarageSystem.PresentFullDetailsOfVehicle(currentVehicle);
            Console.WriteLine(printedMessage);
        }

        public bool CheckAndPrintIfTheGarageIsEmpty()
        {
            bool isGarageEmpty = false;

            if (m_ListOfElectricEngineIsEmpty && m_ListOfFuelEngineIsEmpty)
            {
                Messages.PrintCorrectMessageWhenListIsEmpty("THERE ARE NO VEHICLES IN THE GARAGE!");
                isGarageEmpty = true;
            }

            return isGarageEmpty;
        }

        public bool CheckAndPrintIfThereIsNoFuelEngine()
        {
            if (m_ListOfFuelEngineIsEmpty)
            {
                Messages.PrintCorrectMessageWhenListIsEmpty("THERE ARE NO FUEL ENGINE VEHICLES IN THE GARAGE!");
            }

            return m_ListOfElectricEngineIsEmpty;
        }

        public bool CheckAndPrintIfThereIsNoElectricEngine()
        {
            if (m_ListOfElectricEngineIsEmpty)
            {
                Messages.PrintCorrectMessageWhenListIsEmpty("THERE ARE NO ELECTRIC ENGINE VEHICLES IN THE GARAGE!");
            }

            return m_ListOfElectricEngineIsEmpty;
        }
    }
}

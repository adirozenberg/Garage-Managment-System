using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageSystem
    {
        private List<Vehicle> m_VehiclesInGarage;

        public List<Vehicle> VehiclesInGarage
        {
            get { return m_VehiclesInGarage; }
            set { m_VehiclesInGarage = value; }
        }

        public GarageSystem()
        {
            m_VehiclesInGarage = new List<Vehicle>();
        }

        public bool          CheckIfVehicleInGarage(string i_LicenseNumber, out Vehicle io_FoundVehicle)
        {
            bool alreadyExistsInGarage = false;
            io_FoundVehicle = null;

            foreach (Vehicle vehicle in m_VehiclesInGarage)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    io_FoundVehicle = vehicle;
                    alreadyExistsInGarage = true;
                }
            }

            return alreadyExistsInGarage;
        }

        public StringBuilder CreateListOfLicenseNumberInGarage(int i_EnteredStatusToSortVehicles)
        {
            StringBuilder collectionOfVehicles = new StringBuilder();

            if (IsSortOptionExists(i_EnteredStatusToSortVehicles))
            {
                foreach (Vehicle vehicle in m_VehiclesInGarage)
                {
                    if ((int)vehicle.VehicleStatus == i_EnteredStatusToSortVehicles)
                    {
                        collectionOfVehicles.AppendLine(vehicle.LicenseNumber);
                    }
                }
            }
            else
            {
                foreach (Vehicle vehicle in m_VehiclesInGarage)
                {
                    collectionOfVehicles.AppendLine(vehicle.LicenseNumber);
                }
            }

            return collectionOfVehicles;
        }

        public bool          IsSortOptionExists(int i_EnteredStatusToSortVehicles)
        {
            bool existsSortedOption = false;

            if (i_EnteredStatusToSortVehicles == (int)eVehicleStatus.InRepair || i_EnteredStatusToSortVehicles == (int)eVehicleStatus.Fixed || i_EnteredStatusToSortVehicles == (int)eVehicleStatus.PaidUp)
            {
                existsSortedOption = true;
            }

            return existsSortedOption;
        }

        public void          ChangeStatusOfVehicleInGarage(Vehicle io_VehicleToChange, eVehicleStatus i_NewVehicleStatus)
        {
            io_VehicleToChange.VehicleStatus = i_NewVehicleStatus;
        }

        public void          InflatingWheelsOfVehicleToMaximum(Vehicle io_VehicleToChange)
        {
            foreach (Wheel wheel in io_VehicleToChange.CollectionOfWheels)
            {
                wheel.WheelInflation(wheel.MaximunAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void          RefuelingRegularVehicle(FuelEngine io_FuelEngine, float i_AmountOfFuelToFill)
        {
            io_FuelEngine.Refueling(i_AmountOfFuelToFill);
        }

        public void          ChargingElectricVehicle(ElectricEngine io_ElectricEngine, float i_AmountOfMinutesToFill)
        {
            io_ElectricEngine.BatteryCharging(i_AmountOfMinutesToFill);
        }

        public StringBuilder PresentFullDetailsOfVehicle(Vehicle i_CurrentVehicle)
        {
            StringBuilder printedMessage = new StringBuilder();
            /// mutual details of vehicles
            printedMessage.AppendLine("Details of vehicle with " + i_CurrentVehicle.LicenseNumber + " license number");
            printedMessage.AppendLine("ModelName: " + i_CurrentVehicle.ModelName);
            printedMessage.AppendLine("Owners Name: " + i_CurrentVehicle.VehicleOwner.OwnerName);
            printedMessage.AppendLine("Status in garage:  " + i_CurrentVehicle.VehicleStatus);
            printedMessage.AppendLine("Air pressure in all wheels: " + i_CurrentVehicle.CollectionOfWheels[0].CurrentAirPressure + " and manufacturer of wheels: " + i_CurrentVehicle.CollectionOfWheels[0].ManufacturerName);
            
            if (i_CurrentVehicle.EngineType is FuelEngine) 
            {   
                FuelEngine fuelEngine = i_CurrentVehicle.EngineType as FuelEngine;
                printedMessage.AppendLine("Status of fuel: " + fuelEngine.CurrentAmountOfFuelInLiters);
                printedMessage.AppendLine("Fuel type: " + fuelEngine.FuelType);
            }           
            else 
            {   
                ElectricEngine electricEngine = i_CurrentVehicle.EngineType as ElectricEngine;
                printedMessage.AppendLine("Status of battery: " + electricEngine.RemainingBatteryTimeInHours);
            }

            if (i_CurrentVehicle is Car) 
            {  
                Car car = i_CurrentVehicle as Car;
                printedMessage.AppendLine("Car color: " + car.CarColor);
                printedMessage.AppendLine("Amount of doors: " + car.AmountOfDoorsInCar);
            }
            else if (i_CurrentVehicle is Motorcycle)
            {   
                Motorcycle motorcycle = i_CurrentVehicle as Motorcycle;
                printedMessage.AppendLine("License type: " + motorcycle.LicenseType);
                printedMessage.AppendLine("Engine volume in cc: " + motorcycle.EngineVolumeInCC);
            }
            else 
            {   
                Truck truck = i_CurrentVehicle as Truck;
                printedMessage.AppendLine("Is drives refrigerated contents: " + truck.DrivesRefrigeratedContents);
                printedMessage.AppendLine("Cargo volume: " + truck.CargoVolume);
            }

            return printedMessage;
        }
    }
}

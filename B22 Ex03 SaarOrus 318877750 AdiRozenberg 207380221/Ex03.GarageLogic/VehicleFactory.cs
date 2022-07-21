using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleType
    {
        FuelMotorcycle = 1,
        ElectricMotorcycle,
        FuelCar,
        ElectricCar,
        Truck
    }

    public class VehicleFactory
    {
        /// motorcycle
        private const int k_NumOfWheelsOfMotorcycle = 2;
        private const float k_MaxAirPressureMotorcycle = 31f;
        public const float k_MaxAmountOfFuelInLitersMotorcycle = 6.2f;
        public const float k_MaxBatteryTimeInHoursMotorcycle = 2.5f;

        /// car
        private const int k_NumOfWheelsOfCar = 4;
        private const float k_MaxAirPressureCar = 29f;
        public const float k_MaxAmountOfFuelInLitersCar = 38f;
        public const float k_MaxBatteryTimeInHoursCar = 3.3f;

        /// truck
        private const int k_NumOfWheelsOfTruck = 16;
        private const float k_MaxAirPressureTruck = 24f;
        public const float k_MaxAmountOfFuelInLitersTruck = 120f;

        public Vehicle CreateNewVehicle(eVehicleType i_VehicleType, string i_LicenseNumber, string i_ModelName, VehicleOwnerDetails i_OwnerDetails)
        {
            Vehicle newVehicle = null;
            Engine newEngine;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    newEngine = new FuelEngine(eFuelType.Octan98, k_MaxAmountOfFuelInLitersMotorcycle);
                    newVehicle = new Motorcycle(i_LicenseNumber, i_ModelName, newEngine, i_OwnerDetails, k_NumOfWheelsOfMotorcycle, k_MaxAirPressureMotorcycle);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newEngine = new ElectricEngine(k_MaxBatteryTimeInHoursMotorcycle);
                    newVehicle = new Motorcycle(i_LicenseNumber, i_ModelName, newEngine, i_OwnerDetails, k_NumOfWheelsOfMotorcycle, k_MaxAirPressureMotorcycle);
                    break;
                case eVehicleType.FuelCar:
                    newEngine = new FuelEngine(eFuelType.Octan95, k_MaxAmountOfFuelInLitersCar);
                    newVehicle = new Car(i_LicenseNumber, i_ModelName, newEngine, i_OwnerDetails, k_NumOfWheelsOfCar, k_MaxAirPressureCar);
                    break;
                case eVehicleType.ElectricCar:
                    newEngine = new ElectricEngine(k_MaxBatteryTimeInHoursCar);
                    newVehicle = new Car(i_LicenseNumber, i_ModelName, newEngine, i_OwnerDetails, k_NumOfWheelsOfCar, k_MaxAirPressureCar);
                    break;
                case eVehicleType.Truck:
                    newEngine = new FuelEngine(eFuelType.Soler, k_MaxAmountOfFuelInLitersTruck);
                    newVehicle = new Truck(i_LicenseNumber, i_ModelName, newEngine, i_OwnerDetails, k_NumOfWheelsOfTruck, k_MaxAirPressureTruck);
                    break;
            }

            return newVehicle;
        }
    }
}
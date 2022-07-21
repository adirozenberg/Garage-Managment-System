using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDrivesRefrigeratedContents; 
        private float m_CargoVolume;

        public bool DrivesRefrigeratedContents
        {
            get { return m_IsDrivesRefrigeratedContents; }
            set { m_IsDrivesRefrigeratedContents = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public Truck(string i_LicenseNumber, string i_ModelName, Engine i_EngineType, VehicleOwnerDetails i_OwnerDetails, int i_NumOfWheels, float i_MaximunAirPressure) : base(i_LicenseNumber, i_ModelName, i_EngineType, i_OwnerDetails, i_NumOfWheels, i_MaximunAirPressure)
        {
        }
    }
}
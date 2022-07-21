using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A = 1,
        A1,
        B1,
        BB
    }

    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolumeInCC;

        public Motorcycle(string i_LicenseNumber, string i_ModelName, Engine i_EngineType, VehicleOwnerDetails i_OwnerDetails, int i_NumOfWheels, float i_MaximunAirPressure) : base(i_LicenseNumber, i_ModelName, i_EngineType, i_OwnerDetails, i_NumOfWheels, i_MaximunAirPressure)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolumeInCC
        {
            get { return m_EngineVolumeInCC; }
            set { m_EngineVolumeInCC = value; }
        }
    }
}

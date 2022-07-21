using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InRepair = 1,
        Fixed,
        PaidUp
    }

    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_CollectionOfWheels;
        private VehicleOwnerDetails m_VehicleOwner;
        private Engine m_EngineType;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle(string i_LicenseNumber, string i_ModelName, Engine i_EngineType, VehicleOwnerDetails i_OwnerDetails, int i_NumOfWheels, float i_MaximunAirPressure)
        {
            r_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_CollectionOfWheels = new List<Wheel>();

            AddWheelsToCollection(i_NumOfWheels, i_MaximunAirPressure);

            m_EngineType = i_EngineType;
            m_VehicleOwner = i_OwnerDetails;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public void AddWheelsToCollection(int i_NumOfWheels, float i_MaximunAirPressure)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(i_MaximunAirPressure);
                m_CollectionOfWheels.Add(newWheel);
            }
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public VehicleOwnerDetails VehicleOwner
        {
            get { return m_VehicleOwner; }
            set { m_VehicleOwner = value; }
        }

        public Engine EngineType
        {
            get { return m_EngineType; }
            set { m_EngineType = value; }
        }

        public List<Wheel> CollectionOfWheels
        {
            get { return m_CollectionOfWheels; }
            set { m_CollectionOfWheels = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }
    }
}

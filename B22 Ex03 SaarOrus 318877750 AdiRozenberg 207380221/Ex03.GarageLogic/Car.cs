using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eCarColor
    {
        Red = 1,
        White,
        Green,
        Blue
    }

    public enum eDoorsAmount
    {
        Two = 2,
        Three,
        Four,
        Five
    }

    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorsAmount m_AmountOfDoorsInCar;

        public eCarColor CarColor 
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eDoorsAmount AmountOfDoorsInCar
        {
            get { return m_AmountOfDoorsInCar; }
            set { m_AmountOfDoorsInCar = value; }
        }

        public Car(string i_LicenseNumber, string i_ModelName, Engine i_EngineType, VehicleOwnerDetails i_OwnerDetails, int i_NumOfWheels, float i_MaximunAirPressure) : base(i_LicenseNumber, i_ModelName, i_EngineType, i_OwnerDetails, i_NumOfWheels, i_MaximunAirPressure)
        {
        }        
    }
}

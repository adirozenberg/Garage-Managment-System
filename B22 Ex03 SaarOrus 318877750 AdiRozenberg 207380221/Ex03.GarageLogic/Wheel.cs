using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaximunAirPressure;

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaximunAirPressure
        {
            get { return m_MaximunAirPressure; }
            set { m_MaximunAirPressure = value; }
        }

        public Wheel(float maximunAirPressure)
        {
            m_MaximunAirPressure = maximunAirPressure;
        }

        public void WheelInflation(float i_AmountOfAirToAdd)
        {
            m_CurrentAirPressure += i_AmountOfAirToAdd;
        }
    }
}
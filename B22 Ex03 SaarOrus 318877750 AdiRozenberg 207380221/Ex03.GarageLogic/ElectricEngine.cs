using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private readonly float r_MaxBatteryTimeInHours;
        private float m_RemainingBatteryTimeInHours;       

        public ElectricEngine(float i_MaxBatteryTimeInHours)
        {
            r_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
        }

        public float RemainingBatteryTimeInHours
        {
            get { return m_RemainingBatteryTimeInHours; }
            set { m_RemainingBatteryTimeInHours = value; }
        }

        public float MaxBatteryTimeInHours
        {
            get { return r_MaxBatteryTimeInHours; }
        }

        public void  BatteryCharging(float i_AmountOfBatteryTimeInHoursToAdd)
        {
            m_RemainingBatteryTimeInHours += i_AmountOfBatteryTimeInHoursToAdd;
            CalculateAndUpdateEnergyPercentage(m_RemainingBatteryTimeInHours, r_MaxBatteryTimeInHours);
        }
    }
}

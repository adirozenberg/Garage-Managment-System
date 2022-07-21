using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler = 1,
        Octan95,
        Octan96,
        Octan98
    }

    public class FuelEngine : Engine
    {
        private readonly float r_MaxAmountOfFuelInLiters;
        private readonly eFuelType r_FuelType;
        private float m_CurrentAmountOfFuelInLiters;

        public FuelEngine(eFuelType i_FuelType, float i_MaxAmountOfFuelInLiters)
        {
            r_FuelType = i_FuelType;
            r_MaxAmountOfFuelInLiters = i_MaxAmountOfFuelInLiters;
        }

        public float CurrentAmountOfFuelInLiters
        {
            get { return m_CurrentAmountOfFuelInLiters; }
            set { m_CurrentAmountOfFuelInLiters = value; }
        }

        public float MaxAmountOfFuelInLiters
        {
            get { return r_MaxAmountOfFuelInLiters; }
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void Refueling(float i_AmountOfLitersToAdd)
        {
            m_CurrentAmountOfFuelInLiters += i_AmountOfLitersToAdd;
            CalculateAndUpdateEnergyPercentage(m_CurrentAmountOfFuelInLiters, r_MaxAmountOfFuelInLiters);
        }
    }
}

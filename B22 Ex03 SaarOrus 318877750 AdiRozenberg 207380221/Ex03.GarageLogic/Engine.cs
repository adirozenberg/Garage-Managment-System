using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_LeftPercentageOfEnergyInSource;

        public float LeftPercentageOfEnergyInSource
        {
            get { return m_LeftPercentageOfEnergyInSource; }
            set { m_LeftPercentageOfEnergyInSource = value; }
        }

        public void CalculateAndUpdateEnergyPercentage(float i_CurrentAmountOfEnergy, float i_MaxAmountOfEnergy)
        {
            m_LeftPercentageOfEnergyInSource = (i_CurrentAmountOfEnergy / i_MaxAmountOfEnergy) * 100;
        }
    }
}

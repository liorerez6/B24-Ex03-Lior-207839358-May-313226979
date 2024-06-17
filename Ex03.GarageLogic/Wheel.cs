using System;

namespace Ex03.GameLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_MaxAirPressureByManufacturer;
        private float m_CurrentAirPressure;

        //CTOR
        public Wheel(string i_ManufacturerName, float i_MaxAirPressureByManufacturer, string i_CurrentAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;

            float currentAirPressure = float.Parse(i_CurrentAirPressure);
            if(currentAirPressure > m_MaxAirPressureByManufacturer)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressureByManufacturer - m_CurrentAirPressure, $"Cannot inflate beyond the maximum pressure of {m_MaxAirPressureByManufacturer}");
            }
            else
            {
                m_CurrentAirPressure = currentAirPressure;
            }
        }

        public Wheel(Wheel i_CopyWheel)
        {
            m_CurrentAirPressure = i_CopyWheel.CurrentAirPressure;
            m_ManufacturerName = i_CopyWheel.m_ManufacturerName;
            m_MaxAirPressureByManufacturer = i_CopyWheel.m_MaxAirPressureByManufacturer;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public string ManufactureName
        {
            get { return m_ManufacturerName; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressureByManufacturer; }
        }

        //METHODS
        public virtual void InflatingWheel(float i_AirAmountToInflate)
        {
            float newAirPressure = m_CurrentAirPressure + i_AirAmountToInflate;

            if (newAirPressure <= m_MaxAirPressureByManufacturer)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressureByManufacturer - m_CurrentAirPressure, $"Cannot inflate beyond the maximum pressure of {m_MaxAirPressureByManufacturer}");
            }
        }
    }
}
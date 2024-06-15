using System;

internal class Wheel
{
    private string m_ManufacturerName;
    private float m_MaxAirPressureByManufacturer;
    private float m_CurrentAirPressure;

    //CTOR
    public Wheel(string i_ManufacturerName, float i_MaxAirPressureByManufacturer, string i_CurrentAirPressure)
    {
        m_ManufacturerName = i_ManufacturerName;
        m_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        m_CurrentAirPressure = float.Parse(i_CurrentAirPressure);
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
    }
}
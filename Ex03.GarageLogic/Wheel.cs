using System;

internal class Wheel
{
    private string m_ManufacturerName;
    private float r_MaxAirPressureByManufacturer;
    private float m_CurrentAirPressure;

    //CTOR
    public Wheel(string i_ManufacturerName, float i_MaxAirPressureByManufacturer, string i_CurrentAirPressure)
    {
        m_ManufacturerName = i_ManufacturerName;
        r_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        m_CurrentAirPressure = float.Parse(i_CurrentAirPressure);
    }

    //METHODS
    private void inflatingWheel(float i_AirAmountToInflate)
    {

    }
}
using System;
using System.Collections.Generic;
using static Enums;

internal class ElectricCar : Vehicle
{
    const int k_MaxTiresPressure = 31;
    const float k_MaxTimeEngine = 3.5F;

    private List<Wheel> m_Wheels;
    private Enums.ECarColors m_CarColor;
    private int m_NumberOfDoors;
    private float m_BatteryTimeLeft;

    //private List<string> m_i_Attributes;

    //METHODS
    public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
    {
        Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
        m_Wheels.Add(wheel);
        m_Wheels.Add(wheel);
        m_Wheels.Add(wheel);
        m_Wheels.Add(wheel);
        m_Wheels.Add(wheel);

        m_CarColor = (Enums.ECarColors)Enum.Parse(typeof(Enums.ECarColors), i_GetAttributes["Car color"]);
        m_NumberOfDoors = int.Parse(i_GetAttributes["Number of doors"]);
        m_BatteryTimeLeft = int.Parse(i_GetAttributes["Battery time left"]);
    }

    public override void InitializeAttrubuteList(List<string> i_Attributes)
    {
        i_Attributes = new List<string>()
        {
            "Car color",
            "Manufacturer name",
            "Battery time left",
            "Current air pressure",
            "Number of doors",
        };
    }

    //maybe should find 
    public override void InflatingWheel()
    {
        foreach (Wheel wheel in m_Wheels)
        {
            wheel.CurrentAirPressure = k_MaxTiresPressure;
        }
    }

    public override void FuelVehicle(string i_FuelType, string i_FualAmount)
    {
        //throw exception
    }

    public override void ChargeElectricVehicle(string i_TimeAmount)
    {
        float newTimeAmount = m_BatteryTimeLeft + float.Parse(i_TimeAmount);

        if (newTimeAmount <= k_MaxTimeEngine)
        {
            m_BatteryTimeLeft = newTimeAmount;
        }
    }

    public override Dictionary<string, string> DisplayDetails()
    {
        Dictionary<string, string> details = base.DisplayDetails();

        details.Add("Car color", m_CarColor.ToString());
        details.Add("Numbers of doors", m_NumberOfDoors.ToString());
        details.Add("Battery time left", m_BatteryTimeLeft.ToString());
        details.Add("Manufacture name", m_Wheels[0].ManufactureName);
        details.Add("Maximun air pressure by manufacture", m_Wheels[0].MaxAirPressure.ToString());

        char numOfWheel = '1';

        foreach(Wheel wheel in m_Wheels)
        {
            details.Add(numOfWheel + " wheel air pressure", wheel.CurrentAirPressure.ToString());
            numOfWheel++;
        }

        return details;
    }
}


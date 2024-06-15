using System;
using System.Collections.Generic;

internal class ElectricCar : Vehicle
{
    const int k_MaxTiresPressure = 31;
    const float k_MaxTimeEngine = 3.5F;

    private List<Wheel> m_Wheels;
    private Enums.ECarColors m_CarColor;
    private int m_NumberOfDoors;
    private int m_BatteryTimeLeft;

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

}


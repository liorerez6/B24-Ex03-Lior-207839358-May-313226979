using System;
using System.Collections.Generic;
using static Ex03.GameLogic.Enums;

namespace Ex03.GameLogic
{
    internal class Truck : Vehicle
    {
        private bool r_IsCarringToxicSubstances;
        private float m_CargoCapacity;
        private List<Wheel> m_Wheels = new List<Wheel>();
        const ETypeOfFuel k_TypeOfFuel = ETypeOfFuel.Soler;

        private const int k_MaxTiresPressure = 28;
        private const float k_MaxFuelTank = 120F;
        private float m_CurrentFuelAmount;
        
        //METHODS:

    }
}
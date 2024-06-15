using System;
using System.Collections.Generic;
using static Ex03.GameLogic.Enums;

namespace Ex03.GameLogic
{
    internal class FuelCar : Vehicle
    {
        const int k_MaxTiresPressure = 31;
        const float k_MaxFuelTank = 45F;
        const ETypeOfFuel k_TypeOfFuel = ETypeOfFuel.Octan95;

        private ECarColors m_CarColor;
        private int m_NumberOfDoors;
        private List<Wheel> m_Wheels;
        private float m_CurrentFuelAmount;


        //METHODS:

        //public override void GetAttributesFromVehicle()
        //{

        //}

        public override void FuelVehicle(string i_FuelType, string i_FualAmount)
        {
            ETypeOfFuel fuelType = (ETypeOfFuel)Enum.Parse(typeof(ETypeOfFuel), i_FuelType);

            if (fuelType == k_TypeOfFuel)
            {
                float newFuelAmount = m_CurrentFuelAmount + float.Parse(i_FualAmount);

                if (newFuelAmount <= k_MaxFuelTank)
                {
                    m_CurrentFuelAmount = newFuelAmount;
                }
            }
        }


        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            //throw exception
        }

        public enum ETypeOfFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }


    }
}
﻿using System;
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
        private List<Wheel> m_Wheels = new List<Wheel>();
        private float m_CurrentFuelAmount;


        //METHODS:

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

        public override List<string> InitializeAttrubuteList()
        {
            List<string> i_Attributes = new List<string>()
        {
            "Car color",
            "Current Fuel Amount",
            "Number of doors",
            "Current air pressure",
            "Manufacturer name"
        };
            return i_Attributes;
        }

        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
            m_Wheels.Add(wheel);
            m_Wheels.Add(wheel); // need to corret because now every wheell have refernce to the same wheel. changing tire pressure in one
                                 // will change it in all of them
            m_Wheels.Add(wheel);
            m_Wheels.Add(wheel);
            m_Wheels.Add(wheel);


            m_CarColor = (Enums.ECarColors)Enum.Parse(typeof(Enums.ECarColors), i_GetAttributes["Car color"]);
            m_NumberOfDoors = int.Parse(i_GetAttributes["Number of doors"]);
            m_CurrentFuelAmount = int.Parse(i_GetAttributes["Current Fuel Amount"]);
        }
        public override void InflatingWheel()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = k_MaxTiresPressure;
            }
        }

        public override Dictionary<string, string> DisplayDetails()
        {
            Dictionary<string, string> details = base.DisplayDetails();

            details.Add("Car color", m_CarColor.ToString());
            details.Add("Numbers of doors", m_NumberOfDoors.ToString());
            details.Add("Current Fuel Amount", m_CurrentFuelAmount.ToString());
            details.Add("Manufacture name", m_Wheels[0].ManufactureName);
            details.Add("Maximun air pressure by manufacture", m_Wheels[0].MaxAirPressure.ToString());

            char numOfWheel = '1';

            foreach (Wheel wheel in m_Wheels)
            {
                details.Add(numOfWheel + " wheel air pressure", wheel.CurrentAirPressure.ToString());
                numOfWheel++;
            }

            return details;
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
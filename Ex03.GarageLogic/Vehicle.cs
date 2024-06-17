using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Ex03.GameLogic
{
    public abstract class Vehicle
    {
        public enum ETypeOfFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
        public enum ERepairStatus
        {
            UnderRepair = 1,
            RepairedNotPayed = 2,
            RepairedAndPayed = 3
        }

        public enum ECarColors
        {
            Yellow,
            White,
            Red,
            Black
        }

        public enum ETypeOfMotorcycleLicense
        {
            A,
            A1,
            AA,
            B1
        }

        //Variables
        private string m_ModelName;
        private string m_LicenseNumber;
        private Owner m_OwnerDetails = new Owner();
        private ERepairStatus m_VehicleRepairStatus = ERepairStatus.UnderRepair;
        private List<Wheel> m_Wheels = new List<Wheel>();
        private int m_NumberOfWheels;
        private int m_MaxTirePressure;

        public Vehicle() { }

        public Vehicle(int i_NumberOfWheels, int i_TirePressure)
        {
            m_NumberOfWheels = i_NumberOfWheels;
            m_MaxTirePressure = i_TirePressure;
        }

        public List<Wheel> GetWheelsCopy 
        {
            get { return m_Wheels.ToList(); }
        }

        public void InflatingWheel()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = m_MaxTirePressure;
            }
        }

        public List<string> InitializeWheelsList(bool i_AreAllWheelsTheSame)
        {
            List<string> wheels = new List<string>();

            if (i_AreAllWheelsTheSame)
            {
                wheels.Add("Manufacturer name");
                wheels.Add("Current air pressure");
            }
            else
            {
                for (int i = 1; i <= m_NumberOfWheels; i++)
                {
                    wheels.Add("Manufacturer name " + i);
                    wheels.Add("Current air pressure " + i);
                }
            }

            return wheels;
        }

        public void InitializeWheels(Dictionary<string, string> i_GetWheels, bool i_AreAllWheelsTheSame)
        {
            foreach (string wheelName in i_GetWheels.Keys)
            {
                Wheel wheel = new Wheel(wheelName, m_MaxTirePressure, i_GetWheels[wheelName]);
                m_Wheels.Add(wheel);
            }

            if (i_AreAllWheelsTheSame)      //Than the dictonary has only 1 wheel
            {
                for(int i=0; i < m_NumberOfWheels - 1; i++)
                {
                    Wheel duplicateWheel = new Wheel(m_Wheels[0]);
                    m_Wheels.Add((Wheel)duplicateWheel);
                }
            }
        }

        //should decide if: keep as a nested class or 2 variable inside vehicle
        private class Owner
        {
            private string m_NameOfOwner;
            private string m_PhoneNumberOfOwner;

            public Owner() { }

            public Owner(string i_NameOfOwner, string i_PhoneNumberOfOwner)
            {
                m_NameOfOwner = i_NameOfOwner;
                m_PhoneNumberOfOwner = i_PhoneNumberOfOwner;
            }

            public string Name
            {
                get { return (string)m_NameOfOwner; }
                set { m_NameOfOwner = value; }
            }

            public string Phone
            {
                get { return (string)m_PhoneNumberOfOwner; }
                set { m_PhoneNumberOfOwner = value; }
            }
        }

        //Properties
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public ERepairStatus RepairStatus
        {
            get { return m_VehicleRepairStatus; }
            set { m_VehicleRepairStatus = value; }
        }

        public string Model
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        //METHODS

        public void UpdateOwnerDetails(string i_Name, string i_Phone)
        {
            m_OwnerDetails.Name = i_Name;
            m_OwnerDetails.Phone = i_Phone;
        }

        public virtual List<string> InitializeAttrubuteList()
        {
            List<string> list = new List<string>();
            return list;
        }

        public abstract void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes);

        public abstract void FuelVehicle(string i_FuelType, string i_FualAmount);

        public abstract void ChargeElectricVehicle(string i_TimeAmount);
       
        public virtual List<string> DisplayDetails()
        {
            List<string> details = new List<string>();

            details.Add("License number " + m_LicenseNumber);
            details.Add("Owner's name " + m_OwnerDetails.Name);
            details.Add("Owner's phone number " + m_OwnerDetails.Phone);
            details.Add("Model name "+ m_ModelName);
            details.Add("Vehicle repair status " + m_VehicleRepairStatus.ToString());

            int numOfWheel = 1;

            foreach (Wheel wheel in m_Wheels)
            {
                details.Add(numOfWheel + " wheel details " + wheel.CurrentAirPressure.ToString() + " " + wheel.ManufactureName.ToString());
                numOfWheel++;
            }

            return details;
        }
    }
}
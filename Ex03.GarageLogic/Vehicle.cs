using System;
using System.Collections.Generic;
using static Ex03.GameLogic.Enums;

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
        private float m_EnergyPercentage;
        private Owner m_OwnerDetails = new Owner();
        private ERepairStatus m_VehicleRepairStatus = ERepairStatus.UnderRepair;

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

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { m_EnergyPercentage = value; }
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


        public abstract void InflatingWheel();


        public abstract void FuelVehicle(string i_FuelType, string i_FualAmount);

        public abstract void ChargeElectricVehicle(string i_TimeAmount);
       
        public virtual Dictionary<string, string> DisplayDetails()
        {
            Dictionary<string, string> details = new Dictionary<string, string>();

            details.Add("License number", m_LicenseNumber);
            details.Add("Owner's name", m_OwnerDetails.Name);
            details.Add("Owner's phone number", m_OwnerDetails.Phone);
            details.Add("Model name", m_ModelName);
            details.Add("Energy percentage", m_EnergyPercentage.ToString());
            details.Add("Vehicle repair status", m_VehicleRepairStatus.ToString());

            return details;
        }

    }
}
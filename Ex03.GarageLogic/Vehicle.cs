using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

internal class Vehicle
{
    //Variables
    private string m_ModelName;
    private string m_LicenseNumber;
    private float m_EnergyPercentage;
    private List<Wheel> m_Wheels;       //maybe Wheel should be a nested class/ struct
    private Owner m_OwnerDetails;
    private Enums.ERepairStatus m_VehicleRepairStatus = Enums.ERepairStatus.UnderRepair;

    //private string m_NameOfOwner;
    //private string m_PhoneNumberOfOwner;

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

    public Enums.ERepairStatus RepairStatus
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

}
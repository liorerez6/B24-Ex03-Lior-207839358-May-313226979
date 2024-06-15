using System;
using System.Collections.Generic;

public class Vehicle
{
    //Variables
    private string m_ModelName;
    private string m_LicenseNumber;
    private float m_EnergyPercentage;
    private Owner m_OwnerDetails;
    private Enums.ERepairStatus m_VehicleRepairStatus = Enums.ERepairStatus.UnderRepair;

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

    public void UpdateOwnerDetails(string i_Name, string i_Phone)
    {
        m_OwnerDetails.Name = i_Name;
        m_OwnerDetails.Phone = i_Phone;
    }

    //METHODS
    public virtual void InitializeAttrubuteList(List<string> i_Attributes)
    {

    }

    public virtual void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
    {

    }

    public virtual void InflatingWheel()
    {

    }

    public virtual void FuelVehicle(string i_FuelType, string i_FualAmount)
    {

    }

    public virtual void ChargeElectricVehicle(string i_TimeAmount)
    {

    }


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
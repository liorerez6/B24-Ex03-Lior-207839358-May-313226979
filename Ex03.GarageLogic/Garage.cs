using System;
using System.Collections.Generic;
using System.Linq;


public class Garage
{
    private Dictionary<string, Vehicle> m_VehiclesInGarage;

    public Dictionary<string, Vehicle> VehiclesInGarage
    {
        get { return m_VehiclesInGarage; }
    }

    public List<string> ListOfVehicleLicenseNumbers
    {
        get { return m_VehiclesInGarage.Keys.ToList(); }
    }

    //METHODS
    public void PutNewVehicleInGarage(Vehicle i_Vehicle)
    {
        m_VehiclesInGarage.Add(i_Vehicle.LicenseNumber, i_Vehicle);
    }

    public bool IsVehicleAlreadyInGarage(string i_LicenseNumber)
    {
        bool isVehicleAlreadyInGarage = m_VehiclesInGarage.ContainsKey(i_LicenseNumber);

        if (isVehicleAlreadyInGarage)
        {
            //If is in garage - update it's repair status
            m_VehiclesInGarage[i_LicenseNumber].RepairStatus = Enums.ERepairStatus.UnderRepair;
        }

        return isVehicleAlreadyInGarage;
    }

    public List<string> SortVehiclesByRepairStatus(int i_RepairStatus)
    {
        List<string> list = new List<string>();
        Enums.ERepairStatus sortDelim = (Enums.ERepairStatus)i_RepairStatus;

        foreach(string license in m_VehiclesInGarage.Keys) 
        {
            if (m_VehiclesInGarage[license].RepairStatus == sortDelim)
            {
                list.Add(license);
            }
        }

        return list;
    }

    public void InflateVehicleWheels(string i_LicenseNumber)
    {
        m_VehiclesInGarage[i_LicenseNumber].InflatingWheel();
    }

    public void FuelVehicle(string i_LicenseNumber, string i_FuelType, string i_FualAmount)
    {
        m_VehiclesInGarage[i_LicenseNumber].FuelVehicle(i_FuelType, i_FualAmount);
    }

    public void ChargeElectricVehicle(string i_LicenseNumber, string i_TimeAmount)
    {
        m_VehiclesInGarage[i_LicenseNumber].ChargeElectricVehicle(i_TimeAmount);
    }

    public Dictionary<string, string> DisplayVehicleDetails(string i_LicenseNumber)
    {
        Dictionary<string, string> details = m_VehiclesInGarage[i_LicenseNumber].DisplayDetails();

        return details;
    }

    //public void ChangeVehicleRepairStatus(string i_LicenseNumber, int i_RepairStatus)
    //{
    //    //get details from user: LicenseNumber, new repair status
    //    if(i_LicenseNumber != null)
    //    {
    //        m_VehiclesInGarage[i_LicenseNumber].RepairStatus = (Enums.ERepairStatus)(i_RepairStatus);
    //    }
    //}

    //public void InflateVehicleWheels()
    //{
    //    //get license number
    //}

    //public void FillVehicleWithFuel()
    //{
    //    //get license number
    //    //get type of fuel
    //    //get amount of fuel
    //}

    //public void ChargeVehicleWithElectricity()
    //{
    //    //get license number
    //    //get amount of time
    //}

    //public void DisplayVehicleFullDetails()
    //{
    //    //license number
    //    //model
    //    //owner
    //    //repair status
    //    //detail for this specifi kind of vehicle
    //}
}
using System;
using System.Collections.Generic;


internal class Garage
{
    private Dictionary<string, Vehicle> m_VehiclesInGarage;

    public Dictionary<string, Vehicle> VehiclesInGarage
    {
        get { return m_VehiclesInGarage; }
    }

    //METHODS
    public void PutNewVehicleInGarageRequest(Vehicle i_Vehicle)
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

    public List<string> SortVehicleInGarageByRepairStatus(int i_RepairStatusNumber)
    {
        List<string> list = null; //clone licese lise
        //sotr list

        return list;
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GameLogic
{
    /*public*/ internal class Garage
    {
        private Dictionary<string, Vehicle> m_VehiclesInGarage = new Dictionary<string, Vehicle>();

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

            if (isVehicleAlreadyInGarage && i_LicenseNumber != null)
            {
                m_VehiclesInGarage[i_LicenseNumber].RepairStatus = Vehicle.ERepairStatus.UnderRepair;
            }

            return isVehicleAlreadyInGarage;
        }

        public List<string> SortVehiclesByRepairStatus(int i_RepairStatus)
        {
            List<string> list = new List<string>();
            Vehicle.ERepairStatus sortDelim = (Vehicle.ERepairStatus)i_RepairStatus;

            foreach (string license in m_VehiclesInGarage.Keys)
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

        public List<string> DisplayVehicleDetails(string i_LicenseNumber)
        {
            List<string> details = m_VehiclesInGarage[i_LicenseNumber].DisplayDetails();

            return details;
        }

    }
}
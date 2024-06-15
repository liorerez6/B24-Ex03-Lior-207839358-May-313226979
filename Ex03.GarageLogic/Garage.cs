using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles; // <string,vehicle>
        

        public Garage() /// bli owner Name
        {
            m_Vehicles = new Dictionary<string, Vehicle>();    
        }


        public void AddVehicle(Vehicle vehicle, Dictionary<string,string> i_InformationFromUser)
        {
            GarageEntry newEntry = new GarageEntry(vehicle, i_InformationFromUser[m_RequiredAttributesForGarage[0]], i_InformationFromUser[m_RequiredAttributesForGarage[1]]);

            //update vehicle attributes

            m_Vehicles.Add(vehicle.LicenseNumber, newEntry);
            m_Vehicles[vehicle.LicenseNumber].Status = VehicleStatus.INREPAIR;
        }

        public bool IsCarInGarage(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);               
        }
    }

    public enum VehicleStatus
    {
        INREPAIR,
        REPAIRED,
        PAID
    }
}

            
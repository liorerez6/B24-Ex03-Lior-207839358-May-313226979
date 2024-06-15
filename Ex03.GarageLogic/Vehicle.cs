using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string M_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLeftPercentage;
        private string m_OwnerName;
        private string m_OwnerPhone;
        List<Wheel> Wheels;

        List<string> m_RequiredAttributesForVehicle = new List<string>()
        {
            "Model Name",
            "Energy Left Percentage",
            "Owner phone",
            "Owner Name",
            "Owner Phone"
        };

        static Vehicle()
        {

        }
            
        private static List<string> m_VehicleTypes = new List<string>
        {
            "Truck",
            "Car",
            "Electric Car",
            "Motorcycle",
            "Electric Motorcycle"
        };

        public static List<string> VehicleTypesInGarage
        {
            get { return m_VehicleTypes; }
        }

        public static Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;

            switch (type)
            {
                case "Motorcycle":
                    //vehicle = new Motorcycle();
                    break;
                case "Electric Motorcycle":
                    //vehicle = new ElectricMotorcycle();
                    break;
                case "Fueled Car":
                    vehicle = new FueledCar();
                    break;
                case "Electric Car":
                    vehicle = new ElectricCar();
                    break;
                case "Truck":
                    //vehicle = new Truck();
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }

            return vehicle;
        }

        public virtual List<string> initlizer()
        {
            return m_RequiredAttributesForVehicle;
        }

        public virtual List<string> GetRequiredData()
        {
            return m_RequiredAttributesForVehicle;
        }

        public virtual void UpdateAttributes(Dictionary<string,string> i_Attributes)
        {

        }

        public string ModelName
        {
            get { return M_ModelName; }
            set { M_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float EnergyLeftPercentage
        {
            get { return m_EnergyLeftPercentage; }
            set { m_EnergyLeftPercentage = value; }
        }
    }

    public enum FuelType
    {
        SOLER,
        OCTAN95,
        OCTAN96,
        OCTAN98
    }



}

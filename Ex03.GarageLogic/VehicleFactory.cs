using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {

        private List<string> m_VehicleTypes = new List<string>
        {
            "Truck",
            "Car",
            "Electric Car",
            "Motorcycle",
            "Electric Motorcycle"
        };

        public List<string> VehicleTypesInGarage
        {
            get { return m_VehicleTypes; }
        }


        public Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;

            switch(type)
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
    }
}

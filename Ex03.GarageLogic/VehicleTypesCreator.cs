using System;
using static Ex03.GameLogic.Enums;

namespace Ex03.GameLogic
{
    public enum EVehicleTypes
    {
        FuelCar,
        ElectricCar,
        FuelMotorcycle,
        ElectricMotorcycle,
        Truck
    }

    public class VehicleTypesCreator
    {
        public static Vehicle CreateNewVehicle(string i_VehicleType)
        {
            Vehicle vehicle = null;
            Enum.TryParse(i_VehicleType, out EVehicleTypes getType);

            getType--;

            switch (getType)
            {
                case EVehicleTypes.FuelCar:
                    vehicle = new FuelCar();
                    break;
                case EVehicleTypes.ElectricCar:
                    vehicle = new ElectricCar();
                    break;
                case EVehicleTypes.FuelMotorcycle:
                    vehicle = new FuelMotorcycle();
                    break;
                case EVehicleTypes.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle();
                    break;
                case EVehicleTypes.Truck:
                    vehicle = new Truck();
                    break;
            }
            
            return vehicle;
        }
    }
}
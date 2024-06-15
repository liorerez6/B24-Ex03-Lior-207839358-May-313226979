using System;

namespace Ex03.GameLogic
{
    public class VehicleTypesCreator
    {
        private enum EVehicleTypes
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        public static Vehicle CreateNewVehicle(string i_VehicleType)
        {
            Vehicle vehicle = null;

            if (Enum.TryParse(i_VehicleType, out EVehicleTypes getType))
                getType--;
            {
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
            }

            return vehicle;
        }
    }
}
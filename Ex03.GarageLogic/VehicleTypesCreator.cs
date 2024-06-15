using Ex03.GarageLogic;
using System;

internal class VehicleTypesCreator
{
    private enum EVehicleTypes
    {
        FuelCar,
        ElectricCar,
        FuelMotorcycle,
        ElectricMotorcycle,
        Truck
    }

    public Vehicle CreateNewVehicle(string i_VehicleType)
    {
        Vehicle vehicle = null;

        if (Enum.TryParse(i_VehicleType, out EVehicleTypes getType))
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
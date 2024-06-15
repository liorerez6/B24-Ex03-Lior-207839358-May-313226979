using System;
using System.Collections.Generic;

//new note

internal class ConsoleIO
{
    //private string getInputFromUser()
    //{
    //    string getName = Console.ReadLine();

    //    return getName;
    //}

    //if using this ^^
    //EXAMPLE:
    //public string GetOwnerName()
    //{
    //    Console.WriteLine("Please enter your name:");

    //    return getInputFromUser();
    //}

    public string GetOwnerName()
    {
        Console.WriteLine("Please enter your name:");
        string getName = Console.ReadLine();

        return getName;
    }

    public string GetFuelType()
    {
        Console.WriteLine("Please enter the fuel type of the vehicle:");
        string getFuelType = Console.ReadLine();

        return getFuelType;
    }

    public string GetLicenseNumber()
    {
        Console.WriteLine("Please enter your license number:");
        string getLicenseNumber = Console.ReadLine();

        return getLicenseNumber;
    }

    public string GetVehicleModelType()
    {
        Console.WriteLine("Please enter the model type o:");
        string getModelType = Console.ReadLine();

        return getModelType;
    }

    public string GetOwnerPhoneNumber()
    {
        Console.WriteLine("Please enter your phone number:");
        string getPhoneNumber = Console.ReadLine();

        return getPhoneNumber;
    }

    public int GetAmountOfAirToInflate()
    {
        Console.WriteLine("Please type the amount of air to inflate:");
        string getInput = Console.ReadLine();

        int getRepairStatus = int.Parse(getInput);

        return getRepairStatus;
    }

    public int GetAmountOfElectricityToCharge()
    {
        Console.WriteLine("Please type the amount of air to inflate:");
        string getInput = Console.ReadLine();

        int getRepairStatus = int.Parse(getInput);

        return getRepairStatus;
    }

    //maybe should be display a list, any list
    public void DisplayVehiclesInGarage(List<string> i_VehiclesInGarage)
    {
        foreach (string vehicleDetails in i_VehiclesInGarage)
        {
            Console.WriteLine($"{vehicleDetails}");
        }
    }

    public int GetRepairStatusForSorting()
    {
        Console.WriteLine("Please choose a vehicle repair status:");
        Console.WriteLine("1. Under Repair");
        Console.WriteLine("2. Repaired, not payed");
        Console.WriteLine("3. Repaired and payed");

        string getRepairStatusString = Console.ReadLine();
        int getRepairStatus = int.Parse(getRepairStatusString);

        return getRepairStatus;
    }

    public bool AskIfUserWantToSortVehicleByRepairStatus()
    {
        Console.WriteLine("Do you want to display vehicles sorted by a repair status?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");

        string getRepairStatusString = Console.ReadLine();
        int getRepairStatus = int.Parse(getRepairStatusString);
        bool userRequestedToSort = getRepairStatus == 1;

        return userRequestedToSort;
    }

    public int DisplayVehicleTypesOptions()
    {
        Console.WriteLine("Please choose a vehicle type:");
        Console.WriteLine("1. FuelCar");
        Console.WriteLine("2. ElectricCar");
        Console.WriteLine("3. FuelMotorcycle");
        Console.WriteLine("4. ElectricMotorcycle");
        Console.WriteLine("5. Truck");

        string getTypeString = Console.ReadLine();
        int getType = int.Parse(getTypeString);

        return getType;
    }

    public void VehicleIsAlreadyInGarageMessage()
    {
        Console.WriteLine("This vehicle is already in garage, under repair.");
    }

    public int DisplayGarageSystemOptions()
    {
        bool isValidInput = false;
        int choiseNumber = 0;

        while (isValidInput == false)
        {
            Console.Clear();
            Console.WriteLine("Garage Management System");
            Console.WriteLine("########################");
            Console.WriteLine("Please choose which action you want:");
            Console.WriteLine("1. Add vehicle");
            Console.WriteLine("2. Display vehicles");
            Console.WriteLine("3. Change vehicle repair status");
            Console.WriteLine("4. Inflating vehicle's Wheels");
            Console.WriteLine("5. Fuel vehicle");
            Console.WriteLine("6. Charge electric vehicle");
            Console.WriteLine("7. Display vehicle's details");

            string getInput = Console.ReadLine();
            isValidInput = int.TryParse(getInput, out choiseNumber);
        }

        return choiseNumber;
    }
}
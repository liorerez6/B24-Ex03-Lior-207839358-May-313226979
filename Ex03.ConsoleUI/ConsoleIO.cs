using System;
using System.Collections.Generic;

public class ConsoleIO
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

    public string DisplayMessage(string i_Message)
    {
        Console.Clear();
        Console.WriteLine($"Please enter {i_Message}:");
        string userInput = Console.ReadLine();

        return userInput;
    }

    public string GetAmountOfTimeToCharge()
    {
        Console.Clear();
        Console.WriteLine("Please enter the amount of time to charge:");
        string getAmount = Console.ReadLine();

        return getAmount;
    }

    public string GetFuelAmount()
    {
        Console.Clear();
        Console.WriteLine("Please enter the amount of fuel:");
        string getAmount = Console.ReadLine();

        return getAmount;
    }

    public string GetOwnerName()
    {
        Console.Clear();
        Console.WriteLine("Please enter your name:");
        string getName = Console.ReadLine();

        return getName;
    }

    public string GetFuelType()
    {
        Console.Clear();
        Console.WriteLine("Please enter the fuel type of the vehicle:");
        string getFuelType = Console.ReadLine();

        return getFuelType;
    }

    public string GetLicenseNumber()
    {
        Console.Clear();
        Console.WriteLine("Please enter your license number:");
        string getLicenseNumber = Console.ReadLine();

        return getLicenseNumber;
    }

    public string GetVehicleModelType()
    {
        Console.Clear();
        Console.WriteLine("Please enter the model type o:");
        string getModelType = Console.ReadLine();

        return getModelType;
    }

    public string GetOwnerPhoneNumber()
    {
        Console.Clear();
        Console.WriteLine("Please enter your phone number:");
        string getPhoneNumber = Console.ReadLine();

        return getPhoneNumber;
    }

    public int GetAmountOfAirToInflate()
    {
        Console.Clear();
        Console.WriteLine("Please type the amount of air to inflate:");
        string getInput = Console.ReadLine();

        int getRepairStatus = int.Parse(getInput);

        return getRepairStatus;
    }

    public int GetAmountOfElectricityToCharge()
    {
        Console.Clear();
        Console.WriteLine("Please type the amount of air to inflate:");
        string getInput = Console.ReadLine();

        int getRepairStatus = int.Parse(getInput);

        return getRepairStatus;
    }

    //maybe should be display a list, any list
    public void DisplayVehiclesInGarage(List<string> i_VehiclesInGarage)
    {
        Console.Clear();
        foreach (string vehicleDetails in i_VehiclesInGarage)
        {
            Console.Write(vehicleDetails);
        }
    }

    public void DisplayVehicleDetails(Dictionary<string, string> i_VehiclesDetails)
    {
        Console.Clear();
        foreach (string vehicleDetails in i_VehiclesDetails.Keys)
        {
            Console.WriteLine($"{vehicleDetails}: ");
            Console.Write(i_VehiclesDetails[vehicleDetails]);
        }
    }

    public int GetRepairStatus()
    {
        Console.Clear();
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
        Console.Clear();
        Console.WriteLine("Do you want to display vehicles sorted by a repair status?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");

        string getRepairStatusString = Console.ReadLine();
        int getRepairStatus = int.Parse(getRepairStatusString);
        bool userRequestedToSort = getRepairStatus == 1;

        return userRequestedToSort;
    }

    public string DisplayVehicleTypesOptions()
    {
        Console.Clear();
        Console.WriteLine("Please choose a vehicle type:");
        Console.WriteLine("1. FuelCar");
        Console.WriteLine("2. ElectricCar");
        Console.WriteLine("3. FuelMotorcycle");
        Console.WriteLine("4. ElectricMotorcycle");
        Console.WriteLine("5. Truck");

        string getTypeString = Console.ReadLine();
        //int getType = int.Parse(getTypeString);

        return getTypeString;
    }

    public void VehicleIsAlreadyInGarageMessage()
    {
        Console.Clear();
        Console.WriteLine("This vehicle is already in garage, under repair.");
    }

    public int DisplayGarageSystemOptions()
    {
        Console.Clear();
        bool isValidInput = false;
        int choiseNumber = 0;

        while (isValidInput == false)
        {
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

            Console.Clear();
        }

        return choiseNumber;
    }
}
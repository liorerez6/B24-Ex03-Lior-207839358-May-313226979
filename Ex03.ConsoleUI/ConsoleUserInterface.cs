using System.Collections.Generic; 

internal class ConsoleUserInterface
{
    ConsoleIO m_ConsoleIOMessages = new ConsoleIO();
    Garage m_Garage = new Garage();

    //METHODS
    public void DisplayMenuChoisesToUser()
    {
        int userChoise = m_ConsoleIOMessages.DisplayGarageSystemOptions();

        switch (userChoise)
        {
            case 1:
                addVehicleInGarageRequest();
                break;
            case 2:
                displayVehiclesInGarageDetails();
                break;
            case 3:
                changeVehicleRepairStatus();
                break;
            case 4:
                inflatingWheel();
                break;
            case 5:
                fuelVehicle();
                break;
            case 6:
                chargeElectricVehicle();
                break;
            case 7:
                displayFullDetailsOfVehicle();
                break;
            default:
                break;
        }
    }

    private void addVehicleInGarageRequest()
    {
        string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
        bool isAlreadyInGarage = false; // IsVehicleAlreadyInGarage(getLicenseNumber);

        if (isAlreadyInGarage)
        {
            m_ConsoleIOMessages.VehicleIsAlreadyInGarageMessage();
        }
        else
        {
            createNewVehicleForGarage();
        }
    }

    private void createNewVehicleForGarage()
    {
        string getTypeOfVehicle = m_ConsoleIOMessages.DisplayVehicleTypesOptions();
        Vehicle vehicle = VehicleTypesCreator.CreateNewVehicle(getTypeOfVehicle);

        initializeVehicleDetails(vehicle);

        List<string> attributes = null;
        vehicle.InitializeAttrubuteList(attributes);

        Dictionary<string, string> getAttributes = getInfoFromUserRegadingVehicle(attributes);
        vehicle.InitializeAttributesOfVehicle(getAttributes);
    }

    private Dictionary<string, string> getInfoFromUserRegadingVehicle(List<string> i_Atttibutes)
    {
        Dictionary<string, string> additionalSpecificInfoAboutVehicle = new Dictionary<string, string>();

        foreach (string attribute in i_Atttibutes)
        {
            string userInput =  m_ConsoleIOMessages.DisplayMessage(attribute);
            additionalSpecificInfoAboutVehicle.Add(attribute, userInput);
        }

        return additionalSpecificInfoAboutVehicle;
    }

    private void initializeVehicleDetails(Vehicle i_Vehicle)
    {
        string getOwnerName = m_ConsoleIOMessages.GetOwnerName();
        string getOwnerPhoneNumber = m_ConsoleIOMessages.GetOwnerPhoneNumber();

        i_Vehicle.UpdateOwnerDetails(getOwnerName, getOwnerPhoneNumber);
        i_Vehicle.LicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
        //i_Vehicle.EnergyPercentage = m_ConsoleIOMessages.  ();
        //i_Vehicle.Model = m_ConsoleIOMessages.  ();
    }

    private void displayVehiclesInGarageDetails()
    {
        List<string> getGarageDetails = null;
        bool isRequestedToSort = m_ConsoleIOMessages.AskIfUserWantToSortVehicleByRepairStatus();

        if (isRequestedToSort)
        {
            int sortByRepairStatus = m_ConsoleIOMessages.GetRepairStatus();
            
            //getGarageDetails = //get from logic sorted 
        }
        else
        {
            //getGarageDetails = //get from logic not sorted 
        }

        m_ConsoleIOMessages.DisplayVehiclesInGarage(getGarageDetails);
    }

    private void changeVehicleRepairStatus()
    {
        //display message
        string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();

        //sent to logic datails
        int getRepairChoise = m_ConsoleIOMessages.GetRepairStatus();

        switch (getRepairChoise)
        {
            case 1:
                //Under Repair
                break;
            case 2:
                //Repaired, not payed
                break;
            case 3:
                //Repaired and payed
                break;
            default:
                //ERROR
                break;
        }
    }

    private void inflatingWheel()
    {
        string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();

        //send to logic
    }

    private void fuelVehicle()
    {
        string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
        string getFuelType = m_ConsoleIOMessages.GetFuelType();
        // continue
    }

    private void chargeElectricVehicle()
    {
        //......
    }

    private void displayFullDetailsOfVehicle()
    {
        string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
        //display messages
        ////get license number

    }
}
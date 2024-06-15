using System.Collections.Generic;

internal class ConsoleUserInterface
{
    ConsoleIO m_ConsoleIOMessages = new ConsoleIO();

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
        bool isAlreadyInGarage = false; //IsVehicleAlreadyInGarage(getLicenseNumber);

        if (isAlreadyInGarage)
        {
            m_ConsoleIOMessages.VehicleIsAlreadyInGarageMessage();
        }
        else
        {
            //get information and create one
        }

    }

    private void displayVehiclesInGarageDetails()
    {
        List<string> getGarageDetails = null;
        bool isRequestedToSort = m_ConsoleIOMessages.AskIfUserWantToSortVehicleByRepairStatus();

        if (isRequestedToSort)
        {
            int sortByRepairStatus = m_ConsoleIOMessages.GetRepairStatusForSorting();
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
        //sent to logic datails
        int getRepairChoise = m_ConsoleIOMessages.GetRepairStatusForSorting();

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
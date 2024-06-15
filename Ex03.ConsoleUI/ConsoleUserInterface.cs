using System.Collections.Generic;
using Ex03.GameLogic;

namespace Ex03.ConsoleUI
{


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
            bool isAlreadyInGarage = m_Garage.IsVehicleAlreadyInGarage(getLicenseNumber);

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

            m_Garage.PutNewVehicleInGarage(vehicle);
        }

        private Dictionary<string, string> getInfoFromUserRegadingVehicle(List<string> i_Atttibutes)
        {
            Dictionary<string, string> additionalSpecificInfoAboutVehicle = new Dictionary<string, string>();

            foreach (string attribute in i_Atttibutes)
            {
                string userInput = m_ConsoleIOMessages.DisplayMessage(attribute);
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

                getGarageDetails = m_Garage.SortVehiclesByRepairStatus(sortByRepairStatus);
            }
            else
            {
                getGarageDetails = m_Garage.ListOfVehicleLicenseNumbers;
            }

            m_ConsoleIOMessages.DisplayVehiclesInGarage(getGarageDetails);
        }

        private void changeVehicleRepairStatus()
        {
            string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
            int getRepairChoise = m_ConsoleIOMessages.GetRepairStatus();

            switch (getRepairChoise)
            {
                case 1:
                    m_Garage.VehiclesInGarage[getLicenseNumber].RepairStatus = Enums.ERepairStatus.UnderRepair;
                    break;
                case 2:
                    m_Garage.VehiclesInGarage[getLicenseNumber].RepairStatus = Enums.ERepairStatus.RepairedNotPayed;
                    break;
                case 3:
                    m_Garage.VehiclesInGarage[getLicenseNumber].RepairStatus = Enums.ERepairStatus.RepairedAndPayed;
                    break;
                default:
                    //ERROR
                    break;
            }
        }

        private void inflatingWheel()
        {
            string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();

            m_Garage.InflateVehicleWheels(getLicenseNumber);
        }

        private void fuelVehicle()
        {
            string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
            string getFuelType = m_ConsoleIOMessages.GetFuelType();
            string getAmountOfFuel = m_ConsoleIOMessages.GetFuelAmount();

            m_Garage.FuelVehicle(getLicenseNumber, getFuelType, getAmountOfFuel);
        }

        private void chargeElectricVehicle()
        {
            string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
            string getAmountOfTimel = m_ConsoleIOMessages.GetAmountOfTimeToCharge();

            m_Garage.ChargeElectricVehicle(getLicenseNumber, getAmountOfTimel);
        }

        private void displayFullDetailsOfVehicle()
        {
            string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
            Dictionary<string, string> details = m_Garage.DisplayVehicleDetails(getLicenseNumber);

            m_ConsoleIOMessages.DisplayVehicleDetails(details);
        }
    }
}
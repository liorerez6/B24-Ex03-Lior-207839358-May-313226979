using System;
using System.Collections.Generic;
using Ex03.GameLogic;
using System.Threading;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUserInterface
    {
        ConsoleIO m_ConsoleIOMessages = new ConsoleIO();
        Garage m_Garage = new Garage();

        //METHODS
        public void DisplayMenuChoisesToUser()
        {
            bool isExitRequested = false;

            while (!isExitRequested)
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
                    case 8:
                        isExitRequested = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void addVehicleInGarageRequest() // option number 1# in the menu
        {
            tryAgain:

            try
            {
                string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
                bool isAlreadyInGarage = m_Garage.IsVehicleAlreadyInGarage(getLicenseNumber);

                if (isAlreadyInGarage)
                {
                    m_ConsoleIOMessages.VehicleIsAlreadyInGarageMessage(); 
                }
                else
                {
                    createNewVehicleForGarage(getLicenseNumber);
                }
            }


            catch(Ex03.GameLogic.ValueOutOfRangeException argumentExp)
            {
                Console.WriteLine($"Error: {argumentExp.Message}");
                Console.WriteLine($"Valid range: {argumentExp.MinValue} to {argumentExp.MaxValue}");
                Console.Write(argumentExp);
                Thread.Sleep(1500);
                goto tryAgain;
            }

            catch(FormatException argumentExp)
            {
                Console.Write(argumentExp);
                Thread.Sleep(1500);
                goto tryAgain;
            }

            catch(ArgumentException argumentExp)
            {
                Console.Write(argumentExp);
                Thread.Sleep(1500);
                goto tryAgain;

            }
            catch(Exception ex)  // lefi soogei expection
            {
                Console.Write(ex);
                Thread.Sleep(1500);
                goto tryAgain;

            }
            
        }

        private void createNewVehicleForGarage(string i_LicenseNumber)
        {
            string getTypeOfVehicle = m_ConsoleIOMessages.DisplayVehicleTypesOptions();
            Vehicle vehicle = VehicleTypesCreator.CreateNewVehicle(getTypeOfVehicle);

            initializeVehicleDetails(vehicle, i_LicenseNumber);

            List<string> attributes = vehicle.InitializeAttrubuteList();
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

        private void initializeVehicleDetails(Vehicle i_Vehicle, string i_LicenseNumber)
        {
            string getOwnerName = m_ConsoleIOMessages.GetOwnerName();
            string getOwnerPhoneNumber = m_ConsoleIOMessages.GetOwnerPhoneNumber();

            i_Vehicle.UpdateOwnerDetails(getOwnerName, getOwnerPhoneNumber);
            i_Vehicle.LicenseNumber = i_LicenseNumber;
            i_Vehicle.EnergyPercentage = float.Parse(m_ConsoleIOMessages.GetEnergyPercentage());
            i_Vehicle.Model = m_ConsoleIOMessages.GetVehicleModelType();
        }

        private void displayVehiclesInGarageDetails() // option number 2# in the menu
        {
            tryAgain:

            try
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
                
                m_ConsoleIOMessages.DisplayVehiclesInGarage(getGarageDetails); // TO DO loop and exist when user input..
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                Thread.Sleep(1000);
                goto tryAgain;
            }
        }  

        private void changeVehicleRepairStatus() // option number 3# in the menu
        {
            tryAgain:

            try
            {
                string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
                int getRepairChoise = m_ConsoleIOMessages.GetRepairStatus();

                switch (getRepairChoise)
                {
                    case 1:
                        m_Garage.VehiclesInGarage[getLicenseNumber].RepairStatus = Vehicle.ERepairStatus.UnderRepair;
                        break;
                    case 2:
                        m_Garage.VehiclesInGarage[getLicenseNumber].RepairStatus = Vehicle.ERepairStatus.RepairedNotPayed;
                        break;
                    case 3:
                        m_Garage.VehiclesInGarage[getLicenseNumber].RepairStatus = Vehicle.ERepairStatus.RepairedAndPayed;
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                Thread.Sleep(1000);
                goto tryAgain;
            }
        }

        private void inflatingWheel()  // option number 4# in the menu
        {
            tryAgain:

            try
            {
                string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();

                m_Garage.InflateVehicleWheels(getLicenseNumber);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Thread.Sleep(1000);
                goto tryAgain;
            }
        }

        private void fuelVehicle() // option number 5# in the menu
        {
            tryAgain:

            try
            {
                string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
                string getFuelType = m_ConsoleIOMessages.GetFuelType();
                string getAmountOfFuel = m_ConsoleIOMessages.GetFuelAmount();

                m_Garage.FuelVehicle(getLicenseNumber, getFuelType, getAmountOfFuel);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Thread.Sleep(1000);
                goto tryAgain;
            }
        }

        private void chargeElectricVehicle() // option number 6# in the menu
        {
            tryAgain:

            try { 
                string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
                string getAmountOfTimel = m_ConsoleIOMessages.GetAmountOfTimeToCharge();

                m_Garage.ChargeElectricVehicle(getLicenseNumber, getAmountOfTimel);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Thread.Sleep(1000);
                goto tryAgain;
            }
        }

        private void displayFullDetailsOfVehicle() // option number 7# in the menu
        {
            tryAgain:

            try { 
                string getLicenseNumber = m_ConsoleIOMessages.GetLicenseNumber();
                Dictionary<string, string> details = m_Garage.DisplayVehicleDetails(getLicenseNumber);

                m_ConsoleIOMessages.DisplayVehicleDetails(details);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Thread.Sleep(1000);
                goto tryAgain;
            }
        }
    }
}
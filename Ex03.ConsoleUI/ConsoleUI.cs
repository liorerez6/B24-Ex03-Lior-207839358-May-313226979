using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {
        private Ex03.GarageLogic.Garage m_Garage = new GarageLogic.Garage();
        private Ex03.GarageLogic.VehicleFactory m_VehicleFactory = new VehicleFactory();

        public void Run()
        {
            List<string> supportedVehicales = m_VehicleFactory.VehicleTypesInGarage;


            
            Console.WriteLine("enter lisence number:");
            string licenseNumber = Console.ReadLine();

            if (m_Garage.IsCarInGarage(licenseNumber) == false) // TO DO (right now just return false)
            {
                Console.WriteLine("which car you want to enter the Garage from bellow:");
                foreach (string supportedVehical in supportedVehicales)
                {
                    {
                        Console.WriteLine(supportedVehical);
                    }
                }

                string typeOfCar = Console.ReadLine();


                //Vehicle vehicle = vehicle.CreateVehicle(typeOfCar)
                

                Vehicle vehicle = m_VehicleFactory.CreateVehicle(typeOfCar); // must be before data from the user about the Vehicle

               // List<string> attributes = vehicle.Initilizer()

                Dictionary<string, string> DataForVehicle = getInfoFromUserRegadingVehicle(vehicle,licenseNumber);

                vehicle.UpdateAttributes(DataForVehicle);

            }
        }


        private Dictionary<string, string> getInfoFromUserRegadingVehicle(Vehicle i_Vehicle, string i_LicenseNumber)
        {
            Dictionary<string, string> additionalSpecificInfoAboutVehicle = new Dictionary<string, string>();
           
            List<string> userRequiredData = m_Garage.GetRequiredData(); // attribute of garage : owner name, owner phone

            foreach (string attribute in userRequiredData)
            {
                Console.WriteLine($"Please enter {attribute}:");
                string userInput = Console.ReadLine();
                additionalSpecificInfoAboutVehicle.Add(attribute, userInput);
            }

            List<string> requiredAttributes = i_Vehicle.GetRequiredData(); // attributes of Electric car / motorocycle 

            //additionalSpecificInfoAboutVehicle.Add("License Number", i_LicenseNumber);

            foreach (string attribute in requiredAttributes)
            {
                Console.WriteLine($"Please enter {attribute}:");
                string userInput = Console.ReadLine();
                additionalSpecificInfoAboutVehicle.Add(attribute, userInput);
            }

            return additionalSpecificInfoAboutVehicle;
        }
    }

}

    




        //    switch (i_VehicleType)
        //    {
        //        case "Car":
        //            additionalSpecificInfoAboutVehicle.Add("CarColor", GetCarColor());
        //            additionalSpecificInfoAboutVehicle.Add("NumberOfDoors", GetNumberOfDoors());
        //            break;
        //        case "Electric Car":
        //            additionalSpecificInfoAboutVehicle.Add("CarColor", GetCarColor());
        //            additionalSpecificInfoAboutVehicle.Add("NumberOfDoors", GetNumberOfDoors());
        //            break;
        //        case "Motorcycle":
        //            additionalSpecificInfoAboutVehicle.Add("EngineVolume", GetEngineVolume());
        //            break;
        //        case "Electric Motorcycle":
        //            additionalSpecificInfoAboutVehicle.Add("EngineVolume", GetEngineVolume());
        //            break;

//    }

//    return additionalSpecificInfoAboutVehicle;
//}

//private string GetCarColor()
//{
//    Console.WriteLine("Enter car color:");
//    string color = Console.ReadLine();
//    return  color;
//}

//private string GetNumberOfDoors()
//{
//    Console.WriteLine("Enter number of doors:");
//    string doors = Console.ReadLine();
//    return doors;
//}

//private string GetEngineVolume()
//{
//    Console.WriteLine("Enter engine volume:");
//    string volume = Console.ReadLine();
//    return volume;
//}
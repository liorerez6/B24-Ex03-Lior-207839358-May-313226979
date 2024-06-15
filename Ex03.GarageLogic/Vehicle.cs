using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string M_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLeftPercentage;
        //owner phone
        List<Wheel> Wheels;

        List<string> m_RequiredAttributesForVehicle = new List<string>()
        {
            "Model Name",
            "Energy Left Percentage",
            "Owner phone"
            
            //"License Number"
        };


        public virtual List<string> initlizer()
        {
            return m_RequiredAttributesForVehicle;
        }


        public virtual List<string> GetRequiredData()
        {
            return m_RequiredAttributesForVehicle;
        }

        public virtual void UpdateAttributes(Dictionary<string,string> i_Attributes)
        {

        }

        public string ModelName
        {
            get { return M_ModelName; }
            set { M_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float EnergyLeftPercentage
        {
            get { return m_EnergyLeftPercentage; }
            set { m_EnergyLeftPercentage = value; }
        }
    }

    public enum FuelType
    {
        SOLER,
        OCTAN95,
        OCTAN96,
        OCTAN98
    }



}

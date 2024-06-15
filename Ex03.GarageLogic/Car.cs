using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private CarColor m_CarColor;
        int m_NumberOfDoors;
        List<string> m_RequiredAttributesForCar = new List<string>()
        {
            "Car Color",
            "Number Of Doors",
            "Wheel 1 Manufactor:",
            "Wheel 1 Tyre Pressure:",
            "Wheel 2 Manufactor:",
            "Wheel 2 Tyre Pressure:",
            "Wheel 3 Manufactor:",
            "Wheel 3 Tyre Pressure:",
            "Wheel 4 Manufactor:",
            "Wheel 4 Tyre Pressure:",
        };


        public override List<string> GetRequiredData()
        {
            List<string> requiredData = base.GetRequiredData();
            requiredData.AddRange(m_RequiredAttributesForCar);
            return requiredData;
        }

        public override void UpdateAttributes(Dictionary<string, string> i_Attributes)
        {
            
        }

    }

    public enum CarColor
    {
        YELLOW,
        WHITE,
        BLACK,
        RED
    }

}

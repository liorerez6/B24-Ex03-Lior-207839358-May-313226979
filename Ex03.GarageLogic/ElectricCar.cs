using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private ElectricEngine m_Engine = new ElectricEngine();
       
        public override List<string> GetRequiredData()
        {
            List<string> requiredData = base.GetRequiredData();
            List<string> dataForElectricEngine = m_Engine.GetRequiredData();
            requiredData.AddRange(dataForElectricEngine);

            return requiredData;
        }




        public override void UpdateAttributes(Dictionary<string,string> i_Attributes)
        {
            base.UpdateAttributes(i_Attributes);
            m_battryLeft = ConsoleIO.GetBatteryLeft()
            //adding the data for electric engine
            List<string> dataForElectricEngine = m_Engine.GetRequiredData();
            ///
        }
    }
}

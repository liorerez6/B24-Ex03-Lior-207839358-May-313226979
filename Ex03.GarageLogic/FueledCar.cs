using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FueledCar : Car
    {
        private FuelEngine m_Engine = new FuelEngine();


        public override List<string> GetRequiredData()
        {
            List<string> requiredData = base.GetRequiredData();
            List<string> dataForFuledEngine = m_Engine.GetRequiredData();
            requiredData.AddRange(dataForFuledEngine);

            return requiredData;
        }
        public override void UpdateAttributes(Dictionary<string, string> i_Attributes)
        {
            base.UpdateAttributes(i_Attributes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class GarageEntry
    {
        private class OwnerInfo
        {
            private string m_OwnerName;
            private string m_OwnerPhone;

            public string OwnerName
            {
                get { return m_OwnerName; }
                set { m_OwnerName = value; }
            }
            public string OwnerPhone
            {
                get { return m_OwnerPhone; }
                set { m_OwnerPhone = value; }
            }
        }

        private Vehicle m_Vehicle;
        private OwnerInfo m_OwnerInfo;
        private VehicleStatus m_Status;

        public VehicleStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public GarageEntry(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerInfo = new OwnerInfo();
            m_OwnerInfo.OwnerName = i_OwnerName;
            m_OwnerInfo.OwnerPhone = i_OwnerPhone;
            m_Status = VehicleStatus.INREPAIR;
        }
    }
}
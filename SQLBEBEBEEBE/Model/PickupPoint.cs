using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBEBEBEEBE.Model
{
    internal class PickupPoint
    {
        public int PointID;
        public string PointAddress;

        public PickupPoint(int pointID, string pointAddress)
        {
            PointID = pointID;
            PointAddress = pointAddress;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleADO.Model
{
    class Model
    {
        public Guid ID { get; set; }
        public string _ModelName { get; set; }
        public int _Weight { get; set; }
        public string _Color { get; set; }
        public DateTime _DateOfMan { get; set; }
        public Guid? Id_vehicle { get; set; }
        public override string ToString()
        {
            return $"Name: {_ModelName} Color: {_Color} Weight: {_Weight} Relese Date: {_DateOfMan}";
        }
    }
}

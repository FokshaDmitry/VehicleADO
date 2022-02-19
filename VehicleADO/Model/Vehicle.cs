using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleADO.Model
{
    class Vehicle
    {
        public Guid Id { get; set; }
        public string _NameVehicle { get; set; }
        public double _MaxSpeed { get; set; }
        public int _MaxPassengers { get; set; }
        public int _MaxLoadCapacity { get; set; }
        public override string ToString()
        {
            return $"Name: {_NameVehicle} Max Speed: {_MaxSpeed} Max Passenger: {_MaxPassengers} Max Load Capasity: {_MaxLoadCapacity}";
        }
    }
}

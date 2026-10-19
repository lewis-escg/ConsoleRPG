using ConsoleRPG.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleRPG.Game
{
    public class LocationSystem
    {
        public List<Location> Locations = new();

        Location newLocation = new("Tower Exterior");
        Locations.Append(NewLocation);

        public Location CurrentLocation = Locations[0];
    }
}

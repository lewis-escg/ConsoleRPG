using ConsoleRPG.Classes;
using System;

namespace ConsoleRPG.Game
{
    public class LocationSystem
    {
        public void Initialize()
        {
            List<Location> Locations = new();


            Location newLocation = new Location("Tower Exterior");
            Locations.Add(newLocation);
            Location CurrentLocation = Locations[0];

        }
    }
}

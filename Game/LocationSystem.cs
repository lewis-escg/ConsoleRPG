using ConsoleRPG.Classes;
using System;

namespace ConsoleRPG.Game
{
    public class LocationSystem(Display.Display display)
    {
        private List<Location> Locations = new();
        private Location CurrentLocation;
        private int currentLocationIndex;
        private int direction = 2;
        private const int INITIAL_ALTITUDE = 500;
        public int Altitude;


        private void CreateLocation(string name, int index = -1)
        {
            Location newLocation = new Location(name, this);
            if (index >= 0) // we use a negative index to show no index was provided, or to catch cases where a negative index would throw an error and instead place it at the end of the locations list 
            {
                Locations.Insert(index, newLocation);
            }
            else
            {
                Locations.Add(newLocation);
            }
        }


        public void Initialize() // initialize all the locations in the game (currentlocation must also be set)
        {
            CreateLocation("Tower Exterior", 0);
            SetCurrentLocation(0);
            CreateLocation("Tower Exterior", 1);
            CreateLocation("Tower Exterior", 2);
            CreateLocation("Tower Exterior", 3);
        }


        public void Update(ConsoleKeyInfo? userInput)
        {
            CurrentLocation.Update(display, userInput);
            direction = CurrentLocation.Direction;
            Altitude = INITIAL_ALTITUDE + (currentLocationIndex * 5);
        }


        public Location getCurrentLocation()
        {
            return CurrentLocation;
        }


        public void SetCurrentLocation(int index)
        {
            try // use try/catch in case the index is out of range
            {
                CurrentLocation = Locations[index];
                currentLocationIndex = index;
                CurrentLocation.Direction = direction; // carry over previous direction
            }
            catch { }
        }


        public void OffsetLocation(int difference)
        {
            int newIndex = currentLocationIndex + difference;
            if (newIndex < 0) // if result index would be less than 0
            {
                newIndex = 0;
            }
            else if (newIndex > Locations.Count - 1) // if result index would be out of range
            {
                newIndex = Locations.Count - 1;
            }
            SetCurrentLocation(newIndex);
        }

    }
}

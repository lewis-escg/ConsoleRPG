using ConsoleRPG.Classes;
using System;

namespace ConsoleRPG.Game
{
    public class LocationSystem(Display.Display display)
    {
        private List<Location> Locations = new();
        private Location CurrentLocation;
        private int CurrentLocationIndex;

        private void CreateLocation(string name, int index = -1)
        {
            Location newLocation = new Location(name);
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
        }

        public void Update(ConsoleKeyInfo? userInput)
        {
            CurrentLocation.Update(display, userInput);
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
                CurrentLocationIndex = index;
            }
            catch { }
        }

        public void OffsetLocation(int difference)
        {
            int newIndex = CurrentLocationIndex + difference;
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

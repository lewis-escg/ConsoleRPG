using System;

namespace ConsoleRPG.Classes
{
    public class GameObject(string name)
    {
        public string Name = name;

        public virtual void Update(Display.Display display)
        {

        }
    }
}

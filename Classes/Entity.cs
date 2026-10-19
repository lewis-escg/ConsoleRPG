using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes
{
    public class Entity(string name) : GameObject(name)
    {
        public virtual int Health { get; set; } = 100;
        public virtual int MaxHealth { get; set; } = 100;
    }
}

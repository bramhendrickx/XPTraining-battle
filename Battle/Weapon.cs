using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    internal class Weapon
    {
        internal string Type { get; private set; }
        internal int DamagePoints { get; private set; }

        internal Weapon(string type)
        {
            Type = type;
            switch (type)
            {
                case "BareFist":
                    DamagePoints = 1;
                    break;
                case "Axe":
                    DamagePoints = 3;
                    break;
                case "Spear":
                case "Sword":
                    DamagePoints = 2;
                    break;
                default:
                    break;
            }
        }
    }
}

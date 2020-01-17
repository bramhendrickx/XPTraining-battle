using System;

namespace Battle
{
    public class Soldier
    {
        public string Name { get; }
        private Weapon Weapon { get; set; }

        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);
            Weapon = new Weapon("BareFist");
            Name = name;
        }
        public Soldier(string name, string weaponType)
        {
            ValidateNameisNotBlank(name);
            Weapon = new Weapon(weaponType);
            Name = name;
        }

        public string GetWeaponType()
        {
            return Weapon.Type;
        }
        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());


        public string Attack(Soldier defender)
        {
            if (defender.Weapon.DamagePoints > Weapon.DamagePoints)
            {
                return defender.Name;
            }
            return Name;
        }
    }
}
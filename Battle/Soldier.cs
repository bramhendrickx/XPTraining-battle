using System;

namespace Battle
{
    public class Soldier
    {
        public string Name { get; }
        public string Weapon { get; set; }

        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);
            Weapon = "Bare fist";
            Name = name;
        }

        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());
        
        
    }
}
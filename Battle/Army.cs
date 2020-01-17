using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Battle
{
    public class Army
    {
        public List<Soldier> Soldiers { get; private set; } = new List<Soldier>();
        public Soldier FrontMan { get; private set; }
        public string Name { get; private set; }

        public Army(string name)
        {
            Name = name;
        }
        public void Enlist(Soldier soldier)
        {
            Soldiers.Add(soldier);
            SetFrontMan(soldier);
        }

        internal void UpdateFrontMan()
        {
            FrontMan = Soldiers.FirstOrDefault();
        }

        internal void RemoveFrontMenFromList()
        {
            Soldiers.Remove(FrontMan);
        }
        private void SetFrontMan(Soldier soldier)
        {
            if (FrontMan == null)
            {
                FrontMan = soldier;
            }
        }

        public Army Attack(Army defendingArmy)
        {
            while (CanBattle(this,defendingArmy))
            {
                FrontManBattle(defendingArmy);
            }

            return FrontMan != null ? this : defendingArmy;
        }

        private void FrontManBattle(Army defendingArmy)
        {
            var frontmanWinner = FrontMan.Attack(defendingArmy.FrontMan);
            if (frontmanWinner.Equals(FrontMan))
            {
                defendingArmy.LostFrontMan();
                return;
            }

            LostFrontMan();
        }

        private bool CanBattle(Army attackingArmy, Army defendingArmy)
        {
            return attackingArmy.FrontMan != null && defendingArmy.FrontMan != null;
        }

        internal void LostFrontMan()
        {
            RemoveFrontMenFromList();
            UpdateFrontMan();
            
        }

    }
}

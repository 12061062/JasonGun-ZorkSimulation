using System;
namespace JailCellGame
{
    public class Weapon
    {
        public int damage;
        public string name;

        public string GetName()
        {
            return name;
        }

        public int GetDamage()
        {
            return damage;
        }

        public Weapon()
        {
            damage = 0;
        }
    }
}
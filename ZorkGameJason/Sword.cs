using System;
namespace JailCellGame
{
    public class Sword : Weapon
    {
        int swordDamage;

        public int GetDamage()
        {
            return this.swordDamage;
        }

        public void SetDamage(int swordDamage)
        {
            this.swordDamage = swordDamage;
        }

        public Sword() : base()
        {
            damage = 3;
            name = "Sword";
        }
    }
}
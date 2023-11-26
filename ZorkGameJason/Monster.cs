using System;
namespace JailCellGame
{
    public class Monster : Character
    {
        int health;
        int damage;

        public int GetHealth()
        {
            return this.health;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public int GetDamage()
        {
            return this.damage;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        public Monster() : base()
        {
            health = 20;
            damage = 4;
        }
    }
}
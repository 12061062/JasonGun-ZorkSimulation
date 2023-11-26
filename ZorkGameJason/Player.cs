using System;
namespace JailCellGame
{
    public class Player : Character
    {
        int health;
        int damage;
        int position;

        public int GetPosition()
        {
            return this.position;
        }

        public void SetPosition(int position)
        {
            this.position = position;
        }

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

        public Player() : base()
        {
            health = 100;
            damage = 5;
            position = 0;
        }
    }
}
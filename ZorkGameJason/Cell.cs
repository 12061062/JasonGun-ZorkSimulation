using System;
using System.Threading;

namespace JailCellGame
{
    public class Cell
    {
        string info { get; set; }

        bool monsterHere;
        Monster monster;
        bool weaponHere;
        Weapon weapon;

        public bool GetWeaponHere()
        {
            return this.weaponHere;
        }

        public Weapon GetWeapon()
        {
            return this.weapon;
        }

        public void SetWeapon()
        {
            Random randy = new Random();
            if (randy.Next(0, 10000) < 5000)
            {
                weapon = new Sword();
            }
            else
            {
                weapon = new Stick();
            }
        }

        public Monster GetMonster()
        {
            return monster;
        }

        public void SetWeaponHere(bool status)
        {
            weaponHere = status;
        }

        public bool GetMonsterHere()
        {
            return this.monsterHere;
        }

        public void SetMonsterHere(bool monsterHere)
        {
            this.monsterHere = monsterHere;
        }

        public Cell()
        {
            monsterHere = false;
            weaponHere = false;
            monster = null;
            weapon = null;
        }

        public Cell(bool monsterHere, Monster monster, bool weaponHere, Weapon weapon)
        {
            this.monsterHere = monsterHere;
            this.monster = monster;
            this.weaponHere = weaponHere;
            this.weapon = weapon;
        }

        public string AddPlayer()
        {
            info += "|_P_|";
            return info;
        }

        public string RemovePlayer()
        {
            info += "|___|";
            return info;
        }

        public string AddMonster()
        {
            info += "|_M_|";
            return info;
        }

        public string RemoveMonster()
        {
            info += "|___|";
            return info;
        }

        public string AddWeapon()
        {
            info += "|_W_|";
            return info;
        }

        public string RemoveWeapon()
        {
            info += "|___|";
            return info;
        }

        public override string ToString()
        {
            info += "|___|";
            return info;
        }
    }
}
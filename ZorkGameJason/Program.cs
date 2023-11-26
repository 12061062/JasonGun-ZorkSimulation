
using System;
using System.Numerics;
using System.Threading;

namespace JailCellGame
{
    public class Program
    {
        public static void Main()
        {
            ///Welcomes user
            Console.WriteLine("--------------------------");
            Console.WriteLine("Welcome To Prison Escape!");
            Console.WriteLine("--------------------------\n");

            Console.WriteLine("Your job is to escape the prison... you might encounter monsters or weapons to help you on your journey!\nKEY: \n'P' = Player\n'M' = Monster\n'St' = Stick\n'Sw' = Sword\n");

            int cellNum = 0;

            //Make random number of cells
            Random random = new Random();
            cellNum = random.Next(5, 11);

            List<Cell> dungeon = new List<Cell>();

            Console.WriteLine($"Your prison has {cellNum} cells!\n");

            Cell cell = new Cell();
            Player player = new Player();

            ///Add the cells to the dungeon
            for (int i = 0; i < cellNum; i++)
            {
                if (i == 0)
                {
                    dungeon.Add(new Cell());
                }
                else if (i != 0)
                {
                    bool weaponHere = false;
                    bool monsterHere = false;
                    Monster returnMonster = null;
                    Weapon returnWeapon = null;
                    Random rand = new Random();

                    if (rand.Next(10000) < 5000)
                    {
                        monsterHere = true;
                        returnMonster = new Monster();
                    }

                    dungeon.Add(new Cell(monsterHere, returnMonster, weaponHere, returnWeapon));
                }
            }

            Random rando = new Random();
            int weaponPosition = rando.Next(1, cellNum);
            dungeon[weaponPosition].SetWeaponHere(true);
            dungeon[weaponPosition].SetWeapon();

            bool escaped = false;
            while (player.GetHealth() > 0 && escaped == false)
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"{ToString(dungeon, player)}");
                Console.WriteLine("--------------------------------------------------------------\n");
                Console.WriteLine($"Your remaining health points: {player.GetHealth()}");
                Console.WriteLine("What would you like to do, 'east' or 'west'");
                string userInput = (Console.ReadLine());
                userInput = userInput.ToLower();

                try
                {
                    switch (userInput)
                    {
                        case "west":
                            int playerPositionWest = player.GetPosition() - 1;
                            player.SetPosition(playerPositionWest);

                            if (player.GetPosition() == -1)
                            {
                                player.SetPosition(0);
                            }

                            break;

                        case "east":
                            int playerPositionEast = player.GetPosition() + 1;
                            player.SetPosition(playerPositionEast);

                            if (player.GetPosition() > cellNum - 1)
                            {
                                Console.WriteLine("Congrats! You've survived Zork!!!");
                                escaped = true;
                                break;
                            }
                            else if (dungeon[player.GetPosition()].GetWeaponHere() == true)
                            {
                                Console.WriteLine($"There's a weapon in this cell, it's a {dungeon[player.GetPosition()].GetWeapon().GetName()}, you do {dungeon[player.GetPosition()].GetWeapon().GetDamage()} more damage");
                                player.SetDamage(player.GetDamage() + dungeon[player.GetPosition()].GetWeapon().GetDamage());
                                dungeon[player.GetPosition()].SetWeaponHere(false);
                            }

                            if (dungeon[player.GetPosition()].GetMonsterHere() == true)
                            {
                                Console.WriteLine("There's a monster in this Cell!");

                                do
                                {
                                    Random randMonsterDamage = new Random();
                                    Random randPlayerDamage = new Random();
                                    int newMonsterHealth = randPlayerDamage.Next(1, 11);
                                    int newPlayerHealth = randMonsterDamage.Next(1, 11);

                                    //Player's Turn
                                    if (newMonsterHealth > 1)
                                    {
                                        Console.WriteLine($"You hit the Monster!\nYou did {player.GetDamage()} damage!");
                                        dungeon[player.GetPosition()].GetMonster().SetHealth(dungeon[player.GetPosition()].GetMonster().GetHealth() - player.GetDamage());
                                        Console.WriteLine($"The monster has {dungeon[player.GetPosition()].GetMonster().GetHealth()} health remaining");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You missed!");
                                    }

                                    //Monster's Turn
                                    if (newPlayerHealth > 2 && dungeon[player.GetPosition()].GetMonster().GetHealth() > 0)
                                    {
                                        Console.WriteLine($"The Monster hit you!\nIt has done {dungeon[player.GetPosition()].GetMonster().GetDamage()} damage");
                                        player.SetHealth(player.GetHealth() - dungeon[player.GetPosition()].GetMonster().GetDamage());
                                        Console.WriteLine($"You have {player.GetHealth()} health remaining");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The Monster missed you!");
                                    }

                                    if (dungeon[player.GetPosition()].GetMonster().GetHealth() <= 0)
                                    {
                                        Console.WriteLine("The Monster is dead!");
                                        dungeon[player.GetPosition()].SetMonsterHere(false);
                                    }

                                } while (dungeon[player.GetPosition()].GetMonster().GetHealth() > 0 && player.GetHealth() > 0);
                            }
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter 'east' or west' exactly");
                }
            }
            Console.ReadKey();
        }

        public static string ToString(List<Cell> cells, Player player)
        {
            string info = "";
            for (int i = 0; i < cells.Count; i++)
            {
                if (i == 0 && player.GetPosition() == 0)
                {
                    info += "|P___|";
                }
                else if (i == 0)
                {
                    info += "|____|";
                }
                else if (i > 0 && player.GetPosition() == i)
                {
                    info += "|P___|";
                }
                else if (i > 0 && cells[i].GetMonsterHere() == true && cells[i].GetWeaponHere() == true)
                {
                    if (cells[i].GetWeapon().GetName() == "Stick")
                    {
                        info += "|M_St|";
                    }
                    else
                    {
                        info += "|M_Sw|";
                    }
                }
                else if (i > 0 && cells[i].GetMonsterHere() == true)
                {
                    info += "|_M__|";
                }
                else if (i > 0 && cells[i].GetWeaponHere() == true)
                {
                    if (cells[i].GetWeapon().GetName() == "Stick")
                    {
                        info += "|__St|";
                    }
                    else
                    {
                        info += "|__Sw|";
                    }
                }
                else
                {
                    info += "|____|";
                }
            }
            return info;
        }
    }
}
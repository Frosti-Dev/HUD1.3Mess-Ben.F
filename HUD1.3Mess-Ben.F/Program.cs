using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HUDv1._2Project_BenF
{
    internal class Program
    {
        //variables
        static int weaponnum = 0;

        enum weaponType
        {
            Pistol = 0,
            Shotgun = 1,
            Spreader = 2,
            Laser = 3,
            Sniper = 4,
        }

        static weaponType weapon = weaponType.Pistol;

        static int health = 100;
        static int enemyHealth = 100;


        static weaponType CurWeapon(int weaponchange)
        {
            if (weaponchange == 0)
            {
                return weaponType.Pistol;
            }
            else if (weaponchange == 1)
            {
                return weaponType.Shotgun;
            }
            else if (weaponchange == 2)
            {
                return weaponType.Spreader;
            }
            else if (weaponchange == 3)
            {
                return weaponType.Laser;
            }
            else
            {
                return weaponType.Sniper;
            }

        }

        static int ChangeWeapon(int weapon)
        {
            weaponnum = weapon;
            return weaponnum;
        }

        static int Heal(int amount)
        {
            health += amount;
            return health;
        }

        static int TakeDamage(int amount)
        {
            health -= amount;
            return health;
        }

        static string HealthCheck(int amount)
        {
            health = amount;

            if (health == 100)
            {
                string state = "Perfectly Healthy";
                return state;
            }
            else if (health > 75)
            {
                string state = "Healthy";
                return state;
            }
            else if (health > 50)
            {
                string state = "Hurt";
                return state;
            }
            else if (health > 10)
            {
                string state = "Badly Hurt";
                return state;
            }
            else if (health < 10)
            {
                string state = "Immident Danger";
                return state;
            }

            else if (health == 0)
            {
                string state = "Dead";
                return state;
            }

            else
            {
                string state = "what are you?";
                return state;
            }
        }

        static void DealDamage(int amount)
        {
            Console.WriteLine($"The enemy health is at {enemyHealth}. You deal {amount}.");

            enemyHealth -= amount;

            Console.WriteLine($"The enemy now has {enemyHealth} health.");
        }

        static void ShowHUD()
        {
            if (health < 25)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0,0}{1,30}", $"Health: {HealthCheck(health)}", $"Weapon: {CurWeapon(weaponnum)}");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,0}{1,30}", $"Health: {HealthCheck(health)}", $"Weapon: {CurWeapon(weaponnum)}");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        static void ReadInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    ShowHUD();
                    DealDamage(20);
                    return;

                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    ShowHUD();
                    Console.WriteLine("You Block!");
                    TakeDamage(0);
                    return;

                case ConsoleKey.RightArrow:
                    Console.Clear();
                    ChangeWeapon(2);
                    TakeDamage(35);
                    ShowHUD();
                    Console.WriteLine("You get hit for 35 DMG");
                    Console.WriteLine($"You've switched to {CurWeapon(weaponnum)}");
                    return;
            }
        }

        static void Main(string[] args)
        {
            //start (event 1)
            ShowHUD();
            Console.WriteLine("A scarrryy enemy appears!");
            ReadInput();

        }
    }
}
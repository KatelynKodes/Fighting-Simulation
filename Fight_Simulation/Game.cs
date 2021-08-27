using System;
using System.Collections.Generic;
using System.Text;

namespace Fight_Simulation
{
    class Game
    {
        public void Run()
        {
            //Monster 1 Stats
            Monster Monster1;
            Monster1.name = "Whompus";
            Monster1.health = 100f;
            Monster1.Attk = 50f;
            Monster1.Def = 10f;

            //Monster 2 Stats
            Monster Monster2;
            Monster2.name = "Glompus";
            Monster2.health = 100f;
            Monster2.Attk = 40f;
            Monster2.Def = 20f;

            //Printing stats
            PrintStats(Monster1);
            PrintStats(Monster2);

            //Fight
            float damagetaken = fight(ref Monster1, ref Monster2);
            Console.WriteLine("Monster 1 attacks monster 2");
            Console.WriteLine(Monster2.name + " takes " + damagetaken + " damage");

            damagetaken = fight(ref Monster2, ref Monster1);
            Console.WriteLine("Monster 2 attacks monster 1");
            Console.WriteLine(Monster1.name + " takes " + damagetaken + " damage");

            Console.ReadKey();
            Console.Clear();

            //Printing stats
            PrintStats(Monster1);
            PrintStats(Monster2);
            Console.ReadKey();
        }

        /// <summary>
        /// Subtracts the health of the monster defender from the damage calculated from the Calculate Damage Method
        /// </summary>
        /// <param name="MonsterAttacker"></param>
        /// <param name="MonsterDefender"></param>
        /// <returns></returns>
        float fight( ref Monster MonsterAttacker, ref Monster MonsterDefender)
        {
            float damagetaken = CalculateDamage(MonsterAttacker, MonsterDefender);
            MonsterDefender.health = MonsterDefender.health - damagetaken;
            return damagetaken;
        }
        void PrintStats(Monster monster)
        {
            Console.WriteLine(monster.name + "\nHealth: " + monster.health + "\nAttack: " + monster.Attk + "\nDefense: " + monster.Def);
        }

        /// <summary>
        /// Takes the value of attack and defense and subtracts defense from attack
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;
            if (damage <= 0)
            {
                return 0;
            }
            else
            {
                return damage;
            }
        }

        float CalculateDamage(Monster attacker, Monster defender)
        {
            return attacker.Attk - defender.Def;
        }

        struct Monster
        {
            public string name;
            public float health;
            public float Attk;
            public float Def;
        }
    }
}



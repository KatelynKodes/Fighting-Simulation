using System;
using System.Collections.Generic;
using System.Text;

namespace Fight_Simulation
{
    class Game
    {
        bool gameover;
        Monster CurrentMonster1;
        Monster CurrentMonster2;
        int CurrentMonsterIndex;
        Monster Monster1;
        Monster Monster2;
        Monster Monster3;
        Monster Monster4;

        public void Run()
        {
            //Monster 1 Stats
            Monster1.name = "Whompus";
            Monster1.health = 100f;
            Monster1.Attk = 50f;
            Monster1.Def = 10f;

            //Monster 2 Stats
            Monster2.name = "Glompus";
            Monster2.health = 100f;
            Monster2.Attk = 40f;
            Monster2.Def = 20f;

            
            Monster3.name = "backup Whompus";
            Monster3.health = 300f;
            Monster3.Attk = 25.6f;
            Monster3.Def = 5f;

            
            Monster4.name = "Uncle Phil";
            Monster4.health = 150f;
            Monster4.Attk = 30f;
            Monster4.Def = 40;
        }

        void Update()
        {
            Battle();

        }

        Monster GetMonster(int MonsterIndex)
        {
            Monster PlaceHolderMonster;
            PlaceHolderMonster.name = "none";
            PlaceHolderMonster.health = 0f;
            PlaceHolderMonster.Attk = 0f;
            PlaceHolderMonster.Def = 0f;

            if (MonsterIndex == 1)
            {
                return Monster1;
            }
            else if (MonsterIndex == 2)
            {
                return Monster2;
            }
            else if (MonsterIndex == 3)
            {
                return Monster3;
            }
            else if (MonsterIndex == 4)
            {
                return Monster4;
            }
        }

        void Battle()
        {
            //Printing stats
            PrintStats(CurrentMonster1);
            PrintStats(CurrentMonster2);
            Console.ReadKey(true);

            //Fight
            Console.Clear();
            float damagetaken = fight(ref CurrentMonster1, ref CurrentMonster2);
            Console.WriteLine("Monster 1 attacks monster 2");
            Console.WriteLine(CurrentMonster2.name + " takes " + damagetaken + " damage");

            damagetaken = fight(ref CurrentMonster2, ref CurrentMonster1);
            Console.WriteLine("Monster 2 attacks monster 1");
            Console.WriteLine(CurrentMonster1.name + " takes " + damagetaken + " damage");

            Console.ReadKey(true);
            Console.Clear();
        }

        void UpdateCurrentMonsters()
        {

        }

        string StartBattle(Monster Monstr1, Monster Monstr2)
        {
            string matchresult = "draw";

            while (Monstr1.health > 0 && Monstr2.health > 0)
            {
                //Printing stats
                PrintStats(Monstr1);
                PrintStats(Monstr2);
                Console.ReadKey(true);

                //Fight
                Console.Clear();
                float damagetaken = fight(ref Monstr1, ref Monstr2);
                Console.WriteLine("Monster 1 attacks monster 2");
                Console.WriteLine(Monstr2.name + " takes " + damagetaken + " damage");

                damagetaken = fight(ref Monstr2, ref Monstr1);
                Console.WriteLine("Monster 2 attacks monster 1");
                Console.WriteLine(Monstr1.name + " takes " + damagetaken + " damage");

                Console.ReadKey(true);
                Console.Clear();
            }

            //Checks which monster won, if any
            if (Monstr1.health <= 0 && Monstr2.health <= 0)
            {

                matchresult = "Neither Monster survived the encounter";
                
            }
            else if (Monstr2.health > 0)
            {
                matchresult = "The winner is " + Monstr2.name + "!";
            }
            else
            {
                matchresult = "The winner is " + Monstr1.name + "!";
            }

            //Prints out the winner
            Console.WriteLine(matchresult);
            Console.ReadKey(true);
            Console.Clear();
            return matchresult;
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

        /// <summary>
        /// Prints stats to console.
        /// </summary>
        /// <param name="monster"></param>
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



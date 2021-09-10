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
        int CurrentMonsterIndex = 0;
        Monster Monster1;
        Monster Monster2;
        Monster Monster3;
        Monster Monster4;

        Monster[] AllMonsters;

        int currentscene = 0;

        int[] NumberArray = new int[6] { 1, 2, 3, 4, 5, 6 };


        void Start()
        {
            ResetCurrentMonsters();
        }

        public void Run()
        {

            Start();
            while (!gameover)
            {
                Update();
            }
            End();
        }
        void Update()
        {
            UpdateCurrentScene();
        }

        void End()
        {
            Console.WriteLine("Bye-Bye :)");
        }

        /// <summary>
        /// Resets the monsters to their original values and the currentMonsterIndex
        /// </summary>
        void ResetCurrentMonsters()
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
            Monster3.health = 200f;
            Monster3.Attk = 25.6f;
            Monster3.Def = 5f;


            Monster4.name = "Uncle Phil";
            Monster4.health = 150f;
            Monster4.Attk = 30f;
            Monster4.Def = 40;

            AllMonsters = new Monster[] { Monster1, Monster2, Monster3, Monster4 };

            CurrentMonsterIndex = 0;
            CurrentMonster1 = AllMonsters[CurrentMonsterIndex];
            CurrentMonsterIndex++;
            CurrentMonster2 = AllMonsters[CurrentMonsterIndex];
        }

        /// <summary>
        /// Updates the current scene
        /// </summary>
        void UpdateCurrentScene()
        {
            switch (currentscene)
            {
                case 0:
                    DisplayStartMenu();
                    break;
                case 1:
                    Battle();
                    UpdateCurrentMonsters();
                    Console.ReadKey(true);
                    break;
                case 2:
                    DisplayRestartMenu();
                    break;
                default:
                    Console.WriteLine("Invalid scene Index");
                    break;

            }
        }

        /// <summary>
        /// Presents the player with an option to start the game
        /// </summary>
        void DisplayStartMenu()
        {
            int choice = GetInput("Welcome to Monster Fight Club simulator, featuring Uncle Phil. Would you like to begin?", "Yes", "No");

            if (choice == 1)
            {
                //starts game
                currentscene = 1;
            }
            else if (choice == 2)
            {
                //Ends game
                gameover = true;
            }
        }

        /// <summary>
        /// Presents the player with an option to start the game
        /// </summary>
        void DisplayRestartMenu()
        {
            int choice = GetInput("Would you like to play again?", "Yes", "No");

            if (choice == 1)
            {

                //Restarts game
                currentscene = 0;
                ResetCurrentMonsters();
            }
            else if (choice == 2)
            {
                //Ends game
                gameover = true;
            }
        }


        /// <summary>
        /// Allows the player to make a choice based on a question
        /// </summary>
        /// <param name="Desc"></param>
        /// <param name="Option1"></param>
        /// <param name="Option2"></param>
        /// <param name="PauseInvalid"></param>
        /// <returns></returns>
        int GetInput(string Desc, string Option1, string Option2, bool PauseInvalid = false)
        {
            //Writes out the question and the options
            Console.WriteLine(Desc + "\n [1]" + Option1 + "\n [2]" + Option2);
            Console.Write(">");
            string input = Console.ReadLine();
            int choice = 0;

            //Determines if the input is valid. If not, the loop repeats
            if (input == "1")
            {
                choice = 1;
            }
            else if (input == "2")
            {
                choice = 2;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                //Determines if there is a pause after an invalid input.
                if (PauseInvalid)
                { 
                    Console.ReadKey(true);
                }
            }

            return choice;
        }

        /// <summary>
        /// Gets a monster by the monsterindex
        /// </summary>
        /// <param name="MonsterIndex"></param>
        /// <returns></returns>
        Monster GetMonster(int MonsterIndex)
        {
            Monster PlaceHolderMonster;
            PlaceHolderMonster.name = "none";
            PlaceHolderMonster.health = 0f;
            PlaceHolderMonster.Attk = 0f;
            PlaceHolderMonster.Def = 0f;

            if (MonsterIndex == 0)
            {
                PlaceHolderMonster = Monster1;
            }
            else if (MonsterIndex == 1)
            {
                PlaceHolderMonster = Monster2;
            }
            else if (MonsterIndex == 2)
            {
                PlaceHolderMonster = Monster3;
            }
            else if (MonsterIndex == 3)
            {
                PlaceHolderMonster = Monster4;
            }

            return PlaceHolderMonster;
        }


        /// <summary>
        /// The main battle function where monsters fight
        /// </summary>
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

        bool TryEndSimulation()
        {
            bool SimulationOver = CurrentMonsterIndex >= AllMonsters.Length;

            if (SimulationOver)
            {
                currentscene = 2;
            }
            return SimulationOver;
        }

        /// <summary>
        /// Updates the current monsters based on their health status or ends the game if simulation has ended
        /// </summary>
        void UpdateCurrentMonsters()
        {
            if (CurrentMonster1.health <= 0)
            {
                CurrentMonsterIndex++;
                if (TryEndSimulation())
                {
                    return;
                }
                CurrentMonster1 = AllMonsters[CurrentMonsterIndex];
            }
            if (CurrentMonster2.health <= 0)
            {
                CurrentMonsterIndex++;
                if (TryEndSimulation())
                {
                    return;
                }
                CurrentMonster2 = AllMonsters[CurrentMonsterIndex];
            }
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

        /// <summary>
        /// Takes the value of attack and defense and subtracts defense from attack
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        float CalculateDamage(Monster attacker, Monster defender)
        {
            if (attacker.Attk > defender.Def)
            {
                return attacker.Attk - defender.Def;
            }
            else
            {
                return 0f;
            }
        }

        struct Monster
        {
            public string name;
            public float health;
            public float Attk;
            public float Def;
        }


        /// <summary>
        /// Array Method, lodis excercise.
        /// </summary>
        /// <param name="array"></param>
        void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        void LargestAndSmallest(int[] arr)
        {
            int LargestNum = arr[0];
            int SmallestNum = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > LargestNum)
                {
                    LargestNum = arr[i];
                }
                else if (arr[i] < SmallestNum)
                {
                    SmallestNum = arr[i];
                }
            }

            Console.WriteLine("The largest number in this array is "  + LargestNum);
            Console.WriteLine("The smallest number in this array is " + SmallestNum);
        }
    }
}



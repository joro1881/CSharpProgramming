using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaid
{
    class Enemies
    {
        private static Random rand = new Random();
        public static List<List<int>> enemies = new List<List<int>>();
        public static char [] enemySymbol = {'<','@','>'} ;     

        //method for generating random cordinates 
        public static void GenerateRandomEnemy()
        {          
            int randEnemyPosition = rand.Next(16, 36);//boundaries 
            List<int> randEnemyCordinates = new List<int>()
            { 
                randEnemyPosition, 1//we give horizantal cordinates and vertical cor 1
            };
            enemies.Add(randEnemyCordinates);// adding the cordinates to the list 
        }

        //method for Console print the enemy 
        public static void DrawEnemies()
        {
            foreach (List<int> enemy in enemies)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; //enemy color
                Console.SetCursorPosition(enemy[0], enemy[1]);//using the list enemies for printing
                Console.Write(enemySymbol);// print
            }
        }

        //method for update the moving of the enemy down to the river 
        public static void EnemyMoving()
        {
            // two cycles, one for add +1 to vertical moving, second for removing the enemy when is out of boundaries
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i][1] = enemies[i][1] + 1;
            }

            int index = -1;

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i][1] >= 25)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)//we found enemy that is out of the boundaries and now we have to remove it
            {
                enemies.RemoveAt(index);
            }
        }
        public static void EnemyMovingLeftRight()
        {
            int pointer = rand.Next(1, 1000); // i am using the rand from the GenerateRandomEnemy() because of stable point for randomization

            for (int i = 0; i < enemies.Count-1; i++)
            {
                //we will use some cycle to moving all enemy []char elements
                // for moving left-right we will chose [0] cordinate
                if (enemies[i][0] == 16 && enemies[i][0] == 15 && enemies[i][0] == 17)//i think with that logic if the enemy touch the left land will move to right
                {
                    enemies[i][0] = enemies[i][0] + 1;
                }
                if (enemies[i][0] == 34 && enemies[i][0] == 35 && enemies[i][0] == 33)// same here if touch the right land, will move to left
                {
                    enemies[i][0] = enemies[i][0] - 1;
                }
                if (pointer > 500 )//i am using the random pointer to decide they way // left
                {
                    enemies[i][0] = enemies[i][0] - 1;
                }
                if (pointer < 500 )// right
                {
                    enemies[i][0] = enemies[i][0] + 1;
                }
            }                    
        }
        //removing all enemies instantly
        //for colusions
        public static void RemoveAllEnemies()
        {
            enemies.Clear();            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Speech.Synthesis;

namespace RiverRaid
{
    public struct Element // generic enough
    {
        public string width;
        public int x;
        public int y;
        public ConsoleColor color;
    }

    class RiverRaid
    {
        static int currentRand = 0; // variable with the current state of the random number
        static int nextRand = 0; // variable storing the next random number
        const int ConsoleWidth = 50; // dimensions of console screen, can be changed; width
        const int ConsoleHeight = 30; // height

        static void Main()
        {
            DrawIntro(); //Method for drawing the ASCII art at the begining
            Console.BackgroundColor = ConsoleColor.DarkBlue; // set default background color

            //Sound initialization:
            SpeechSynthesizer synth = new SpeechSynthesizer(); // creates new synthesizer 
            synth.SetOutputToDefaultAudioDevice(); // Redirect audio to default device

            //Sound demo: 
            //synth.Speak("Team Robin Hood Presents: River Raid"); //Just testing audio

            Console.BufferHeight = Console.WindowHeight = ConsoleHeight; // set size of the console screen
            Console.BufferWidth = Console.WindowWidth = ConsoleWidth;
            List<Element> landmass = new List<Element>(); // creates the list containing the "shore"
            List<Element> shots = new List<Element>();
            Fighter airplane = new Fighter(Console.WindowWidth / 2, Console.WindowHeight - 8);
            int counter = 0; // count the steps for randomization purposes
            uint score = 0;
            while (true)
            {
                counter++;
                //                airplane.FuelManage();
                DrawScorefield();
                if (counter == 5)//set one enemy every 10 cycles
                {
                    Enemies.GenerateRandomEnemy(); // generate the enemy cordinates ( a new enemy every cicle) 
                }
                Enemies.EnemyMoving();//enemy moving down to the console
                Enemies.EnemyMovingLeftRight(); // enemy moving left, right, with random step
                //!!       //I dont know why my enemies start moving right-left after one or two full cycles(10-20) 
                int current = 0;
                //                airplane.MoveFighter();
                List<Element> newList = new List<Element>(); // new list for storing temporary objects
                for (int i = 0; i < landmass.Count; i++)
                {
                    Element oldEl = landmass[i];
                    Element el = new Element();
                    el.y = oldEl.y + 1;
                    el.x = oldEl.x;
                    el.width = oldEl.width;
                    current = el.width.Length;
                    // it doesn't work properly if I let the terrain reach the bottom of the screen
                    //we can use the bottom space for system information - score, lives, fuel etc.
                    if (el.y < ConsoleHeight - 5)
                        newList.Add(el);
                }
                landmass = newList;

                List<Element> tempShots = new List<Element>();
                for (int i = 0; i < shots.Count; i++)
                {
                    Element oldEl = shots[i];
                    Element el = new Element();
                    el.y = oldEl.y - 1;
                    el.x = oldEl.x;
                    el.width = oldEl.width;
                    if (el.y >= 0)
                        tempShots.Add(el);
                }
                shots = tempShots;

                try
                {
                    for (int i = 0; i < shots.Count; i++)
                    {
                        var enemies = Enemies.enemies;
                        for (int j = 0; j < enemies.Count; j++)
                        {
                            if ((shots[i].x >= enemies[j][0]) && (shots[i].x <= enemies[j][0] + (Enemies.enemySymbol.Length - 1))
                                && (shots[i].y == enemies[j][1]))
                            {
                                shots.RemoveAt(i);
                                enemies.RemoveAt(j);
                                score += 10;
                                Console.Beep(); //Play sound when the enemy is hit
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Clear(); // very important
                Element tempLand = new Element();
                tempLand.x = 0;
                tempLand.y = 0;
                tempLand.width = LandGenerator(counter, current);
                Element tempLandRight = tempLand; // mirror the right shore
                tempLandRight.x = ConsoleWidth - tempLandRight.width.Length; // and place it accordingly
                landmass.Add(tempLand);
                landmass.Add(tempLandRight);

                airplane.DrawFighter();

                Controls(airplane, shots);

                foreach (var missile in shots)
                {
                    PrintShots(missile.x, missile.y, missile.width);
                }

                Enemies.DrawEnemies(); //printing the enemy on the  console
                Console.ForegroundColor = ConsoleColor.White; // Set color for player information
                PrintStringAtPos("Lives: ", 2, Console.WindowHeight - 4, airplane.Lives.ToString());
                PrintStringAtPos("Score: ", 2, Console.WindowHeight - 3, score.ToString());

                foreach (var element in landmass)
                {
                    PrintLand(element.x, element.y, element.width);
                    ColisionWithWallsCheck(element, airplane, landmass, shots, score);
                }
                EnemyCollisions(airplane, shots, score);
                DrawScorefield();
                Thread.Sleep(200); // controls game speed - lower is faster
                if (counter == 10) // reset the counter when reaching 10 so it doesn't overflow at some point
                {
                    counter = 1;
                }
            }
        }

        static void PrintLand(int x, int y, string shape)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(shape);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        static void PrintShots(int x, int y, string shape)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(shape);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static string LandGenerator(int row, int currentLength = 0)
        {
            int upperLimit = 16; // upper limit of randomization; the greatest width the land mass will be
            int lowerLimit = 1; // lower limit of randomization; the minimum width of the land mass
            Random randWidth = new Random();
            int landWidth = randWidth.Next(lowerLimit, upperLimit);
            if (currentRand == 0)
            {
                currentRand = landWidth;
            }
            if (nextRand == 0)
            {
                nextRand = randWidth.Next(lowerLimit, upperLimit);
            }
            if (currentLength != 0)
            {
                if (row % 10 == 9 || row % 10 == 1)
                {
                    if (nextRand > currentLength)
                    {
                        landWidth = currentLength + ((nextRand - currentLength) / 2);
                    }
                    else if (currentLength > nextRand)
                    {
                        landWidth = nextRand + ((currentLength - nextRand) / 2);
                    }
                    else // they're equal
                    {
                        landWidth = currentLength;
                    }
                }
                else if (row % 10 == 0)
                {
                    landWidth = nextRand;
                    currentRand = landWidth;
                    nextRand = randWidth.Next(lowerLimit, upperLimit);
                }
                else // none of those cases
                {
                    landWidth = currentLength;
                }
            }
            string land = new string(' ', landWidth);
            return land;
        }

        private static void EnemyCollisions(Fighter airplane, List<Element> shots, uint score)
        {
            var enemies = Enemies.enemies;
            var enemyLenght = Enemies.enemySymbol.Length - 1;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (((airplane.XCoord <= enemies[i][0] && airplane.XCoord + 2 >= enemies[i][0])
                    ||
                    ((airplane.XCoord <= enemies[i][0] + enemyLenght) && (airplane.XCoord + 2 >= enemies[i][0] + enemyLenght)))
                    &&
                    (airplane.YCoord + 1 == enemies[i][1] || airplane.YCoord == enemies[i][1] ||
                     airplane.YCoord + 2 == enemies[i][1]))
                {
                    PlayerDeath(airplane, shots, score);
                }
            }
        }

        private static void PlayerDeath(Fighter airplane, List<Element> shots, uint score)
        {
            try
            {
                airplane.Lives--;
                airplane.XCoord = Console.WindowWidth / 2 - 1;
                Enemies.RemoveAllEnemies();
                Console.Clear();
                shots.Clear();
            }
            catch (ArgumentOutOfRangeException)
            {
                SaveScore(score);
            }
        }

        static void SaveScore(uint score)
        {
            //Speak the scores:
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Game Over! Your score is " + score + " points");

            DrawGameOver(score); //Draw the ASCII art instead and speak the scores
            
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 1);
            Console.WriteLine("GAME OVER!");
            Console.Write("Enter your name: "); //Looks better if the name is on the same row
            string playerName = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter("../../Scoreboard.txt", true))
            {
                sw.WriteLine("{0}\t\t\t{1}", playerName, score);
            }
            DisplayScoreFile(score, playerName);
        }

        private static void DisplayScoreFile(uint playerScore, string playerName)
        {
            using (StreamReader sr = new StreamReader("../../Scoreboard.txt"))
            {
                Console.WriteLine(new string('-', 40) + Environment.NewLine + "Scoreboard:" +
                                  Environment.NewLine + new string('-', 40) + Environment.NewLine);
                List<string> namesList = new List<string>();
                List<uint> scoresList = new List<uint>();
                for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
                {
                    int counter = 1;
                    var m = Regex.Match(line, @"(^[\w\s]+?(?=\t)).*?(\d+)"); // extract from the line the name and the score
                    namesList.Add(m.Groups[1].Value); // add the name to the names list
                    scoresList.Add(uint.Parse(m.Groups[2].Value)); // add the score to the scores list
                    counter++;
                }
                // turn the lists into arrays
                uint[] points = scoresList.ToArray();
                string[] names = namesList.ToArray();
                Array.Sort(points, names); // sort the arrays
                bool current = true;
                for (int i = names.Length - 1; i >= 0; i--) // and print the names along with their corresponding scores
                {
                    if (names[i] == playerName && points[i] == playerScore)
                    {
                        if (current)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        current = false;
                    }
                    Console.Write(names[i]);
                    Console.CursorLeft = Console.BufferWidth - 6;
                    Console.WriteLine(points[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Environment.Exit(0);
        }

        private static void Controls(Fighter airplane, List<Element> shots)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true); //Escapes holding arrows pressed problem.
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    airplane.MoveLeft();
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    airplane.MoveRight();
                }
                else if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    Shoot(airplane, shots);
                }
            }
        }

        private static void Shoot(Fighter airplane, List<Element> shots)
        {
            Element shot = new Element();
            shot.x = airplane.XCoord + 1;
            shot.y = airplane.YCoord - 1;
            shot.width = "!";
            shot.color = ConsoleColor.White;
            shots.Add(shot);
        }

        public static void ColisionWithWallsCheck(Element land, Fighter airplane, List<Element> listEl, List<Element> shots, uint score)
        {
            if ((airplane.XCoord + 1 <= land.width.Length || airplane.XCoord + 2 >= Console.WindowWidth - land.width.Length) &&
                (airplane.YCoord + 1 == land.y || airplane.YCoord == land.y || airplane.YCoord + 2 == land.y))
            {
                PlayerDeath(airplane, shots, score);
            }
        }

        public static void PrintStringAtPos(string text, int x, int y, string value)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text + " " + value);
        }

        static void DrawScorefield()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                PrintStringAtPos("\"", i, Console.WindowHeight - 5, "");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void DrawIntro()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"
                 .___________. _______     ___      .___  ___. 
                 |           ||   ____|   /   \     |   \/   | 
                 `---|  |----`|  |__     /  ^  \    |  \  /  | 
                     |  |     |   __|   /  /_\  \   |  |\/|  | 
                     |  |     |  |____ /  _____  \  |  |  |  | 
                     |__|     |_______/__/     \__\ |__|  |__| 
                                                              
                .______        ______   .______    __  .__   __. 
                |   _  \      /  __  \  |   _  \  |  | |  \ |  | 
                |  |_)  |    |  |  |  | |  |_)  | |  | |   \|  | 
                |      /     |  |  |  | |   _  <  |  | |  . `  | 
                |  |\  \----.|  `--'  | |  |_)  | |  | |  |\   | 
                | _| `._____| \______/  |______/  |__| |__| \__| 
                                                                 
                   __    __    ______     ______    _______  
                  |  |  |  |  /  __  \   /  __  \  |       \ 
                  |  |__|  | |  |  |  | |  |  |  | |  .--.  |
                  |   __   | |  |  |  | |  |  |  | |  |  |  |
                  |  |  |  | |  `--'  | |  `--'  | |  '--'  |
                  |__|  |__|  \______/   \______/  |_______/  ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"
                                 isnpired by:
                      _____      _              _  _    
                     |_   _|___ | |  ___  _ __ (_)| | __
                       | | / _ \| | / _ \| '__|| || |/ /
                       | ||  __/| ||  __/| |   | ||   < 
                       |_| \___||_| \___||_|   |_||_|\_\
                                                   
                 _                    _                         
                / \    ___  __ _   __| |  ___  _ __ ___   _   _ 
               / _ \  / __|/ _` | / _` | / _ \| '_ ` _ \ | | | |
              / ___ \| (__| (_| || (_| ||  __/| | | | | || |_| |
             /_/   \_\\___|\__,_| \__,_| \___||_| |_| |_| \__, |
                                                          |___/     ");
            Console.WriteLine(@"
                                    and
                          _    _                _ 
                         / \  | |_  __ _  _ __ (_)
                        / _ \ | __|/ _` || '__|| |
                       / ___ \| |_| (_| || |   | |
                      /_/   \_\\__|\__,_||_|   |_| ");
            
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"
                                 present:

            .______       __  ____    ____  _______ .______      
            |   _  \     |  | \   \  /   / |   ____||   _  \     
            |  |_)  |    |  |  \   \/   /  |  |__   |  |_)  |    
            |      /     |  |   \      /   |   __|  |      /     
            |  |\  \----.|  |    \    /    |  |____ |  |\  \----.
            | _| `._____||__|     \__/     |_______|| _| `._____|
                                                                 
                 .______           ___       __   _______  
                 |   _  \         /   \     |  | |       \ 
                 |  |_)  |       /  ^  \    |  | |  .--.  |
                 |      /       /  /_\  \   |  | |  |  |  |
                 |  |\  \----. /  _____  \  |  | |  '--'  |
                 | _| `._____|/__/     \__\ |__| |_______/  

                Controls: 
                            Left Arrow - move left;
                            Right Arrow - move right;
                            Space - shoot;

                      H A V E  F U N   A N D  E N J O Y !
                                                                        ");
            Console.ReadLine();
            Console.Clear();
                            
        }

        static void DrawGameOver(uint score)
        {
            Console.Clear();
            Console.WriteLine(@"

  




        ______          ______   _______ 
       / _____)   /\   |  ___ \ (_______)
      | /  ___   /  \  | | _ | | _____   
      | | (___) / /\ \ | || || ||  ___)  
      | \____/|| |__| || || || || |_____ 
       \_____/ |______||_||_||_||_______)
                                     
        _____   _    _  _______  ______   _ 
       / ___ \ | |  | |(_______)(_____ \ | |
      | |   | || |  | | _____    _____) )| |
      | |   | | \ \/ / |  ___)  (_____ ( |_|
      | |___| |  \  /  | |_____       | | _ 
       \_____/    \/   |_______)      |_||_| 
                            ");
            //Speak the scores:
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Game Over! Your score is " + score + " points");

            Console.ReadLine();
            Console.Clear();


        }
    }
}

/* 
 * FEATURE TO DO LIST: 
 *              1. Fuel Consumption
 *              2. Bonus System ( besides flying fuel tanks )
*/
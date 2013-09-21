using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RiverRaid
{
    public class Fighter
    {
        //Fields
        private readonly char[,] airplaine =
        {
            { ' ', '|', ' ' },
            { '-', '-', '-' },
            { ' ', '^', ' ' }
        };
        private int lives = 5;
        public int speed = 0;
        private int fuel = 100; 
        private int points = 0;
        public List<List<int>> shots = new List<List<int>>();

        public int shotXCoord;
        public int shotYCoord;

        //Properties
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public int Lives
        {
            get { return this.lives; }
            set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.lives = value; 
            }
        }
        public char[,] Airplaine 
        {
            get { return this.airplaine; }
        }
        public int Fuel
        {
            get { return this.fuel;}
            set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.fuel = value; 
            }
        }
        public int Points { get; set; }

        //Constructor
        public Fighter(int x, int y)
        {
            this.XCoord = x;
            this.YCoord = y;
        }

        //Methods
        public void DrawFighter()
        {
            int counter = 1;
            Console.SetCursorPosition(this.XCoord, this.YCoord);
            for (int row = 0; row < this.Airplaine.GetLength(0); row++)
            {
                for (int col = 0; col < this.Airplaine.GetLength(1); col++)
                {
                    Console.Write(this.Airplaine[row, col]);
                }
                Console.SetCursorPosition(this.XCoord, this.YCoord + counter);
                counter++;
            }
        }
        
        public void MoveLeft()
        {
            if (XCoord > 1)
            this.XCoord -= 2;
        }

        public void MoveRight()
        {
            if (XCoord < Console.BufferWidth - 4)
            this.XCoord += 2;
        }

        public void FuelManage()
        {
            try
            {
                this.Fuel--;
            }
            catch (ArgumentOutOfRangeException)
            {
                FillScoreboard();
            }
        }

        public void FillScoreboard()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 1);
            Console.WriteLine("GAME OVER!");
            using (StreamWriter sw = new StreamWriter("../../Scoreboard.txt"))
            {
                Console.WriteLine("Enter your name:");
                string playerName = Console.ReadLine();
                sw.WriteLine("{0}\t\t\t{1}", playerName, this.points);
            }
            using(StreamReader sr = new StreamReader("../../Scoreboard.txt"))
            {
                Console.WriteLine(new string('-', 40) + Environment.NewLine + "Scoreboard:" +
                    Environment.NewLine + new string('-', 40) + Environment.NewLine);
                for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
                {
                    int counter = 1;
                    Console.WriteLine(counter+". "+line+" --> "+this.points+" points.");
                    counter++;
                }
            }
            Environment.Exit(0);
        }
    }
}

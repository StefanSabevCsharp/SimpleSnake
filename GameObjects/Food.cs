using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Food : Point
    {
        
        private Random random;
        private Wall wall;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol,int points)
            : base(0,0)
        {
            this.wall = wall;
            this.random = new Random();
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
           this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                  this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}

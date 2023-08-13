using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private Queue<Point> snake;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private const char snakeSymbol = '\u25CF';
        private int foodIndex;

      

        public Snake(Wall wall)
            : base(0, 0)
        {
            this.wall = wall;
            this.snake = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.GetFoods(); 
            this.CreateSnake();
        }

        public int RandomFoodNumber  => new Random().Next(0, this.foods.Length);
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snake.Enqueue(new Point(2,topY));
            }
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodAsterisk(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;

        }
        public bool IsPointOfWall(Point snake)
            => 
               snake.TopY == 0 
            || snake.LeftX == 0 
            || snake.LeftX == this.LeftX - 1
            || snake.TopY == this.TopY;   

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snake.Last();
            this.GetNextPoint(direction, currentSnakeHead);

            bool isPointOfWall = this.IsPointOfWall(currentSnakeHead);

            if (isPointOfWall)
            {
                return false;
            }
            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);
            bool isPointOfSnake = this.snake.Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            this.snake.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }
            Point snakeTail = this.snake.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snake.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snake);
        }
    }
}

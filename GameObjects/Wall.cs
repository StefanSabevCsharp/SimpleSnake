using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
            
        }

        private void InitializeWallBorders()
        {
            for (int i = 0; i < this.LeftX; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(wallSymbol);
            }

            for (int i = 1; i <= this.TopY; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(wallSymbol);
            }
            for (int i = 1; i <= this.TopY; i++)
            {
                Console.SetCursorPosition(this.LeftX - 1, i);
                Console.Write(wallSymbol);
            }
            Console.SetCursorPosition(0, this.TopY);
            for (int i = 0; i < this.LeftX; i++)
            {
                Console.Write(wallSymbol);
            }


        }
    }
}

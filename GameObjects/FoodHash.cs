namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char charSybol = '#';
        private const int points = 3;
        protected FoodHash(Wall wall)
            : base(wall, charSybol, points)
        {
        }
    }

}

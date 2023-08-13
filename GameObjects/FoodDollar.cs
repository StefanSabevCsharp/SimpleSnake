namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char charSybol = '$';
        private const int points = 2;
        protected FoodDollar(Wall wall)
            : base(wall, charSybol, points)
        {
        }
    }

}

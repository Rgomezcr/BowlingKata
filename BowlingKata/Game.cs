namespace BowlingKata
{
    public class Game
    {
        private int _pins;


        public int Score()
        {
            return _pins;
        }

        public void Roll(int pins)
        {
            _pins = pins;
        }
    }
}
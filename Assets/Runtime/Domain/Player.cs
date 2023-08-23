namespace Runtime.Domain
{
    public class Player
    {
        private int _happiness;
        private readonly Hand _hand;
        private readonly Board _board;

        public Player(Hand hand, Board board)
        {
            _hand = hand;
            _board = board;
        }

        public void PlayCard(Card card, Coordinate coordinate)
        {
            _board.PlayCard(card, coordinate);
            _hand.PlayCard(card);
            _happiness = _board.GetBoardHappiness();
        }
    }
}
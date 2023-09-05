using System.Collections.Generic;

namespace Runtime.Domain
{
    public class Player
    {
        private readonly Hand _hand;
        private readonly Board _board;
        private readonly List<Milestone> _milestones;

        public Player(Hand hand, Board board, List<Milestone> milestones)
        {
            _hand = hand;
            _board = board;
            _milestones = milestones;
        }

        public void PlayCard(Card card, Coordinate coordinate)
        {
            _board.PlayCard(card, coordinate);
            _hand.PlayCard(card);
            CheckMilestonesAchieved();
        }

        private void CheckMilestonesAchieved()
        {
            var achievedMilestones = _milestones.FindAll(x => !x.Completed && x.Goal <= _board.GetBoardHappiness());

            foreach (var milestone in achievedMilestones)
            {
                milestone.Complete();
            }
        }
    }
}
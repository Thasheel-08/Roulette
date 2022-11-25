using System.Collections.Generic;
using Roulette.Models.Bets;

namespace Roulette.Models.Player
{
    public class PlayerBets
    {
        public string IdentityNumber { get; set; }
        public ColourBet? colourBet { get; set; }
        public PartitionBet? partitionBet { get; set; }
        public EvenOddBet? evenOddBet { get; set; }
        public HalfBet? halfBet { get; set; }
        public TwotoOneBet? twotoOneBet { get; set; }
        public List<NumberBets>? numberBets { get; set; }
    }
}

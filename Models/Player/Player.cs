using Roulette.Models.Bets;
using System.Collections.Generic;


namespace Roulette.Models.Player
{
    public class Player : PlayerBet
    {
        public string Customer_Id { get; set; }
        public int BetAmount { get; set; }
        public int NumberFull { get; set; }
        public int NumberSplit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roulette.Models.Player;

namespace Roulette.Interface
{
    public interface IBettingProcessManager
    {
        Task<string> ExecutePlaceBet(PlayerBets PlayerBet);
        Task<string> ExecuteSpin();
        Task<string> Payout();

        Task<string> GetPreviousSpinInformation();
    }
}

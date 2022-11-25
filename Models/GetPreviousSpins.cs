using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Roulette.Models.Bets;

namespace Roulette.Models
{
    public class GetPreviousSpins : IRequest<List<PlayerBet>>
    {
    }
}

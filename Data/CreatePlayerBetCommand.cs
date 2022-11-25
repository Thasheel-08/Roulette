using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Roulette.Data
{
    public class CreatePlayerBetCommand : IRequest<string>
    {
        public string CustomerIdentityNumber { get; set; }
        public string PlacebetId { get; set; }
        public int BetAmount { get; set; }
        public int ColourBlack { get; set; }
        public int ColourRed { get; set; }
        public int FirstTwelve { get; set; }
        public int SecondTwelve { get; set; }
        public int ThirdTwelve { get; set; }
        public int FirstHalf { get; set; }
        public int SecondHalf { get; set; }
        public int OddNumber { get; set; }
        public int EventNumber { get; set; }
        public int FirstTwoToOne { get; set; }
        public int SecondTwoToOne { get; set; }
        public int ThirdTwoToOne { get; set; }
        public int Number { get; set; }
        public int NumberFull { get; set; }
        public int NumberSplit { get; set; }
    }
}

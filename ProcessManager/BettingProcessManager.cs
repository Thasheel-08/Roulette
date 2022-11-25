using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roulette.Interface;
using MediatR;
using Roulette.Models.Player;
using System.Text.Json;
using Roulette.Data;
using Roulette.View_Models;
using System.Linq;
using Roulette.Models.Bets;
using Roulette.Models;

namespace Roulette.ProcessManager
{
    public class BettingProcessManager : IBettingProcessManager
    {
        private readonly IMediator _mediator;

        public BettingProcessManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> ExecutePlaceBet(PlayerBets customerBet)
        {
          
            var placeBetId =  Guid.NewGuid().ToString();

            List<Task<string>> tasks = new List<Task<string>>();

            //create the customer bet for the new open bet
            if (customerBet.colourBet.Black > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.colourBet.Black,
                    ColourBlack = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.colourBet.Red > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.colourBet.Red,

                    ColourRed = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.evenOddBet.EvenBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.evenOddBet.EvenBet,
                    EventNumber = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.evenOddBet.OddBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.evenOddBet.OddBet,
                    OddNumber = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.halfBet.FirstHalfBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.halfBet.FirstHalfBet,
                    FirstHalf = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.halfBet.SecondHalfBet > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.halfBet.FirstHalfBet,
                    FirstHalf = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.partitionBet.FirstPartition > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.halfBet.FirstHalfBet,
                    FirstHalf = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.partitionBet.SecondPartition > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.partitionBet.SecondPartition,
                    SecondTwelve = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.partitionBet.ThirdPartition > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.partitionBet.ThirdPartition,
                    ThirdTwelve = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.twotoOneBet.FirstTwotoOne > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.twotoOneBet.FirstTwotoOne,
                    FirstTwoToOne = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.twotoOneBet.SecondTwotoOne > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.twotoOneBet.SecondTwotoOne,
                    SecondTwoToOne = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            if (customerBet.twotoOneBet.ThirdTwotoOne > 0)
            {
                tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                {
                    BetAmount = (int)customerBet.twotoOneBet.ThirdTwotoOne,
                    ThirdTwoToOne = 1,
                    CustomerIdentityNumber = customerBet.IdentityNumber,
                    PlacebetId = placeBetId
                })));
            }
            foreach (var value in customerBet.numberBets)
            {
                if (value.NumberSplit == 1)
                {
                    tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                    {
                        BetAmount = (int)value.Value,
                        Number = (int)value.Number,
                        NumberSplit = 1,
                        CustomerIdentityNumber = customerBet.IdentityNumber,
                        PlacebetId = placeBetId
                    })));
                }
                if (value.NumberSplit == 0)
                {
                    tasks.Add(Task.Run(() => _mediator.Send(new CreatePlayerBetCommand
                    {
                        BetAmount = (int)value.Value,
                        Number = (int)value.Number,
                        NumberFull = 1,
                        CustomerIdentityNumber = customerBet.IdentityNumber,
                        PlacebetId = placeBetId
                    })));
                }
            }

            await Task.WhenAll(tasks);

            return JsonSerializer.Serialize(new PlayerPlaceBetInformation { PlayerIdentityNumber = customerBet.IdentityNumber, PlacBetId = placeBetId });
        }

        public async Task<string> ExecuteSpin()
        {

            var openBet = await _mediator.Send(new GetOpenBet());

            int[] blackNumbers = new int[18] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
            int[] redNumbers = new int[18] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };

            Random r = new Random();
            int randomNumber = r.Next(0, 37);

            var betResult = new PlayerBet
            {
                Placebet_Id = openBet.Id,
                Black = blackNumbers.Any(x => x == randomNumber) ? 1 : 0,
                Red = redNumbers.Any(x => x == randomNumber) ? 1 : 0,
                Even = randomNumber % 2 == 0 ? 1 : 0,
                Odd = randomNumber % 2 == 0 ? 0 : 1,
                FirstHalf = randomNumber < 19 ? 1 : 0,
                SecondHalf = randomNumber > 18 ? 1 : 0,
                FirstTwelve = randomNumber <= 12 ? 1 : 0,
                SecondTwelve = randomNumber > 12 && randomNumber <= 24 ? 1 : 0,
                ThirdTwelve = randomNumber > 24 ? 1 : 0,
                FirstTwotoOne = randomNumber % 3 == 1 ? 1 : 0,
                SecondTwotoOne = randomNumber % 3 == 2 ? 1 : 0,
                ThirdTwotoOne = randomNumber % 3 == 0 && randomNumber != 0 ? 1 : 0,
                Number = randomNumber
            };
                     

            await _mediator.Send(new CreatePlayerBetCommand { PlacebetId = openBet.Id });

            return JsonSerializer.Serialize(betResult);
        }

        public async Task<string> Payout()
        {
            //await _mediator.Send(new UpdatePayoutStatusCommand { PlacebetId = latestBetResult.Placebet_Id });

            return JsonSerializer.Serialize("");
        }

        public async Task<string> GetPreviousSpinInformation()
        {
            var previousSpins = await _mediator.Send(new GetPreviousSpins());
            return JsonSerializer.Serialize(previousSpins);
        }
    }
}

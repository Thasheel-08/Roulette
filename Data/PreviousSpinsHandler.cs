using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Roulette.Models;
using Roulette.Models.Bets;

namespace Roulette.Data
{
    public class PreviousSpinsHandler : IRequestHandler<GetPreviousSpins, List<PlayerBet>>
    {
        public async Task<List<PlayerBet>> Handle(GetPreviousSpins request, CancellationToken cancellationToken)
        {
            var list = new List<PlayerBet>();

            using (IDbConnection cnn = new SqliteConnection("Data Source=./DemoRouletteDB.db;Version=3"))
            {
                var output = cnn.Query<PlayerBet>("SELECT * from BetResults", new DynamicParameters());

                list = output.ToList();
            }

            return list;

        }

    }
}

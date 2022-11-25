using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Roulette.Models.Bets;

namespace Roulette.Data
{
    public class GetOpenBetHandler : IRequestHandler<GetOpenBet, PlaceBet?>
    {
        public async Task<PlaceBet?> Handle(GetOpenBet request, CancellationToken cancellationToken)
        {
            var list = new PlaceBet();

            using (IDbConnection cnn = new SqliteConnection("Data Source=./DemoRouletteDB.db;Version=3"))
            {
                var pb = cnn.Query<PlaceBet>("select * from PlaceBets where IsBetOpen = 1 ", new DynamicParameters());

                if (pb.Count() > 0)
                {
                    list = pb.Single();
                }
            }

            return list;
        }
    }
}

using MediatR;
using Microsoft.Data.Sqlite;
using System.Threading;
using System.Threading.Tasks;

namespace Roulette.Data
{
    public class PlayerBetHandler : IRequestHandler<CreatePlayerBetCommand, string>
    {
        public async Task<string> Handle(CreatePlayerBetCommand request, CancellationToken cancellationToken)
        {
            using (var conn = new SqliteConnection("Data Source=./DemoRouletteDB.db;Version=3"))
            {
                using (SqliteCommand comm = conn.CreateCommand())
                {
                    conn.Open();
                    comm.Parameters.AddWithValue("@Customer_Id", request.CustomerIdentityNumber);
                    comm.Parameters.AddWithValue("@Placebet_Id", request.PlacebetId);
                    comm.Parameters.AddWithValue("@BetAmount", request.BetAmount);
                    comm.Parameters.AddWithValue("@Black", request.ColourBlack);
                    comm.Parameters.AddWithValue("@Red", request.ColourRed);
                    comm.Parameters.AddWithValue("@FirstTwelve", request.FirstTwelve);
                    comm.Parameters.AddWithValue("@SecondTwelve", request.SecondTwelve);
                    comm.Parameters.AddWithValue("@ThirdTwelve", request.ThirdTwelve);
                    comm.Parameters.AddWithValue("@FirstHalf", request.FirstHalf);
                    comm.Parameters.AddWithValue("@SecondHalf", request.SecondHalf);
                    comm.Parameters.AddWithValue("@Even", request.EventNumber);
                    comm.Parameters.AddWithValue("@Odd", request.OddNumber);
                    comm.Parameters.AddWithValue("@FirstTwotoOne", request.FirstTwoToOne);
                    comm.Parameters.AddWithValue("@SecondTwotoOne", request.SecondTwoToOne);
                    comm.Parameters.AddWithValue("@ThirdTwotoOne", request.ThirdTwoToOne);
                    comm.Parameters.AddWithValue("@NumberFull", request.NumberFull);
                    comm.Parameters.AddWithValue("@NumberSplit", request.NumberSplit);
                    comm.Parameters.AddWithValue("@Number", request.Number);
                    comm.CommandText = "Insert into Customer_Bet(Customer_Id,Placebet_Id,BetAmount,Black,Red,FirstTwelve,SecondTwelve,ThirdTwelve,FirstHalf,SecondHalf,Even,Odd,FirstTwotoOne,SecondTwotoOne,ThirdTwotoOne,NumberFull,NumberSplit,Number) values (@Customer_Id,@Placebet_Id,@BetAmount,@Black,@Red,@FirstTwelve,@SecondTwelve,@ThirdTwelve,@FirstHalf,@SecondHalf,@Even,@Odd,@FirstTwotoOne,@SecondTwotoOne,@ThirdTwotoOne,@NumberFull,@NumberSplit,@Number)";
                    int value = comm.ExecuteNonQuery();
                }
            }

            return "added successfully";
        }
    }
}

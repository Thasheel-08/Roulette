using MediatR;
using Microsoft.Data.Sqlite;
using System.Threading;
using System.Threading.Tasks;

namespace Roulette.Data
{
    public class PlaceBetHandler : IRequestHandler<CreatePlaceBetCommand, string>
    {
        public async Task<string> Handle(CreatePlaceBetCommand request, CancellationToken cancellationToken)
        {
            using (var conn = new SqliteConnection("Data Source=./DemoRouletteDB.db;Version=3"))
            {
                using (SqliteCommand comm = conn.CreateCommand())
                {
                    conn.Open();
                    comm.Parameters.AddWithValue("@Id", request.Id);
                    comm.CommandText = "Insert into PlaceBets(Id) values (@Id)";
                    int value = comm.ExecuteNonQuery();
                }
            }

            return "new placebet is active";
        }

    }
}

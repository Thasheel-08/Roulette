using MediatR;
using Microsoft.Data.Sqlite;
using Roulette.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Roulette.Data
{
    public class ExceptionHandler : IRequestHandler<CreateExceptionCommand, string>
    {
        public async Task<string> Handle(CreateExceptionCommand request, CancellationToken cancellationToken)
        {
            using (var conn = new SqliteConnection("Data Source=./DemoRouletteDB.db;Version=3"))
            {
                using (SqliteCommand comm = conn.CreateCommand())
                {
                    conn.Open();
                    comm.Parameters.AddWithValue("@ErrorMessage", request.ErrorMessage);
                    comm.Parameters.AddWithValue("@StackTrace", request.StackTrace);
                    comm.CommandText = "Insert into GlobalException (ErrorMessage,StackTrace) values (@ErrorMessage, @StackTrace)";
                    int value = comm.ExecuteNonQuery();
                }
            }

            return "added successfully";
        }
    }
}

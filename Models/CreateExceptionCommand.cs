using MediatR;

namespace Roulette.Models
{
    public class CreateExceptionCommand : IRequest<string>
    {
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}

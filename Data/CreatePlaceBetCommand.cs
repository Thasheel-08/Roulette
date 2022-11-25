using MediatR;

namespace Roulette.Data
{
    public class CreatePlaceBetCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}

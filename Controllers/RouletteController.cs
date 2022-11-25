using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.Interface;
using Roulette.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly IBettingProcessManager _placebetProcessManager;

        public RouletteController(IBettingProcessManager placebetProcessManager)
        {
            _placebetProcessManager = placebetProcessManager;
        }

        [HttpPost, Route("PlaceCustomerBet")]
        public async Task<string> PlaceCustomerBet([FromBody] PlayerBets customer)
        {
            return await _placebetProcessManager.ExecutePlaceBet(customer);
        }

        [HttpGet, Route("Spin")]
        public async Task<string> Spin()
        {
            return await _placebetProcessManager.ExecuteSpin();
        }

        [HttpGet, Route("Payout")]
        public async Task<string> Payout()
        {
            var message = await _placebetProcessManager.Payout();

            return message;
        }

        [HttpGet, Route("GetPreviousSpinInformation")]
        public Task<string> GetCustomerAsync()
        {
            return _placebetProcessManager.GetPreviousSpinInformation();
        }
    }
}

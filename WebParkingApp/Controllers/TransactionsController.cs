using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParkingApp.Server;

namespace WebParkingApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]

    public class TransactionsController : Controller
    {
        Server.Server _server = new Server.Server();

        [HttpGet("all")]
        public string[] GetAllTransaction()
        {
            return _server.GetAllTransaction();
        }

        [HttpGet("lastMinute")]
        public IEnumerable<Transaction> GetTransactionInTheLastMinute()
        {
            return _server.GetTransactionInTheLastMinute();
        }

        [HttpGet("{id}")]
        public IEnumerable<Transaction> GetCarTransaction(string id)
        {
            return _server.GetCarTransaction(id);
        }

        [HttpPut("{carId}/{amount}")]
        public void ReplenishCarBalance(string carId, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Error! Invalid input. Entered value must be an integer value and greater than 0!");
            }
            else
            {
                _server.ReplenishCarBalance(carId, amount);
            }
        }
    }
}
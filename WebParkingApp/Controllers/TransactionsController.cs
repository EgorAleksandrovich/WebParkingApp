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
    public class TransactionsController : Controller
    {
        Server.Server _server = new Server.Server();

        [HttpGet]
        [Route("api/Transaction/all")]
        public string[] GetAllTransaction()
        {
            string[] transactions = _server.GetAllTransaction();
            if (transactions.Count() == 0)
            {
                throw new ArgumentNullException(string.Format("There are no transaction yet!"));
            }
            return transactions;
        }

        [HttpGet]
        [Route("api/Transaction/lastMinute")]
        public IEnumerable<Transaction> GetTransactionInTheLastMinute()
        {
            IEnumerable<Transaction> transactionInTheLastMinute = _server.GetTransactionInTheLastMinute();
            if (transactionInTheLastMinute.Count() == 0)
            {
                throw new ArgumentNullException("There are no transaction yet!");
            }
            return transactionInTheLastMinute;
        }

        [HttpGet]
        [Route("api/Transaction/{id}")]
        public IEnumerable<Transaction> GetCarTransaction(string id)
        {
            IEnumerable<Transaction> transactions = _server.GetTransactionInTheLastMinute();
            if (transactions.Count() == 0)
            {
                throw new ArgumentNullException("There are no transaction yet!");
            }

            IEnumerable<Transaction> carTransactions = _server.GetCarTransaction(id);
            if (carTransactions.Count() == 0)
            {
                throw new ArgumentNullException(string.Format("Car with id \"{0}\" not found!", id));
            }
            return carTransactions;
        }
    }
}
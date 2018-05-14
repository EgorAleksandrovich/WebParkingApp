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
    [Route("api/Parking")]
    public class ParkingController : Controller
    {
        Server.Server _server = new Server.Server();

        [HttpGet("freePlace")]
        public int GetFreePlaces()
        {
            return _server.GetFreePlaces();
        }

        [HttpGet("busyPlace")]
        public int GetBusyPlaces()
        {
            return _server.GetBusyPlaces();
        }

        [HttpGet("Balance")]
        public int GetTotalBalance()
        {
            return _server.GetTotalBalance();
        }
    }
}
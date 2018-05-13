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
    public class ParkingController : Controller
    {
        Server.Server _server = new Server.Server();

        [HttpGet]
        [Route("api/Parking/freePlace")]
        public int GetFreePlaces()
        {
            return _server.GetFreePlaces();
        }

        [HttpGet]
        [Route("api/Parking/busyPlace")]
        public int GetBusyPlaces()
        {
            return _server.GetBusyPlaces();
        }

        [HttpGet]
        [Route("api/Parking/totalBalance")]
        public int GetTotalBalance()
        {
            return _server.GetTotalBalance();
        }
    }
}
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
    [Route("api/Cars")]
    public class CarsController : Controller
    {
        Server.Server _server = new Server.Server();

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _server.GetCars(); ;
        }

        [HttpGet("{id}")]
        public Car GetCar(string id)
        {
            return _server.GetCar(id);
        }

        [HttpPost]
        public void Post([FromBody]Car car)
        {
            if (car.CarType == CarType.Undefined)
            {
                throw new ArgumentNullException("Was not chosen \"car type\", please fill out all required fields!");
            }
            else
            {
                if (car.Balance < 1)
                {
                    throw new ArgumentException("Was not entered or entered wrong required field value \"car balance\"! Must be an integer value and greater than 0!");
                }
            }
            _server.ParkTheCar(car);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _server.RemoveCar(id);
        }
    }
}
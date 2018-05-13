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
            Car car = _server.GetCar(id);
            if (car == null)
            {
                throw new ArgumentNullException();
            }
            return car;
        }

        [HttpPost]
        public void Post([FromBody]Car car)
        {
            if (car.CarType == CarType.Undefined)
            {
                throw new ArgumentException("Was not chosen \"car type\", please fill out all required fields!!");
            }
            else
            {
                if (car.Balance < 1)
                {
                    throw new ArgumentException("Was not entered required field \"car type\"!");
                }
            }
            _server.ParkTheCar(car);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Car outgoingCar = _server.GetCar(id);
            if (outgoingCar == null)
            {
                throw new ArgumentNullException(string.Format("Car with id \"{0}\" not found," +
                    " please check the correctness of the input id.", id));
            }
            else
            {
                if (outgoingCar.Balance < 1)
                {
                    int requiredAmount = outgoingCar.Balance * -1;
                    throw new ArgumentException(string.Format("In your account {0}, "+
                        "to pick up the car replenish the account not less than {1}", outgoingCar.Balance, requiredAmount));
                }
                else
                {
                    _server.RemoveCar(outgoingCar);
                }
            }
        }
    }
}
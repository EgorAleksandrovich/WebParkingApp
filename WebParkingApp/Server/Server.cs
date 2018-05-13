using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebParkingApp.Server
{
    public class Server
    {
        Parking _parking = Parking.GetInstance();

        public void ParkTheCar(Car newCar)
        {
            if (newCar.Balance > 0)
            {
                _parking.ParkTheCar(newCar);
            }
        }

        public IEnumerable<Car> GetCars()
        {
            return _parking.GetCars();
        }

        public Car GetCar(string id)
        {
            return _parking.GetCar(id);
        }

        public void RemoveCar(Car outgoingCar)
        {
            _parking.PickUpTheCar(outgoingCar);
        }

        public int GetFreePlaces()
        {
            return _parking.GetFreePlaces();
        }

        public int GetBusyPlaces()
        {
            return _parking.GetBusyPlaces();
        }

        public int GetTotalBalance()
        {
            return _parking.GetBalance();
        }

        public IEnumerable<Transaction> GetTransactionInTheLastMinute()
        {
            return _parking.Transactions;
        }

        public IEnumerable<Transaction> GetCarTransaction(string id)
        {
            return _parking.Transactions.Where(tr => tr.CarId == id);
        }

        public string[] GetAllTransaction()
        {
            return _parking.RetriveTransactionData();
        }
    }
}

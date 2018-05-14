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
            Car car = _parking.GetCar(id);
            if (car == null)
            {
                throw new ArgumentException(string.Format("Car with id \"{0}\" not found!", id));
            }
            return car;
        }

        public void RemoveCar(string removeCarId)
        {
            bool conteinsCar = _parking.ConteinsCar(removeCarId);
            if (!conteinsCar)
            {
                throw new ArgumentException(string.Format("Car with id \"{0}\" not found," +
                    " please check the correctness of the input id!", removeCarId));
            }
            else
            {
                Car outgoingCar = _parking.GetCar(removeCarId);
                if (outgoingCar.Balance < 1)
                {
                    int requiredAmount = outgoingCar.Balance * -1;
                    throw new ArgumentException(string.Format("In your account {0}, " +
                        "to pick up the car replenish the account not less than {1}!", outgoingCar.Balance, requiredAmount));
                }
                else
                {
                    _parking.PickUpTheCar(outgoingCar);
                }
            }
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
            IEnumerable<Transaction> carTransactions = _parking.Transactions.Where(tr => tr.CarId == id);
            if (carTransactions.Count() == 0)
            {
                throw new ArgumentException(string.Format("Car transaction with id \"{0}\" not found!", id));
            }
            return carTransactions;
        }

        public string[] GetAllTransaction()
        {
            return _parking.RetriveTransactionData();
        }

        public void ReplenishCarBalance(string carId, int amount)
        {
            Car car = _parking.GetCar(carId);
            if (car == null)
            {
                throw new ArgumentException(string.Format("Car with id \"{0}\" not found," +
                    " please check the correctness of the input id.", carId));
            }
            else
            {
                car.Balance += amount;
            }
        }
    }
}

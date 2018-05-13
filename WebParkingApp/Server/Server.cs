﻿using System;
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
    }
}

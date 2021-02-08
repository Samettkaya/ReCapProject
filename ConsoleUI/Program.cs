using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //ColorAdd(colorManager);
            //ColorDelete(colorManager);
            //BrandAdd(brandManager);
            //CarAdd(carManager);
            AllCars(carManager);

        }


        private static void CarAdd(CarManager carManager)
        {
            carManager.Add(new Car
            {
                CarName = "Tesla123",
                ModelYear = "2021",
                DailyPrice = 1000,
                Descriptions = "kayıt",
                BrandId = 1002,
                ColorId = 5

            });
        }

        private static void BrandAdd(BrandManager brandManager)
        {
            brandManager.Add(new Brand
            {

                BrandName = "Tesla"

            });
        }

        private static void AllCars(CarManager carManager)
        {
            Console.WriteLine("\nTüm arabalar:\n\nId\tCar Name\tBrand Name\tColor Name\tModel Year\tDaily Price\tDescriptions");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"{car.CarId}\t{car.CarName}\t{car.BrandName}\t\t{car.ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void ColorDelete(ColorManager colorManager)
        {
            colorManager.Delete(new Color
            {

                ColorId = 1003

            });
        }

        private static void ColorAdd(ColorManager colorManager)
        {
            colorManager.Add(new Color
            {

                ColorName = "turuncu"

            });
        }

    }
}

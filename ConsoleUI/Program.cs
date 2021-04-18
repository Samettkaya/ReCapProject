using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
           


            //ColorTest(colorManager);
            //BrandTest(brandManager);
            CarTest(carManager);
            UserTest(userManager);
            CustomerTest(customerManager);

           
        }

        private static void RentalTest(RentalManager rentalManager)
        {
            var result = rentalManager.GetAll();
            if (result.Success)
            {

                Console.WriteLine("\nKiralık Arabalar:\n\nId\tCar Id\tCustomer Id\tRent Date\t\tReturn Date");
                foreach (var rental in result.Data)
                {
                    if (rental.ReturnDate != null)
                    {
                        Console.WriteLine($"{rental.RentalId}\t{rental.CarId}\t{rental.CustomerId}\t\t{rental.RentDate}\t{rental.ReturnDate}");

                    }
                    else
                    {
                        Console.WriteLine(result.Message);
                    }
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void CustomerTest(CustomerManager customerManager)
        {
            var result = customerManager.GetAll();

            Console.WriteLine("\nAraba Kiralayan Şirketler:\n\n Company Name");
            foreach (var customer in result.Data)
            {
                Console.WriteLine($"{customer.CompanyName}");

            }

            //customerManager.Add(new Customer{UserId=1005,CompanyName="Ptt"});
            //customerManager.Delete(new Customer {CustomerId=1005 });
        }

        private static void UserTest(UserManager userManager)
        {
            var result = userManager.GetAll();

            Console.WriteLine("\nTüm Kulanıcılar:\n\nId\tFirst Name\tLast Name\tE-mail");
            foreach (var user in result.Data)
            {
                Console.WriteLine($"{user.UserId}\t{user.FirstName}\t\t{user.LastName}\t\t{user.Email}");

            }

            //userManager.Add(new User { FirstName="Kayahan",LastName="Haskaya",Email="kayahan45@gmail.com",Password="123kayahan"});
            //userManager.Update(new User {UserId=1005,Password="123haskaya" });
            //userManager.Delete(new User { UserId = 1005 });
        }




        private static void BrandTest(BrandManager brandManager)
        {
            //brandManager.Add(new Brand { BrandName = "Audi" });
            //brandManager.Update(new Brand {BrandId=2002, BrandName="Audi"});
            //brandManager.Delete(new Brand { BrandId=2002});
        }

       
        private static void CarTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                Console.WriteLine("\nTüm arabalar:\n\nId\tCar Name\tBrand Name\tColor Name\tModel Year\tDaily Price\tDescriptions");
                foreach (var car in result.Data)
                {      
                    Console.WriteLine($"{car.CarId}\t{car.CarName}\t{car.BrandName}\t\t{car.ColorName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
                }
               
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            //carManager.Add(new Car{CarName = "Jetta",ModelYear = "2017",DailyPrice = 300,Descriptions = "Manuel Dizel",BrandId = 5,ColorId = 5});
            //carManager.Add(new Car() { CarName = "Tesla 12", BrandId = 6, ColorId = 4, ModelYear = "2010", DailyPrice = 400, Descriptions = "Güzel Araba" });
            //carManager.Delete(new Car() { CarId = 2006, CarName = "Tesla 12", BrandId = 6, ColorId = 4, ModelYear = "2010", DailyPrice = 400, Descriptions = "Güzel Araba" });
            //carManager.Update(new Car() { CarId = 2006, CarName = "Tesla 12", BrandId = 6, ColorId = 4, ModelYear = "2010", DailyPrice = 400, Descriptions = "Güzel Araba" });
        }

        private static void ColorTest(ColorManager colorManager)
        {

            //colorManager.Delete(new Color{ ColorId = 1003});

            //colorManager.Update(new Color() { ColorId = 7, ColorName = "Silver" });

            //colorManager.Add(new Color { ColorName = "turuncu" });

            var result = colorManager.GetAll();
            Console.WriteLine("Tüm Renkler \n Id \t Name");
            foreach (var color in result.Data)
            {
                Console.WriteLine($"{color.ColorId  } \t {color.ColorName}");
            }
        }

      

   

    }
  
  
       
}

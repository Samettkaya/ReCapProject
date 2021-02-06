using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryCarDal : ICarDal
    public class InMemoryCarDal
    {

        //List<Car> _cars;
        //public InMemoryCarDal()
        //{
        //    _cars = new List<Car>
        //    {
        //        new Car{CarId=1, BrandId=1,ColorId=1,ModelYear=2019,DailyPrice=80000,Descriptions="Aile Arabası"},
        //        new Car{CarId=2, BrandId=2,ColorId=2,ModelYear=2018,DailyPrice=60000,Descriptions="Gezi Arabası"},
        //        new Car{CarId=3, BrandId=3,ColorId=3,ModelYear=2016,DailyPrice=40000,Descriptions="Acil satılık "},
        //        new Car{CarId=4, BrandId=4,ColorId=4,ModelYear=2017,DailyPrice=50000,Descriptions="Dağ Arabası"},
        //        new Car{CarId=5, BrandId=5,ColorId=5,ModelYear=2020,DailyPrice=100000,Descriptions="Otomatik Araba"},

        //    };

        //}
        //public void Add(Car car)
        //{
        //    _cars.Add(car);
        //}

        //public void Delete(Car car)
        //{
        //    Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
        //    _cars.Remove(carToDelete);

        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetById(int id)
        //{
        //    return _cars.Where(c => c.CarId == id).ToList();

        //}

        //public void Update(Car car)
        //{
        //    Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

        //    carToUpdate.CarId = car.CarId;
        //    carToUpdate.ModelYear = car.ModelYear;
        //    carToUpdate.ColorId = car.ColorId;
        //    carToUpdate.BrandId = car.BrandId;
        //    carToUpdate.Descriptions = car.Descriptions;
        //    carToUpdate.DailyPrice = car.DailyPrice;
             
        //}
    }
}

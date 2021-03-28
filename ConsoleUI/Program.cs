using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetails();
            //ModelYearBrandNameDto();
            CarsGetAll();    
        }
     
        private static void CarsGetAll()
        {
            
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var cars in result.Data)
            {
                Console.WriteLine(cars.CarId + "/" + cars.BrandId + "/" + cars.ColorId
                                    + "/" + cars.DailyPrice + "/" + cars.Description);
            }
            Console.WriteLine(result.Message);
        }

        private static void ModelYearBrandNameDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetModelYearBrandNameDtos();
            foreach (var modelbrand in result.Data)
            {
                Console.WriteLine(modelbrand.BrandName + "/" + modelbrand.ModelYear);
            }
            Console.WriteLine(result.Message);
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var cars in result.Data)
            {
                Console.Write(cars.ModelYear + " / ");
                Console.Write(cars.BrandName + " / ");
                Console.Write(cars.ColorName + " / ");
                Console.Write(cars.DailyPrice);
                Console.WriteLine();             
            }
            Console.WriteLine(result.Message);
        }
    }
}

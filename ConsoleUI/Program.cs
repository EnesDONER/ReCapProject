using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            userManager.Add(new User
            {
                FirstName = "Ercan",
                LastName = "Döner",
                Email = "özcan131@gmail.com",
                Password = "1333"
            });

            //RentalAdd(rentalManager);
            //CustomerAdd(customerManager);
            UserAdd(userManager);
            //GetAllColor(colorManager);
            //GetCarDetalis(carManager);
            //GetAll(carManager);
            Console.WriteLine("Hello World!");
        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental { CarId = 11, CustomerId = 1, RentDate = DateTime.Now.Date });
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.CarId + "" + item.RentDate);
            }
        }

        private static void UserAdd(UserManager userManager)
        {

            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        private static void CustomerAdd(CustomerManager customerManager)
        {
            customerManager.Add(new Customer { UserId = 1, CompanyName = "sahibinden" });
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine(item.CompanyName);
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

   
    }
}

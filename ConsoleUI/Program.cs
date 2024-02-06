using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllCar();
            //   GetAllByDailPrice_();
            // BrandTest();
            //  BrandName();
            // Add();
            // Delet(2);
            //clorListDeneme();
            //CarDetail();
            //  BrandAdd();
            //  ColorAdd();
            //CustomerAdd();
            //  UserAdd();
            // RentalAdd();
            //CustomerList();
           // RentalAll();
            UserAll();
        }
        public static void UserAll()
        {
            UserManeger userManeger = new UserManeger( new  EfUser()) ;
            using (RentACarContext context = new RentACarContext())
            {

                //  BrandManeger brandManeger = new BrandManeger(new EfBrandDal());
                // foreach (var brand in brandManeger.GetByBrandId(3).Data)
               


               var result= userManeger.GetAll();
                foreach (var user in result.Data) 
                {
                    Console.WriteLine(user.UserId+" "+ user.FirstName+" "+ user.LastName+" "+ user.Email);
                }
            }
        }
        public static void RentalAll() 
        {
            RentalManeger rentalManeger = new RentalManeger(new EfRentalDal());
            using (RentACarContext carContext = new RentACarContext())
            {
                var result= rentalManeger.GetAll();
                if (result.Succeess==true)
                {
                    foreach (var rental in result.Data)
                    {
                        Console.WriteLine(rental.RentalId+" "+ rental.CarId+" "+rental.Price+" "+rental.CustomerId);
                    }
                }
            }
        }

        public static void CustomerList() 
        {
            CustumerManeger custumerManeger = new CustumerManeger(new  EfCostomerDal());
            using (RentACarContext context = new RentACarContext() )
            {
                var result = custumerManeger.GetAll();
                if (result.Succeess == true)
                {
                    foreach (var customer in result.Data)
                    {
                        Console.WriteLine(customer.UserId+"  "+ customer.CustomerId+" "+customer.CompanyName);
                    }
                }
            }
        }
        public static void RentalAdd() 
        {

            RentalManeger rentalManeger = new RentalManeger(new EfRentalDal());
            using (RentACarContext context = new RentACarContext())
            {
                var result = rentalManeger.Add(new Rental { CarId = 1, CustomerId = 10, Price = 200, RentalId = 1, RentDate = DateTime.UtcNow, ReturDate =null });
                Console.WriteLine(result.Message);
            }
        }
        public static void UserAdd()
        {
            UserManeger userManeger = new UserManeger(new EfUser());

                using (RentACarContext context = new RentACarContext())
                {


             //   var result = userManeger.Add(new User { UserId = 2, FirstName = "Emirhan", LastName = "Toker", Email = "emir@gmail.com", Password = "2" });

            //    Console.WriteLine(result.Message);
                }
            
        }
        public static void CustomerAdd()
        {//new Customer { UserId=2,CompanyName="KOÇ" }
            CustumerManeger custumerManeger = new CustumerManeger(new EfCostomerDal());
            using (RentACarContext context = new RentACarContext())
            {


                var result = custumerManeger.Add(new Customer { UserId=1, CompanyName = "Öztürk", CustomerId = 10 });

                Console.WriteLine(result.Message);
            }
        }
        public static void ColorAdd()
        {
         
            ColorManeger colorManeger = new ColorManeger(new EfColorDal());
            using (RentACarContext context = new RentACarContext())
            {
              //  var result = colorManeger;
                colorManeger.Add(new Color { ColourId = 6, ColourName = "Pınk" });
                Console.WriteLine(Messages.CarAdded);
            }

        }


        private static void CarDetail()
        {
            CarManeger carManeger = new CarManeger(new EfCarDal());

            var result= carManeger.GetCarDetail();

            if (result.Succeess == true)
            {
                foreach (var car in result.Data)
                {
                    
                     Console.WriteLine(car.BrandName +" "+ car.Descriptions+ " " + car.ClorName + " " + car.ModelYear+" "+ result.Message);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        private static void clorListDeneme()
        {
            ColorManeger colorManeger = new ColorManeger(new EfColorDal());
            foreach (var color in colorManeger.GetAll().Data)
            {
                Console.WriteLine( color.ColourName+" "+color.ColourId );
            }
        }
        private static void BrandName()
        {
            BrandManeger brandmaneger = new BrandManeger(new EfBrandDal());
            foreach (var brand in brandmaneger.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void BrandTest()
        {
            BrandManeger brandManeger = new BrandManeger(new EfBrandDal());
            foreach (var brand in brandManeger.GetByBrandId(3).Data)
            {
                Console.WriteLine(brand.BrandId + brand.BrandName);
            }
        }

        public static void GetAllByDailPrice_()
        {

            CarManeger carManeger = new CarManeger(new EfCarDal());
            foreach (var car in carManeger.GetCarsByDailPrice(0, 550).Data)
            {


                Console.WriteLine(car.ClorId + " " + car.BrandId + " " + car.ModelYear + " " + car.Descriptions);
            }
        }

    
       public static void GetAllCar()
       {
        CarManeger carManeger = new CarManeger(new EfCarDal());
        foreach (var car in carManeger.GetCarsByBrandId(3).Data)
        {


            Console.WriteLine(car.ClorId + " " + car.BrandId + " " + car.ModelYear + " " + car.Descriptions);
        }
       }


       public static void Add( )
        {
            CarManeger carManeger = new CarManeger(new EfCarDal());
            using (RentACarContext carContext = new RentACarContext())
            {
               // carManeger.Add(new Car() { BrandId = 1, ClorId = 1, Descriptions = "t1", DailPrice = 0, ModelYear = 2023 });
                //carManeger.Add(new Car() { BrandId = 2, ClorId = 2, Descriptions = "3008", DailPrice = 50, ModelYear = 2021 });
                //carManeger.Add(new Car() { BrandId = 3, ClorId = 3, Descriptions = "Civic", DailPrice = 60, ModelYear = 2022 });
                //carManeger.Add(new Car() { BrandId = 1, ClorId = 4, Descriptions = "T10x 4WD", DailPrice = 60, ModelYear = 2022 });
               // carManeger.Add(new Car() { BrandId = 3, ClorId = 2, Descriptions = "Accord", DailPrice = 10, ModelYear = 2022 });
                //carManeger.Add(new Car() { BrandId = 3, ClorId = 2, Descriptions = "Type R", DailPrice = 10, ModelYear = 2022 });



            }
           


        }
        public static void Delet(int  brandId )
        {

            CarManeger carManeger = new CarManeger(new EfCarDal());
            using (RentACarContext carContext = new RentACarContext())
            {
               
               
                if (brandId == 2)
                {
                    var DeleteEntity = carContext.Entry(brandId);
                    DeleteEntity.State = EntityState.Deleted;
                    carContext.SaveChanges();
                    Console.WriteLine("başarıyla silinmiştir");
                }
                else
                {
                    Console.WriteLine("başarısız");
                }

            }

        }
        public static void BrandAdd()
        {
            BrandManeger brandManeger = new BrandManeger(new EfBrandDal());
            {
                using (RentACarContext carContext =new RentACarContext())
                {
                    brandManeger.Add(new Brand() { BrandId = 5, BrandName=  "Audi" });
                    brandManeger.Add(new Brand() { BrandId = 6, BrandName = "Dacia" });
                    brandManeger.Add(new Brand() { BrandId = 7, BrandName = "Toyota" });
                    brandManeger.Add(new Brand() { BrandId = 8, BrandName = "Hyundai" });
                    brandManeger.Add(new Brand() { BrandId = 9, BrandName = "Opel" });
                    brandManeger.Add(new Brand() { BrandId = 10, BrandName = "Renault" });
                }
            }
        }

    }


}
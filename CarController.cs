using Car_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Configuration;

namespace Car_MVC.Controllers
{
    public class CarController : Controller
    {
        public IConfiguration Configuration { get; }

        public CarController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IActionResult funcInlineHelper()
        {
            ViewBag.confname = Configuration.ToString();

            List<int> numbers = new List<int>() { 15 , 50 , -30 , -200 , 10};

            ViewBag.Numbers = numbers;

            return View();
        }
        public IActionResult getall()
        {
            var carlst = CarList.cars.ToList();

            // the prop name of viewbag is from your choice
            
            // ViewBag.AllCars = carlst;

            return View(carlst);
        }

        public IActionResult getByNum(int num)
        {
            //ViewBag.car = CarList.cars.Where(c => c.Num == num).FirstOrDefault(); 

            Car cr = CarList.cars.Where(c => c.Num == num).FirstOrDefault();

            return View(cr);
        }

        
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(int num , string color , string manfacture , string model)
        {
            Car newcar = new Car()
            {
                Num = num,
                Color = color,
                Manfacture = manfacture,
                Model = model
            };

            CarList.cars.Add(newcar);

            return RedirectToAction("getall");
        }

        
        public IActionResult Edit(int num) { 
   
            //ViewBag.curCar = CarList.cars.Where(c => c.Num == num).FirstOrDefault();
            Car curCar = CarList.cars.Where(c => c.Num == num).FirstOrDefault();

            return View(curCar);
        }

        [HttpPost]
        public IActionResult Edit(int num, string color, string manfacture, string model) 
        {
            var updatedcar = CarList.cars.Where(c => c.Num == num).FirstOrDefault();
            updatedcar.Color = color;
            updatedcar.Manfacture = manfacture;
            updatedcar.Model = model;

            return RedirectToAction("getall");
        }

        public IActionResult Delete(int num)
        {
            var cur_car = CarList.cars.Where(c => c.Num == num).FirstOrDefault();
            if (cur_car != null)
            {
                CarList.cars.Remove(cur_car);
            }


            return RedirectToAction("getAll");
        }

    }
}

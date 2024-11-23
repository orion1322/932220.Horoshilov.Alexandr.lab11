using Microsoft.AspNetCore.Mvc;
using CalculatorApp.Models; 
using System;
using WebApplicationTask11.Models;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult UsingModelCalc()
        {
            var model = new CalculatorViewModel
            {
                Number1 = new Random().Next(0, 11),
                Number2 = new Random().Next(0, 11)
            };

            try
            {
                model.Sum = _calculatorService.Add(model.Number1, model.Number2);
                model.Difference = _calculatorService.Subtract(model.Number1, model.Number2);
                model.Product = _calculatorService.Multiply(model.Number1, model.Number2);
                model.Quotient = _calculatorService.Divide(model.Number1, model.Number2);
            }
            catch (DivideByZeroException)
            {
                ViewBag.ErrorMessage = "Ошибка: деление на ноль!";
            }

            return View(model);
        }

        public IActionResult UsingViewDataCalc()
        {
            var number1 = new Random().Next(0, 11);
            var number2 = new Random().Next(0, 11);

            ViewData["Number1"] = number1;
            ViewData["Number2"] = number2;
            ViewData["Sum"] = _calculatorService.Add(number1, number2);
            ViewData["Difference"] = _calculatorService.Subtract(number1, number2);
            ViewData["Product"] = _calculatorService.Multiply(number1, number2);

            try
            {
                ViewData["Quotient"] = _calculatorService.Divide(number1, number2);
            }
            catch (DivideByZeroException)
            {
                ViewBag.ErrorMessage = "Ошибка: деление на ноль!";
            }

            return View();
        }

        public IActionResult UsingViewBagCalc()
        {
            var number1 = new Random().Next(0, 11);
            var number2 = new Random().Next(0, 11);

            ViewBag.Number1 = number1;
            ViewBag.Number2 = number2;
            ViewBag.Sum = _calculatorService.Add(number1, number2);
            ViewBag.Difference = _calculatorService.Subtract(number1, number2);
            ViewBag.Product = _calculatorService.Multiply(number1, number2);

            try
            {
                ViewBag.Quotient = _calculatorService.Divide(number1, number2);
            }
            catch (DivideByZeroException)
            {
                ViewBag.ErrorMessage = "Ошибка: деление на ноль!";
            }

            return View();
        }

        public IActionResult UsingServiceInjectionCalc()
        {
            var number1 = new Random().Next(0, 11);
            var number2 = new Random().Next(0, 11);

            var model = new CalculatorViewModel
            {
                Number1 = number1,
                Number2 = number2,
                Sum = _calculatorService.Add(number1, number2),
                Difference = _calculatorService.Subtract(number1, number2),
                Product = _calculatorService.Multiply(number1, number2)
            };

            try
            {
                model.Quotient = _calculatorService.Divide(number1, number2);
            }
            catch (DivideByZeroException)
            {
                ViewBag.ErrorMessage = "Ошибка: деление на ноль!";
            }

            return View(model);
        }
    }
}
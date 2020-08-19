using Microsoft.AspNetCore.Mvc;
using Calculator.BLL;
using Calculator.BLL.DataContract;
using System;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(CalculateReq calculateReq)
        {
            try
            {
                return Json(CalculatorBLL.Calculate(calculateReq));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormulaGeneral.Models;

namespace FormulaGeneral.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double VariableA,double VariableB,double VariableC)
        {
            ViewBag.Result = Calculo(VariableA, VariableB, VariableC);
            return View("Resultado");
        }

        public string Calculo(double VariableA, double VariableB, double VariableC)
        {
            double discriminante, x1, x2;
            string resultado;
            discriminante = (VariableB * VariableB) - (4 * VariableA * VariableC);

            if (discriminante == 0)
            {
                x1 = -VariableB / (2 * VariableA);
                resultado = "La solución es x = " + x1;
            }
            else if (discriminante > 0)
            {
                x1 = (-VariableB + Math.Sqrt(discriminante)) / (2 * VariableA);
                x2 = (-VariableB - Math.Sqrt(discriminante)) / (2 * VariableA);
                resultado = "Las soluciones son x = " + x1 + ", " + x2;
            }
            else
            {
                resultado = "No existen soluciones reales";
            }

            return resultado;
        }

        public ViewResult Resultado()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

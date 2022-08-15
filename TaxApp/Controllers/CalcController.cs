using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxApp.Models;

namespace TaxApp.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index()
        {
            return View(new Calc());
        }
        [HttpPost]
        public IActionResult Index(Calc calc)
        {
            double deduction;
            if (calc.Age > 50)
            {
                deduction = 0.85;
                calc.Elder = true;
            }
            else
            {
                deduction = 1;
                calc.Elder = false;
            }
            
            calc.TaxPerAnnum = Math.Round((getTax(calc.Salary)*deduction),2);
            calc.TaxPerMonth = Math.Round((calc.TaxPerAnnum / 12),2);
            calc.SalaryAfterTax = Math.Round(calc.Salary - calc.TaxPerAnnum, 2);
            calc.MonthlySalaryAfterTax = Math.Round((calc.Salary / 12) - calc.TaxPerMonth, 2);
            return View("Result", calc);

        }



        public double getTax(double anualSalary)
        {
            //Up to 5000 0 %
            //Up to 10000 5 %
            //Up to 20000 7.5 %
            //Up to 35000 9 %
            //Up to 50000 15 %
            //Up to 70000 25 %
            //More than 70000 30 %

            double monthlySalary = anualSalary / 12;
            double tax = 0;
            if (monthlySalary < 5000)
            {
                tax = 0;
            }
            else if (monthlySalary < 10000)
            {
                tax = monthlySalary * 0.05;
            }
            else if (monthlySalary < 20000)
            {
                tax = monthlySalary * 0.075;
            }
            else if (monthlySalary < 35000)
            {
                tax = monthlySalary * 0.09;
            }
            else if(monthlySalary < 50000)
            {
                tax = monthlySalary * 0.15;
            }
            else if (monthlySalary < 70000)
            {
                tax = monthlySalary * 0.25;
            }
            else if (monthlySalary > 70000)
            {
                tax = monthlySalary * 0.30;
            }
            return tax*12;
        }
    }
}

namespace TaxApp.Models
{
    public class Calc
    {
        public int Age { get; set; }
        public double Salary { get; set; }
        public double TaxPerAnnum { get; set; }
        public double TaxPerMonth { get; set; }
        public bool Elder { get; set; }
        public double SalaryAfterTax { get; set; }
        public double MonthlySalaryAfterTax { get; set; }
    }
}

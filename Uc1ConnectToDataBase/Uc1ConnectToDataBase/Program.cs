using System;

namespace Uc1ConnectToDataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Sql");

            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();

            employee.EmployeeName = "Eren Jeager";
            employee.PhoneNumber = "8106529025";
            employee.Address = "25-4-710";
            employee.Department = "Hr";
            employee.Gender = 'M';
            employee.BasicPay = 22000;  
            employee.Deductions = 1500;
            employee.TaxablePay = 200.00;
            employee.Tax = 300;
            employee.NetPay = 25000;
            employee.StartDate = DateTime.Now;
            employee.City = "Kazipet";
            employee.Country = "India";
            //repo.GetAllEmployee();
            repo.Retrieve(employee);


        }
    }
}

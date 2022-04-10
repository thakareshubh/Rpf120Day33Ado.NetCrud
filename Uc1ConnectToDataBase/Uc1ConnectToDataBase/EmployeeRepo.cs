using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Uc1ConnectToDataBase
{
    class EmployeeRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public static string connectionString = @"(localdb)\MSSQLLocalDB;Database=payroll_service;Trusted_Connection=True";
        SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT EmployeeID,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay,StartDate,City,Country
                                    FROM Employee_payroll";

                    //Define Sql Command Object
                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.PhoneNumber = dr.GetString(2);
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Department = dr.GetString(4);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(5));
                            employeeModel.BasicPay = dr.GetDouble(6);
                            employeeModel.Deductions = dr.GetDouble(7);
                            employeeModel.TaxablePay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.NetPay = dr.GetDouble(10);
                            employeeModel.StartDate = dr.GetDateTime(11);
                            employeeModel.City = dr.GetString(12);
                            employeeModel.Country = dr.GetString(13);

                            //display retieved record

                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department, employeeModel.Gender);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    //Close Data Reader
                    dr.Close();
                    this.connection.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        ///Uc3 Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(EmployeeModel model)
        {
            string query = @"Update Employee_payroll Set BasicPay=3000000.00 Where EmployeeName='Terisa'";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            EmployeeModel employeeModel = new EmployeeModel();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employeeModel.EmployeeName = dr.GetString(1);
                    employeeModel.BasicPay = dr.GetDouble(6);
                    //display retieved record

                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department, employeeModel.Gender, employeeModel.BasicPay);
                    Console.WriteLine("\n");


                }
            }

        }

    }

}

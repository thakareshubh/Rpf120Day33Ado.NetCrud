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
        /// <summary>
        /// Uc5-Retrieves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Retrieve(EmployeeModel model)
        {
            
            string query = @"Select * From Employee_payroll Where StartDate Between '1894-06-23' And '2022-04-07'";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            EmployeeModel employeeModel = new EmployeeModel();
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

                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", employeeModel.EmployeeID, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department, employeeModel.Gender, employeeModel.BasicPay);
                    Console.WriteLine("\n");
                }
            }
            this.connection.Close();

        }
        

          /// <summary>
          ///Uc6- Aggregates the specified model.
          /// </summary>
          /// <param name="model">The model.</param>
          public void Aggregate(EmployeeModel model)
        {
            string query = @"Select Sum(BasicPay) From Employee_payroll Where Gender ='M' Group By Gender";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            EmployeeModel employeeModel = new EmployeeModel();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employeeModel.BasicPay = dr.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("Sum of Basic Pay for Male : " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query2 = @"Select Sum(BasicPay) From Employee_payroll Where Gender ='F' Group By Gender";
            SqlCommand cmd2 = new SqlCommand(query2, this.connection);
            this.connection.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();

            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    employeeModel.BasicPay = dr2.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("Sum of Basic Pay for Female: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query3 = @"Select AVG(BasicPay) From Employee_payroll Where Gender ='M' Group By Gender";
            SqlCommand cmd3 = new SqlCommand(query3, this.connection);
            this.connection.Open();
            SqlDataReader dr3 = cmd3.ExecuteReader();

            if (dr3.HasRows)
            {
                while (dr3.Read())
                {
                    employeeModel.BasicPay = dr3.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("AVG of Basic Pay for Male: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query4 = @"Select AVG(BasicPay) From Employee_payroll Where Gender ='F' Group By Gender";
            SqlCommand cmd4 = new SqlCommand(query4, this.connection);
            this.connection.Open();
            SqlDataReader dr4 = cmd4.ExecuteReader();

            if (dr4.HasRows)
            {
                while (dr4.Read())
                {
                    employeeModel.BasicPay = dr4.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("AVG of Basic Pay for Female: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query5 = @"Select Min(BasicPay) From Employee_payroll Where Gender ='M' Group By Gender";
            SqlCommand cmd5 = new SqlCommand(query5, this.connection);
            this.connection.Open();
            SqlDataReader dr5 = cmd3.ExecuteReader();

            if (dr5.HasRows)
            {
                while (dr5.Read())
                {
                    employeeModel.BasicPay = dr5.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("Min of Basic Pay for Male: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query6 = @"Select Min(BasicPay) From Employee_payroll Where Gender ='F' Group By Gender";
            SqlCommand cmd6 = new SqlCommand(query6, this.connection);
            this.connection.Open();
            SqlDataReader dr6 = cmd6.ExecuteReader();

            if (dr6.HasRows)
            {
                while (dr6.Read())
                {
                    employeeModel.BasicPay = dr6.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("Min of Basic Pay for Female: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query7 = @"Select Max(BasicPay) From Employee_payroll Where Gender ='M' Group By Gender";
            SqlCommand cmd7 = new SqlCommand(query7, this.connection);
            this.connection.Open();
            SqlDataReader dr7 = cmd7.ExecuteReader();

            if (dr7.HasRows)
            {
                while (dr7.Read())
                {
                    employeeModel.BasicPay = dr7.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("Max of Basic Pay for Male: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query8 = @"Select Max(BasicPay) From Employee_payroll Where Gender ='F' Group By Gender";
            SqlCommand cmd8 = new SqlCommand(query8, this.connection);
            this.connection.Open();
            SqlDataReader dr8 = cmd8.ExecuteReader();

            if (dr8.HasRows)
            {
                while (dr8.Read())
                {
                    employeeModel.BasicPay = dr8.GetDouble(0);
                    //display retieved record

                    Console.WriteLine("Min of Basic Pay for Female: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query9 = @"Select Count(BasicPay) From Employee_payroll Where Gender ='M' Group By Gender";
            SqlCommand cmd9 = new SqlCommand(query9, this.connection);
            this.connection.Open();
            SqlDataReader dr9 = cmd9.ExecuteReader();

            if (dr9.HasRows)
            {
                while (dr9.Read())
                {
                    employeeModel.BasicPay = dr9.GetInt32(0);
                    //display retieved record

                    Console.WriteLine("Count of Basic Pay for Male: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();
            string query10 = @"Select Count(BasicPay) From Employee_payroll Where Gender ='F' Group By Gender";
            SqlCommand cmd10 = new SqlCommand(query10, this.connection);
            this.connection.Open();
            SqlDataReader dr10 = cmd10.ExecuteReader();

            if (dr10.HasRows)
            {
                while (dr10.Read())
                {
                    employeeModel.BasicPay = dr10.GetInt32(0);
                    //display retieved record

                    Console.WriteLine("Count of Basic Pay for Female: " + "{0}", employeeModel.BasicPay);
                }
            }
            this.connection.Close();


        }

    }

}

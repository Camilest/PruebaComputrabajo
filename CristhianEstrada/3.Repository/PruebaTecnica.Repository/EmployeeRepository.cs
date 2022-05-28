using PruebaTecnica.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PruebaTecnica.Repository
{
    public partial class EmployeeRepository
    {
        private string DbConnectionString { get; set; }
        private SqlConnection SqlConnection { get; set; }
        private const string TABLE = "Employees";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        public EmployeeRepository(string dbConnectionString)
        {
            this.DbConnectionString = dbConnectionString;
            this.SqlConnection = new SqlConnection(dbConnectionString);
        }

        /// <summary>
        /// Permite agregar un nuevo empleado.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmployee(Employee employee)
        {
            int employeeId = 0;
            this.SqlConnection.Open();
            try
            {
                string values =
                    $"{nameof(employee.CompanyId)}, {nameof(employee.CreatedOn)}, {nameof(employee.DeletedOn)}, " +
                    $"{nameof(employee.Email)}, {nameof(employee.Fax)}, {nameof(employee.Name)}, {nameof(employee.Lastlogin)}, " +
                    $"{nameof(employee.Password)}, {nameof(employee.PortalId)}, {nameof(employee.RoleId)}, {nameof(employee.StatusId)}, " +
                    $"{nameof(employee.Telephone)}, {nameof(employee.UpdatedOn)}, {nameof(employee.Username)}";

                string data =
                    $"{employee.CompanyId}, {employee.CreatedOn}, {employee.DeletedOn}, " +
                    $"{employee.Email}, {employee.Fax}, {employee.Name}, {employee.Lastlogin}, " +
                    $"{employee.Password}, {employee.PortalId}, {employee.RoleId}, {employee.StatusId}, " +
                    $"{employee.Telephone}, {employee.UpdatedOn}, {employee.Username}";

                string sql = $"INSERT INTO {TABLE} ({values}) VALUES ({data})";
                SqlCommand cmd = new SqlCommand(sql, this.SqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            this.SqlConnection.Close();
            return employeeId;
        }

        /// <summary>
        /// Obtener todos los empleados desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            this.SqlConnection.Open();
            try
            {
                string sql = $"SELECT * FROM {TABLE}";
                SqlCommand cmd = new SqlCommand(sql, this.SqlConnection);
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    var testc = result["Username"];
                    Employee employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(result["EmployeeId"]),
                        CompanyId = result["CompanyId"].ToString(),
                        CreatedOn = result["CreatedOn"].ToString(),
                        DeletedOn = result["DeletedOn"].ToString(),
                        Email = result["Email"].ToString(),
                        Fax = result["Fax"].ToString(),
                        Name = result["Name"].ToString(),
                        Lastlogin = result["Lastlogin"].ToString(),
                        Password = result["Password"].ToString(),
                        PortalId = result["PortalId"].ToString(),
                        RoleId = result["RoleId"].ToString(),
                        StatusId = result["StatusId"].ToString(),
                        Telephone = result["Telephone"].ToString(),
                        UpdatedOn = result["UpdatedOn"].ToString(),
                        Username = result["Username"].ToString()
                    };
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {

            }
            this.SqlConnection.Close();
            return employees;
        }

        /// <summary>
        /// Obtener un empleado por el identificador.
        /// </summary>
        /// <param name="employeeId"></param>
        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = null;
            this.SqlConnection.Open();
            try
            {
                string sql = $"SELECT TOP 1 * FROM {TABLE} WHERE EmployeeId = {employeeId}";
                SqlCommand cmd = new SqlCommand(sql, this.SqlConnection);
                SqlDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(result["EmployeeId"]),
                        CompanyId = result["CompanyId"].ToString(),
                        CreatedOn = result["CreatedOn"].ToString(),
                        DeletedOn = result["DeletedOn"].ToString(),
                        Email = result["Email"].ToString(),
                        Fax = result["Fax"].ToString(),
                        Name = result["Name"].ToString(),
                        Lastlogin = result["Lastlogin"].ToString(),
                        Password = result["Password"].ToString(),
                        PortalId = result["PortalId"].ToString(),
                        RoleId = result["RoleId"].ToString(),
                        StatusId = result["StatusId"].ToString(),
                        Telephone = result["Telephone"].ToString(),
                        UpdatedOn = result["UpdatedOn"].ToString(),
                        Username = result["Username"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {

            }
            this.SqlConnection.Close();
            return employee;
        }

        /// <summary>
        /// Actualizar un registro existente.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string UpdateEmployee(Employee employee)
        {
            string result = string.Empty;
            this.SqlConnection.Open();
            try
            {
                // Construcción de los campos que se desean actualizar.
                StringBuilder sbValue = new StringBuilder();
                sbValue.Append($"{nameof(Employee.CompanyId)} = {employee.CompanyId},");
                sbValue.Append($"{nameof(Employee.CreatedOn)} = {employee.CreatedOn},");
                sbValue.Append($"{nameof(Employee.DeletedOn)} = {employee.DeletedOn},");
                sbValue.Append($"{nameof(Employee.Email)} = {employee.Email},");
                sbValue.Append($"{nameof(Employee.Fax)} = {employee.Fax},");
                sbValue.Append($"{nameof(Employee.Name)} = {employee.Name},");
                sbValue.Append($"{nameof(Employee.Lastlogin)} = {employee.Lastlogin},");
                sbValue.Append($"{nameof(Employee.Password)} = {employee.Password},");
                sbValue.Append($"{nameof(Employee.RoleId)} = {employee.RoleId},");
                sbValue.Append($"{nameof(Employee.StatusId)} = {employee.StatusId},");
                sbValue.Append($"{nameof(Employee.Telephone)} = {employee.Telephone},");
                sbValue.Append($"{nameof(Employee.UpdatedOn)} = {employee.UpdatedOn},");
                sbValue.Append($"{nameof(Employee.Username)} = {employee.Username}");
                // Construcción de los filtros.
                StringBuilder sbValueFilter = new StringBuilder();
                sbValueFilter.Append($"{nameof(Employee.EmployeeId)} = {employee.EmployeeId}");

                string sql = $"UPDATE {TABLE} SET {sbValue} WHERE {sbValueFilter}";
                SqlCommand cmd = new SqlCommand(sql, this.SqlConnection);
                int cant = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return result = $"ha ocurrido un error al actualizar el registro: {ex.Message}";
            }
            this.SqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Eliminar un registro por el identificar del empleado.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public string DeleteEmployee(int employeeId)
        {
            string result = string.Empty;
            this.SqlConnection.Open();
            try
            {
                string sql = $"DELETE FROM {TABLE} WHERE {nameof(Employee.EmployeeId)} = {employeeId}";
                SqlCommand cmd = new SqlCommand(sql, this.SqlConnection);
                int cant = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return result = $"ha ocurrido un error al eliminar el registro: {ex.Message}";
            }
            this.SqlConnection.Close();
            return result;
        }
    }
}

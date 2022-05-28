using PruebaTecnica.DTO;
using PruebaTecnica.Repository;
using System;
using System.Collections.Generic;

namespace PruebaTecnica.BLL
{
    public partial class EmployeeBll
    {
        /// <summary>
        /// 
        /// </summary>
        private string DbConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection"></param>
        public EmployeeBll(string dbConnectionString)
        {
            this.DbConnectionString = dbConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        [ThreadStatic]
        private EmployeeRepository _EmployeeRepository;
        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (this._EmployeeRepository == null)
                {
                    this._EmployeeRepository = new EmployeeRepository(this.DbConnectionString);
                }
                return this._EmployeeRepository;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyId"></param>
        /// <param name="createdOn"></param>
        /// <param name="deletedOn"></param>
        /// <param name="email"></param>
        /// <param name="fax"></param>
        /// <param name="name"></param>
        /// <param name="lastlogin"></param>
        /// <param name="password"></param>
        /// <param name="portalId"></param>
        /// <param name="roleId"></param>
        /// <param name="statusId"></param>
        /// <param name="telephone"></param>
        /// <param name="updatedOn"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public int AddEmployee(string companyId, string createdOn, string deletedOn, string email, string fax, string name, string lastlogin,
            string password, string portalId, string roleId, string statusId, string telephone, string updatedOn, string username)
        {
            var employee = new Employee
            {
                CompanyId = companyId,
                CreatedOn = createdOn,
                DeletedOn = deletedOn,
                Email = email,
                Fax = fax,
                Name = name,
                Lastlogin = lastlogin,
                Password = password,
                PortalId = portalId,
                RoleId = roleId,
                StatusId = statusId,
                Telephone = telephone,
                UpdatedOn = updatedOn,
                Username = username
            };
            return this.EmployeeRepository.AddEmployee(employee);
        }

        /// <summary>
        /// Obtener todos los empleados desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return this.EmployeeRepository.GetEmployees();
        }

        /// <summary>
        /// Obtener un empleado por el identificador.
        /// </summary>
        /// <param name="employeeId"></param>
        public Employee GetEmployeeById(int employeeId)
        {
            return this.EmployeeRepository.GetEmployeeById(employeeId);
        }

        /// <summary>
        /// Actualizar un registro existente.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string UpdateEmployee(string companyId, string createdOn, string deletedOn, string email, string fax, string name, string lastlogin,
            string password, string portalId, string roleId, string statusId, string telephone, string updatedOn, string username)
        {
            var employee = new Employee
            {
                CompanyId = companyId,
                CreatedOn = createdOn,
                DeletedOn = deletedOn,
                Email = email,
                Fax = fax,
                Name = name,
                Lastlogin = lastlogin,
                Password = password,
                PortalId = portalId,
                RoleId = roleId,
                StatusId = statusId,
                Telephone = telephone,
                UpdatedOn = updatedOn,
                Username = username
            };
            string result = this.EmployeeRepository.UpdateEmployee(employee);
            return result;
        }

        /// <summary>
        /// Eliminar un registro por el identificar del empleado.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public string DeleteEmployee(int employeeId)
        {
            return this.EmployeeRepository.DeleteEmployee(employeeId);
        }
    }
}

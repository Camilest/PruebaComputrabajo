using PruebaTecnica.BLL;
using PruebaTecnica.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Obtener cadena de conexión que se encuentra establecida en el archivo de configuración.
        /// </summary>
        public virtual string DbConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString; }
        }

        [ThreadStatic]
        private EmployeeBll _EmployeeBll;
        public EmployeeBll EmployeeBll
        {
            get
            {
                if (this._EmployeeBll == null)
                {
                    this._EmployeeBll = new EmployeeBll(this.DbConnectionString);
                }
                return this._EmployeeBll;
            }
        }

        /// <summary>
        /// Obtener todos los empleados que se encuentren en la tabla.
        /// </summary>
        /// <returns>Lista de empleados.</returns>
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return this.EmployeeBll.GetEmployees();
        }

        /// <summary>
        /// Obtener empleado mediante el identificador interno de la base de datos.
        /// </summary>
        /// <param name="employeeId">Identificador interno.</param>
        /// <returns>Empleado seleccionado</returns>
        [HttpGet, ActionName("GetEmployeeById")]
        public Employee GetEmployeeById(int employeeId)
        {
            return this.EmployeeBll.GetEmployeeById(employeeId);
        }

        /// <summary>
        /// Permite agregar un nuevo empleado en la tabla de empleado.
        /// </summary>
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
        /// <returns>Identificador de empleado agregado.</returns>
        [HttpPost, ActionName("AddEmployee")]
        public int AddEmployee(string companyId, string createdOn, string deletedOn, string email, string fax, string name, string lastlogin,
            string password, string portalId, string roleId, string statusId, string telephone, string updatedOn, string username)
        {
            int employeeId = this.EmployeeBll.AddEmployee(companyId, createdOn, deletedOn, email, fax, name, lastlogin, password, portalId, roleId, statusId, telephone, updatedOn, username);
            return employeeId;
        }        

        /// <summary>
        /// Permite realizar la actualización de un empleado especifico.
        /// </summary>
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
        /// <returns>Mensaje de ejecución.</returns>
        [HttpPut, ActionName("UpdateEmployee")]
        public string UpdateEmployee(string companyId, string createdOn, string deletedOn, string email, string fax, string name, string lastlogin,
            string password, string portalId, string roleId, string statusId, string telephone, string updatedOn, string username)
        {
            string result = this.EmployeeBll.UpdateEmployee(companyId, createdOn, deletedOn, email, fax, name, lastlogin, password, portalId, roleId, statusId, telephone, updatedOn, username);
            return result;
        }

        /// <summary>
        /// Permite eliminar a un empleado mediante el identificador interno.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Mensaje de ejecución.</returns>
        [HttpDelete, ActionName("DeleteEmployee")]
        public string DeleteEmployee(int employeeId)
        {
            return this.EmployeeBll.DeleteEmployee(employeeId);
        }
    }
}

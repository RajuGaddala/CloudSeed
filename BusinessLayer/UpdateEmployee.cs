using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UpdateEmployee : IEmployee
    {
        EmployeeModel objEmpDetails = null;
        public UpdateEmployee(EmployeeModel empDetails)
        {
            objEmpDetails = empDetails;
        }
        public T Process<T>()
        {
            string Qry = "UPDATE tblEmployee SET Name='" + objEmpDetails.EmpName + "', Gender = '" + objEmpDetails.Gender + "', DOB = '" + objEmpDetails.DateOfBirth + "', DOJ = '" + objEmpDetails.DateOfJoin + "', Salary ='" + objEmpDetails.Salary + "' WHERE Id='" + objEmpDetails.EmpId + "'";
            return (T)(object)new DataAccess().ExecuteNonQuery(Qry);
        }

        public int SaveEmployee(EmployeeModel objEmpDetails)
        {
            try
            {
                string Qry = "UPDATE tblEmployee SET Name='" + objEmpDetails.EmpName + "', Gender = '" + objEmpDetails.Gender + "', DOB = '" + objEmpDetails.DateOfBirth + "', DOJ = '" + objEmpDetails.DateOfJoin + "', Salary ='" + objEmpDetails.Salary + "' WHERE Id='" + objEmpDetails.EmpId + "'";
                return new DataAccess().ExecuteNonQuery(Qry);
            }
            catch
            {
                throw;
            }
        }
    }
}

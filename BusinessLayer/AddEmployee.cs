using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AddEmployee : IEmployee
    {
        EmployeeModel objEmpDetails = null;
        public AddEmployee(EmployeeModel empDetails)
        {
            objEmpDetails = empDetails;
        }

        public T Process<T>()
        {
            string Qry = "insert into tblEmployee(Name, Gender, DOB, DOJ, Salary) values ('" + objEmpDetails.EmpName + "', '" + objEmpDetails.Gender + "','" + objEmpDetails.DateOfBirth + "','" + objEmpDetails.DateOfJoin + "','" + objEmpDetails.Salary + "')";
            return (T)(object)new DataAccess().ExecuteNonQuery(Qry);
        }

        public int InsertEmployee(EmployeeModel objEmpDetails)
        {
            try
            {

                string Qry = "insert into tblEmployee(Name, Gender, DOB, DOJ, Salary) values ('" + GetEmpId() + "','" + objEmpDetails.EmpName + "', '" + objEmpDetails.Gender + "','" + objEmpDetails.DateOfBirth + "','" + objEmpDetails.DateOfJoin + "','" + objEmpDetails.Salary + "')";
                return new DataAccess().ExecuteNonQuery(Qry);
            }
            catch
            {
                throw;
            }
        }

        private int GetEmpId()
        {
            DataSet myDs = new DataAccess().ExecuteQuery(" select max(Id) from tblEmployee");
            if (myDs != null & myDs.Tables.Count > 0 && myDs.Tables[0].Rows.Count > 0)
                return Convert.ToInt16(myDs.Tables[0].Rows[0][0].ToString()) + 1;

            return 0;
        }
    }
}

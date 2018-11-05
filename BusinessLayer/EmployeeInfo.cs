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
    public class EmployeeInfo : IEmployee
    {
        DataTable myDT = null;
        public EmployeeInfo()
        {

        }
        public DataTable GetEmployeeDetails()
        {
            myDT = new System.Data.DataTable();
            try
            {
                string Qry = "select * from tblEmployee";
                DataSet myDs = new DataAccess().ExecuteQuery(Qry);
                if (myDs != null & myDs.Tables.Count > 0)
                    myDT = myDs.Tables[0];
            }
            catch
            {
                throw;
            }
            return myDT;
        }
        public T Process<T>()
        {
            myDT = new System.Data.DataTable();
            try
            {
                string Qry = "select * from tblEmployee";
                DataSet myDs = new DataAccess().ExecuteQuery(Qry);
                if (myDs != null & myDs.Tables.Count > 0)
                    myDT = myDs.Tables[0];
            }
            catch
            {
                throw;
            }
            return (T)(object)myDT;
        }
    }
}

using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DeleteEmployee : IEmployee
    {
        int empId = 0;
        public DeleteEmployee(int EmpId)
        {
            empId = EmpId;
        }
        public T Process<T>()
        {
            string Qry = "DELETE FROM tblEmployee WHERE Id='" + empId + "'";
            return (T)(object)new DataAccess().ExecuteNonQuery(Qry);
        }

        public int RemoveEmployee()
        {
            try
            {
                string Qry = "DELETE FROM tblEmployee WHERE Id='" + empId + "'";
                return new DataAccess().ExecuteNonQuery(Qry);
            }
            catch
            {
                throw;
            }
        }
    }
}

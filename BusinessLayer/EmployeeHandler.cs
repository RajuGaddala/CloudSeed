using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeHandler : EmployeeFactory
    {
        public override IEmployee GetHandler(EmployeeModel objEmpDetails)
        {
            IEmployee instance = null;
            switch (objEmpDetails.Operation)
            {
                case "GET":
                    instance = new EmployeeInfo();
                    break;
                case "INSERT":
                    instance = new AddEmployee(objEmpDetails);
                    break;
                case "UPDATE":
                    instance = new UpdateEmployee(objEmpDetails);
                    break;
                case "DELETE":
                    instance = new DeleteEmployee(objEmpDetails.EmpId);
                    break;
            }

            return instance;
        }
    }
}

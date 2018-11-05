using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public abstract class EmployeeFactory
    {
        public abstract IEmployee GetHandler(EmployeeModel objEmpDetails);
        public static IEmployee GetInstance(EmployeeModel objEmpDetails)
        {
            EmployeeFactory factory = new EmployeeHandler();
            IEmployee instance = factory.GetHandler(objEmpDetails);
            return instance;
        }
    }
}

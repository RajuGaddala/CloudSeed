using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeModel
    {
        #region " Public Properties "

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfJoin { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public string Operation { get; set; }

        #endregion
    }
}

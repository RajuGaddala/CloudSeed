System.register([], function (exports_1, context_1) {
  "use strict";
  var __moduleName = context_1 && context_1.id;
  var Employee;
  return {
    setters: [],
    execute: function () {
      Employee = (function () {
        debugger;
        function Employee(EmpId, EmpName, Gender, DateOfBirth, DateOfJoin, Salary, Operation) {
          this.EmpId = EmpId;
          this.EmpName = EmpName;
          this.Gender = Gender;
          this.DateOfBirth = DateOfBirth;
          this.DateOfJoin = DateOfJoin;
          this.Salary = Salary;
          this.Operation = Operation;
        }
        return Employee;
      }());
      exports_1("Employee", Employee);
    }
  };
});

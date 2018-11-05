using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessLayer;
using BusinessLayer.Interface;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ExceptionHandler]
    public class EmployeeController : ApiController
    {
   
        /// <summary>
        /// Below mthod is not required. But I have implemented it with FACTORY METHOD PATTERN using a generic method (class will be known at runtime only)
        /// For all the operations, we can use this single method. 
        /// POST is faster and secured compared to remaining HTTP verbs. So below method used with POST.
        /// </summary>
        /// <param name="empDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EmployeeOperations(EmployeeModel empDetails)
        {
            try
            {
                empDetails = empDetails.Operation == null ? new EmployeeModel() { EmpId = 0, EmpName = "", Gender = "", DateOfBirth = "", DateOfJoin = "", Salary = 0, Operation = "GET" } : empDetails;
                IEmployee instance = EmployeeFactory.GetInstance(empDetails);
                var result = instance.Process<object>();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                var errorMessagError = new HttpError(ex.Message) { { "ErrorCode", 405 } };
                throw new HttpResponseException(ControllerContext.Request.CreateErrorResponse
                    (HttpStatusCode.MethodNotAllowed, errorMessagError));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetEmployeeDetails()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new EmployeeInfo().GetEmployeeDetails());
            }
            catch (Exception ex)
            {
                var errorMessagError = new HttpError(ex.Message) { { "ErrorCode", 405 } };
                throw new HttpResponseException(ControllerContext.Request.CreateErrorResponse
                    (HttpStatusCode.MethodNotAllowed, errorMessagError));
            }
        }

        [HttpPost]
        public HttpResponseMessage AddEmployee(EmployeeModel empDetails)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new AddEmployee(empDetails).InsertEmployee(empDetails));
            }
            catch (Exception ex)
            {
                var errorMessagError = new HttpError(ex.Message) { { "ErrorCode", 405 } };
                throw new HttpResponseException(ControllerContext.Request.CreateErrorResponse
                    (HttpStatusCode.MethodNotAllowed, errorMessagError));
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateEmployee(EmployeeModel empDetails)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new UpdateEmployee(empDetails).SaveEmployee(empDetails));
            }
            catch (Exception ex)
            {
                var errorMessagError = new HttpError(ex.Message) { { "ErrorCode", 405 } };
                throw new HttpResponseException(ControllerContext.Request.CreateErrorResponse
                    (HttpStatusCode.MethodNotAllowed, errorMessagError));
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int EmpId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new DeleteEmployee(EmpId).RemoveEmployee());
            }
            catch (Exception ex)
            {
                var errorMessagError = new HttpError(ex.Message) { { "ErrorCode", 405 } };
                throw new HttpResponseException(ControllerContext.Request.CreateErrorResponse
                    (HttpStatusCode.MethodNotAllowed, errorMessagError));
            }
        }



    }
}

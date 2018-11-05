import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, URLSearchParams, Headers } from '@angular/http';
import * as globalURLs from './GlobalUrls';
import { Observable } from 'rxjs/internal/Observable';
import { contentHeaders } from '../common/headers';
import { EmployeeModel } from '../app/employee.model';


@Injectable()
export class EmployeeService {
  employee: EmployeeModel;
  constructor(private http: Http) { }


  getEmployeeDetails(): Observable<Response> {
    //debugger;
    this.employee = new EmployeeModel(0, '', '', '', '', 0, "GET");
    let options = new RequestOptions(
      { headers: contentHeaders });

    try {
      return this.http.get(globalURLs.apiURL + 'GetEmployeeDetails');
      //return this.http.post(globalURLs.apiURL + 'EmployeeOperations', JSON.stringify(this.employee), options)
    }
    catch (e) {
      console.log(e.toString());
    }
  }

  addEmployee(emp: EmployeeModel): Observable<Response> {
    //debugger;
    let options = new RequestOptions(
      { headers: contentHeaders });

    emp.Operation = "INSERT";

    try {
      return this.http.post(globalURLs.apiURL + 'AddEmployee', JSON.stringify(emp), options);
      //return this.http.post(globalURLs.apiURL + 'EmployeeOperations', JSON.stringify(this.employee), options);
    }
    catch (e) {
      console.log(e.toString());
    }

  }

  updateEmployee(id: Number, emp: EmployeeModel): Observable<Response> {
    let options = new RequestOptions(
      { headers: contentHeaders });

    emp.Operation = "UPDATE";

    try {
      return this.http.put(globalURLs.apiURL + 'UpdateEmployee/' + id, JSON.stringify(emp), options);
    }
    catch (e) {
      console.log(e.toString());
    }
  }

  deleteEmployee(id: Number): Observable<Response> {
    let options = new RequestOptions(
      { headers: contentHeaders });

    try {
      return this.http.delete(globalURLs.apiURL + 'DeleteEmployee?EmpId=' + id)
    }
    catch (e) {
      console.log(e.toString());
    }
  }

  getError(error: Response) {
    return Observable.throw(error);
  }
}

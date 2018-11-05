import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/ActionToBePerform';
import { EmployeeModel } from './employee.model';
import { TemplateRef, ViewChild } from '@angular/core';
import { Headers, Response } from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [EmployeeService]
})
export class AppComponent implements OnInit {
  @ViewChild('readOnlyTemplate') readOnlyTemplate: TemplateRef<any>;
  @ViewChild('editTemplate') editTemplate: TemplateRef<any>;

  objEmployeeService: EmployeeService;
  apiName: string = "";
  empList = [];
  employee: EmployeeModel;
  selemp: EmployeeModel;
  isNewRecord: boolean;
  statusMessage: string;

  constructor(EmployeeService: EmployeeService) {
    this.objEmployeeService = EmployeeService;
    this.selemp = new EmployeeModel(10005, '', '', '', '', 0, "");
  }
  ngOnInit() {
    // this.getUserName("Mahismathi");
    this.GetEmployees();
  }
  getUserName(name: string): void {
    //debugger;
    //this.objEmployeeService.getName(name)
    //  .subscribe(res => this.getResponse(res), (error) => {
    //    console.log(error);
    //  });
  }

  GetEmployees() {
   // debugger;
    this.objEmployeeService.getEmployeeDetails()
      .subscribe(res => this.getResponse(res), (error) => {
        console.log(error);
      });
  }

  addEmp() {
    this.selemp = new EmployeeModel(0, '', '', '', '', 0, "INSERT");
    this
      .empList
      .push(this.selemp);
    this.isNewRecord = true;
  }

  editEmployee(emp: EmployeeModel) {
    //debugger;
    this.selemp = emp;
    this.loadTemplate(emp);
  }

  loadTemplate(emp: EmployeeModel) {
    if (this.selemp && this.selemp.Id == emp.Id) {
      return this.editTemplate;
    } else {
      return this.readOnlyTemplate;
    }
  }

  addOrUpdateEmployee() {
    //debugger;
    if (this.isNewRecord) {
      this.objEmployeeService.addEmployee(this.selemp).subscribe((resp: Response) => {
        this.employee = resp.json(),
          this.statusMessage = 'Record Added Successfully.',
          this.GetEmployees();
      });
      this.isNewRecord = false;
      this.selemp = null;

    } else {
      this.objEmployeeService.updateEmployee(this.selemp.Id, this.selemp).subscribe((resp: Response) => {
        this.statusMessage = 'Record Updated Successfully.',
          this.GetEmployees();
      });
      this.selemp = null;

    }
  }
  cancel() {
    this.selemp = null;
  }

  deleteEmployee(emp: EmployeeModel) {
    //debugger;
    this.objEmployeeService.deleteEmployee(emp.Id).subscribe((resp: Response) => {
      this.statusMessage = 'Record Deleted Successfully.',
        this.GetEmployees();
    });

  }

  getResponse(res: any) {
    //debugger;
    this.empList = res.json();
  }
}

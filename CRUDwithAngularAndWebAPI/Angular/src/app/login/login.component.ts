import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login.model';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { element } from 'protractor';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: LoginModel = new LoginModel();
  constructor(private router: Router, private authService: UserService) {
    if (sessionStorage.getItem("userId") != null) {
      if (sessionStorage.getItem("userId").length < 1) {
        sessionStorage.removeItem("userId");
      }
    }
  };


  ngOnInit() {
  }

  onSubmit() {
    debugger;
    var result = this.authService.login(this.login.username, this.login.password);
    if (sessionStorage.getItem("userId") != null) {
      if (sessionStorage.getItem("userId").length > 1) {
        this.router.navigate(['/home']);
      }
    }
    this.router.navigate(['/login']);


  }



}

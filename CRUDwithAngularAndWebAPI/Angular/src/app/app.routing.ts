import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';
import { UserService } from '../services/user.service';

@NgModule({
  imports: [
    RouterModule.forRoot([
    { path: 'login', component: LoginComponent },
    { path: 'home', component: AppComponent, canActivate: [UserService] },
    ])
  ],
  exports: [
    RouterModule
  ]
})

export class AppRoutingModule {

}

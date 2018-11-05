import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response, URLSearchParams } from '@angular/http';
import { Router } from '@angular/router';
import { IProfile, UserProfile } from './user.profile';
import { contentHeaders } from '../common/headers';

@Injectable()
export class UserService {
  redirectUrl: string;
  errorMessage: string;
  constructor(
    private http: Http,
    private router: Router,
    private authProfile: UserProfile) { }

  login(userName: string, password: string) {
    //debugger;
    if (!userName || !password) {
      return;
    }

    if (userName == "root" && password == "root") {
      var userProfile: IProfile = { userId: "1", userName: userName };
      this.authProfile.setProfile(userProfile);
    }
    else {
      this.authProfile.resetProfile();
    }

  }

  logout(): void {
    this.authProfile.resetProfile();
  }
}

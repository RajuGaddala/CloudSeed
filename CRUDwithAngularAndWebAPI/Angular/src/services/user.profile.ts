import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Headers } from '@angular/http';

@Injectable()
export class UserProfile {
  userProfile: IProfile = {
    userId: "",
    userName: ""
  };
  constructor(private router: Router) {
    //debugger;
  }

  setProfile(profile: IProfile): void {
    //debugger;
    var custid = 'dfgdfgdfg'; // profile.claims.filter(p => p.type == 'CustomerId')[0].value;
    var userName = 'RajuG'; // profile.claims.filter(p => p.type == 'username')[0].value;

    this.userProfile.userId = profile['userId'];
    this.userProfile.userName = profile['userName'];

    sessionStorage.setItem('userName', this.userProfile.userName);
    sessionStorage.setItem('userId', this.userProfile.userId);
  }


  resetProfile(): IProfile {
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('userId');
    
    this.userProfile = {
      userName: "",
      userId: ""
    };
    return this.userProfile;
  }
}

export interface IProfile {
  userId: string;
  userName: string;
}


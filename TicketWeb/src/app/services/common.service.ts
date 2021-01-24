import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor() { }

  private customerEmail = new BehaviorSubject('');
  getEmail = this.customerEmail.asObservable();

  setEmail(email: string) {
    this.customerEmail.next(email);
  }

  private userType = new BehaviorSubject('');
  getUserType = this.userType.asObservable();

  setUserType(usertype: string) {
    this.userType.next(usertype);
  }
}

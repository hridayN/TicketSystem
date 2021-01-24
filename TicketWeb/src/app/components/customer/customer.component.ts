import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ExitRequest } from 'src/app/models/ExitRequest';
import { LoginRequest } from 'src/app/models/LoginRequest';
import { LoginResponse } from 'src/app/models/LoginResponse';
import { User } from 'src/app/models/User';
import { CommonService } from 'src/app/services/common.service';
import { ExitService } from 'src/app/services/exit.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  email = '';
  alive = new Subject();
  tickets: LoginResponse;
  agentName = '';
  constructor(private _loginService: LoginService,
    private _commonService: CommonService,
    private _exitService: ExitService,
    private _router: Router) { }

  ngOnInit(): void {
    this._commonService.getEmail.pipe(takeUntil(this.alive)).subscribe(emailValue => {
      if (emailValue?.trim() !== '') {
        this.email = emailValue;
        this.getTicketsInfo();
      }
    });
  }

  getTicketsInfo() {
    const userInfo = new User();
    userInfo.Email = this.email;
    userInfo.UserType = "Customer";

    const loginRequest = new LoginRequest();
    loginRequest.User = userInfo;
    this._loginService.login(loginRequest).pipe(takeUntil(this.alive)).subscribe((loginResponse: LoginResponse) => {
      this.tickets = new LoginResponse();
      this.tickets = loginResponse;
      this.agentName = this.tickets.TicketSystemInfo[0].Users[0].AgentName;
    });
  }

  exit() {
    const exitRequest = new ExitRequest();
    exitRequest.Email = this.email;
    this._exitService.exit(exitRequest).pipe(takeUntil(this.alive)).subscribe(response => {
      if (response != null) {
        this._commonService.setEmail('');
        this._commonService.setUserType('');
      }
    });
    this._router.navigate(['/login']);
  }
}

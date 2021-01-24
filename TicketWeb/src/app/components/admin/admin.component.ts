import { Component, Input, OnInit } from '@angular/core';
import { Agent } from 'src/app/models/Agent';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { LoginRequest } from 'src/app/models/LoginRequest';
import { LoginResponse } from 'src/app/models/LoginResponse';
import { User } from 'src/app/models/User';
import { CommonService } from 'src/app/services/common.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  private alive = new Subject();
  tickets: LoginResponse;
  email = '';
  agentsList = new Array<Agent>();
  userList = new Array<User>();
  constructor(private _loginService: LoginService,
    private _commonService: CommonService) { }

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
    userInfo.UserType = "Admin";

    const loginRequest = new LoginRequest();
    loginRequest.User = userInfo;
    this._loginService.login(loginRequest).pipe(takeUntil(this.alive)).subscribe((loginResponse: LoginResponse) => {
      this.tickets = new LoginResponse();
      this.tickets = loginResponse;
      this.setData(this.tickets);
    });
  }

  setData(tickets: LoginResponse) {
    tickets.TicketSystemInfo.forEach(info => {
      if (this.agentsList.find(x => x.Id === info.AgentId) === null) {
        let agent = new Agent();
        agent.AgentName = info.Users[0].AgentName;
        agent.Id = info.AgentId;
        this.agentsList.push(agent);
      }
    });

    tickets.TicketSystemInfo.forEach(info => {
      if (this.userList.find(x => x.Email === info.Users[0].Email) === null)
      {
        let user = new User();
        user.Email = info.Users[0].Email;
        this.userList.push(user);
      }
    });
  }
}

import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginRequest } from 'src/app/models/LoginRequest';
import { UserType } from 'src/app/models/UserType';
import { LoginService } from 'src/app/services/login.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { LoginResponse } from 'src/app/models/LoginResponse';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';
import { Console } from 'console';
import * as EventEmitter from 'events';
import { CommonService } from 'src/app/services/common.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userFormGroup: FormGroup;
  userType = [ "Admin", "Customer" ];
  constructor(private _fb: FormBuilder,
    private _router: Router,
    private _commonService: CommonService) { }

  ngOnInit(): void {
    this.userFormGroup = this._fb.group({
      email: this._fb.control(null, [Validators.required]),
      usertype: this._fb.control(null, [Validators.required])
    });
  }

  login() {
    this._commonService.setEmail(this.userFormGroup.controls.email.value);
    this._commonService.setUserType(this.userFormGroup.controls.usertype.value);
    
    switch(this.userFormGroup.controls.usertype.value) {
      case "Admin": 
      this._router.navigate(['/admin']); 
      break;
      default: 
      this._router.navigate(['/customer']); break;
    }
  }

  validateInfo() : boolean {
    return (this.userFormGroup.valid) ? true : false;
  }

}

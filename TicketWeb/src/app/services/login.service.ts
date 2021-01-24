import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from '../models/LoginRequest';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { LoginResponse } from '../models/LoginResponse';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = environment.ticketSystemApiUrl;
  constructor(private http: HttpClient) { }

  login(loginRequest: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.apiUrl + 'login', loginRequest);
  }
}

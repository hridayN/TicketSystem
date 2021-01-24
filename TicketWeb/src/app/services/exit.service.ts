import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ExitRequest } from '../models/ExitRequest';
import { ExitResponse } from '../models/ExitResponse';

@Injectable({
  providedIn: 'root'
})
export class ExitService {

  private apiUrl = environment.ticketSystemApiUrl;
  constructor(private http: HttpClient) { }

  exit(exitRequest: ExitRequest): Observable<ExitResponse> {
    return this.http.post<ExitResponse>(this.apiUrl + 'exit', exitRequest);
  }
}

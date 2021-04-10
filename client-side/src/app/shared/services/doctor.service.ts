import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private baseUrl = environment.api;

  constructor(private http: HttpClient) { }

  public patientsAppointment(): Observable<User[]> {
    const url = `${this.baseUrl}/doctor/patients/appointment`;
    return this.http.get<User[]>(url);
  }
}

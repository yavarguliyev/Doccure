import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  private baseUrl = environment.api;
  private memberCache = new Map();

  constructor(private http: HttpClient) {}

  public patientsAppointment(): Observable<User[]> {
    const url = `${this.baseUrl}/doctor/patients/appointment`;
    return this.http.get<User[]>(url);
  }

  public patientBySlug(slug: any): Observable<User> {
    const patient = [...this.memberCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((x: User) => x.slug === slug);

    if (patient) {
      return of(patient);
    }

    const url = `${this.baseUrl}/doctor/patient/${slug}`;
    return this.http.get<User>(url);
  }
}

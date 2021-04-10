import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { DoctorSocialMedia } from '../models/doctor-social-media-url';
import { UpdatePassword } from '../models/update-user-password';
import { User } from '../models/user';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  private baseUrl = environment.api;
  private memberCache = new Map();

  constructor(private http: HttpClient, private authService: AuthService) {}

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

  public getDoctorSocialMediaUrl(): Observable<DoctorSocialMedia> {
    const url = `${this.baseUrl}/doctor/social-media-url`;
    return this.http.get<DoctorSocialMedia>(url);
  }

  public updateDoctorSocialMediaUrl(model: DoctorSocialMedia): Observable<any> {
    const url = `${this.baseUrl}/doctor/update-social-media-url`;
    return this.http.put(url, model);
  }

  public updateDoctorPassword(model: UpdatePassword): Observable<any> {
    const url = `${this.baseUrl}/doctor/update-password`;
    return this.http.put(url, model).pipe(
      map((response: any) => {
        const user = response.response;
        if (user) {
          this.authService.setCurrentUser(user);
          return response.message;
        }
      })
    );
  }
}

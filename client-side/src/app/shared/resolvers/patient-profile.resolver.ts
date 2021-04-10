import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { DoctorService } from '../services/doctor.service';

@Injectable({
  providedIn: 'root',
})
export class PatientProfileResolver implements Resolve<User> {
  constructor(private doctorService: DoctorService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.doctorService.patientBySlug(route.paramMap.get('slug'));
  }
}

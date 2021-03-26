import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Term } from '../models/term';
import { Privacy } from '../models/privacy';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  constructor(private http: HttpClient) {}

  public getTermsAndCondition() {
    return this.http.get<Term>(`${environment.api}/admin_settings/terms`);
  }

  public getPrivaciesAndPolicies(): Observable<Privacy> {
    return this.http.get<Privacy>(`${environment.api}/admin_settings/privacies`);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Term } from '../models/term';
import { Privacy } from '../models/privacy';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { timeout } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  constructor(private http: HttpClient) {}

  public getTerm(): Observable<Term> {
    return this.http.get<Term>(`${environment.api}/admin_settings/terms`);
  }

  public getPrivacy(): Observable<Privacy>
  {
    const url = `${environment.api}/admin_settings/privacies`;
    return this.http.get<Privacy>(url);
  }
}

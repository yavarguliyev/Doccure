import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Term } from '../models/term';
import { Privacy } from '../models/privacy';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { SocialMedia } from '../models/social-media-settings';
import { MainPageSettings } from '../models/main-page-settings';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  private baseUrl = environment.api;

  constructor(private http: HttpClient) {}

  public getTerm(): Observable<Term> {
    return this.http.get<Term>(`${this.baseUrl}/admin_settings/terms`);
  }

  public getPrivacy(): Observable<Privacy> {
    const url = `${this.baseUrl}/admin_settings/privacies`;
    return this.http.get<Privacy>(url);
  }

  public getMainPageSettings(): Observable<MainPageSettings> {
    const url = `${this.baseUrl}/admin_settings/settings`;
    return this.http.get<MainPageSettings>(url);
  }

  public getSocialMedia(): Observable<SocialMedia[]> {
    const url = `${this.baseUrl}/admin_settings/social-media`;
    return this.http.get<SocialMedia[]>(url);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Currency } from '../models/currency.model';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  constructor(private http: HttpClient) { }

  get(id): Observable<Currency> {
    return this.http.get<Currency>(`${environment.api_url}${id}`);
  }
}

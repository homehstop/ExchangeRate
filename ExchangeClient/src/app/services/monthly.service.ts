import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Currency } from '../models/currency.model';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Monthly } from '../models/monthly.model';
import { isNull } from 'util';

@Injectable({
  providedIn: 'root'
})
export class MonthlyService {
  constructor(private http: HttpClient) { }

  get(id): Observable<Monthly> {
    if (isNull(id)) {
      console.error('Monthly id is null');
      return null;
    }

    return this.http.get<Monthly>(`${environment.api_url}monthly/${id}`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { Monthly } from '../models/monthly.model';
import { isNull, isUndefined } from 'util';

@Injectable({
  providedIn: 'root'
})
export class MonthlyService {
  constructor(private http: HttpClient) {
  }

  get(id: number): Observable<Array<Monthly>> {
    if (isNull(id)) {
      console.error('Id is null');
      return null;
    }
    return this.http.get<Array<Monthly>>(`${environment.api_url}monthly/${id}`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  baseUrl: string = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {}

  sendTransaction(message: string): Observable<any> {
    const params = new HttpParams().set('message', message);
    return this.http.get(this.baseUrl + '/transaction', { params });
  }
}

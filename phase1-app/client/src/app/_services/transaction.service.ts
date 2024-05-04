import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  baseUrl: string = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {}

  sendTransaction(message: string) {
    const params = new HttpParams().set('message', message);

    this.http.get(this.baseUrl + '/transaction', { params }).subscribe({
      next: (response) => {
        const res = response as Response;

        if (res.statusCode == 200) {
          console.log(res);
          // form.reset();
        }
      },
      error: (error) => console.log(error.message),
    });
  }
}

interface Response {
  id: number;
  message: string;
  date: Date;
  isSuccess: boolean;
  statusCode: number;
  text: string;
}

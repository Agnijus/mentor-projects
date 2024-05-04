import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  baseUrl: string = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {}

  sendTransaction(message: string) {
    const transaction: Transaction = {
      message: message,
    };

    this.http.post(this.baseUrl + '/transaction', transaction).subscribe({
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

interface Transaction {
  message: string;
}

interface Response {
  isSuccess: boolean;
  statusCode: number;
  text: string;
}

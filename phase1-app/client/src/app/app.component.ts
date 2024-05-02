import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title: string = 'Angular-Phase1';
  //transaction :any;
  //alerts: Alert[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  sendTransaction(form: NgForm) {
    if (form.valid) {
      const transaction: Transaction = {
        message: form.value.message,
      };

      this.http
        .post('http://localhost:5000/api/transaction', transaction)
        .subscribe({
          next: (response) => {
            const res = response as Response;

            if (res.statusCode == 200) {
              console.log(res);
              form.reset();
            }
          },
          error: (error) => console.log(error.message),
        });
    }
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

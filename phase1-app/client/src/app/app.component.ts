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
  transaction: any;

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
          next: (response) => console.log(response),
          error: (error) => console.log(error),
        });
    }
  }
}

interface Transaction {
  message: string;
}

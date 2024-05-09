import { Component } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { TransactionService } from '../_services/transaction.service';
import { CommonModule } from '@angular/common';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatButtonModule,
    CommonModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
})
export class FormComponent {
  inputText: string = '';
  notification: string | null = null;
  response: Response | null = null;
  isLoading: boolean = false;

  constructor(private transactionService: TransactionService) {}

  onSubmit() {
    if (this.inputText) {
      this.response = null;
      this.isLoading = true;

      this.transactionService.sendTransaction(this.inputText).subscribe({
        next: (res: Response) => {
          console.log(res);

          this.isLoading = false;
          this.resetForm();
          this.response = res;
          this.displayNotification('The message has been saved');
        },
        error: (error) => {
          console.log(error);

          this.isLoading = false;
          this.displayNotification('Failed to save the message');
        },
      });
    }
  }
  resetForm(): void {
    this.inputText = '';
  }
  displayNotification(notification: string): void {
    this.notification = notification;
    setTimeout(() => (this.notification = null), 3000);
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

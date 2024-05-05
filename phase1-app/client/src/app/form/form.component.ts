import { Component } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { TransactionService } from '../_services/transaction.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatButtonModule,
    CommonModule,
  ],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
})
export class FormComponent {
  inputText: string = '';
  notification: string | null = null;
  response: Response | null = null;

  constructor(private transactionService: TransactionService) {}

  onSubmit() {
    if (this.inputText) {
      this.transactionService.sendTransaction(this.inputText).subscribe({
        next: (res: Response) => {
          console.log(res);
          this.response = res;
          this.notification = 'The message has been saved';
          setTimeout(() => (this.notification = null), 3000);
          this.resetForm();
        },
        error: (error) => {
          console.log(error);
          this.notification = 'Failed to save the message';
          setTimeout(() => (this.notification = null), 3000);
        },
      });
    }
  }
  resetForm(): void {
    this.inputText = '';
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

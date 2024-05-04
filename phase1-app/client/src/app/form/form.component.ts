import { Component } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { TransactionService } from '../_services/transaction.service';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [MatInputModule, MatFormFieldModule, FormsModule, MatButtonModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
})
export class FormComponent {
  constructor(private transactionService: TransactionService) {}

  onSubmit(message: string) {
    if (message) {
      this.transactionService.sendTransaction(message);
    }
  }
}

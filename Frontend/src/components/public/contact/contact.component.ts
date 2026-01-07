import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactRequest } from '../../../models/contact/contact-request';
import { ContactService } from '../../../services/contact-service';

@Component({
  selector: 'app-contact',
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {
  private readonly contactService = inject(ContactService);

  model: ContactRequest = {
    name: '',
    email: '',
    message: ''
  };

  isSending = false;
  successMessage = '';
  errorMessage = '';

  onSubmit(): void {
    this.successMessage = '';
    this.errorMessage = '';

    if (!this.model.email || !this.model.message) {
      this.errorMessage = 'Моля, въведете имейл и съобщение.';
      return;
    }

    this.isSending = true;

    this.contactService.sendContact(this.model).subscribe({
      next: () => {
        this.successMessage = 'Съобщението беше изпратено успешно.';
        this.model = { name: '', email: '', message: '' };
        this.isSending = false;
      },
      error: () => {
        this.errorMessage = 'Възникна грешка при изпращане на съобщението.';
        this.isSending = false;
      }
    });
  }
}
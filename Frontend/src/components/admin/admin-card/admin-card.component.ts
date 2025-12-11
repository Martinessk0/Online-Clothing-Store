import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-admin-card',
  imports: [CommonModule, RouterLink],
  templateUrl: './admin-card.component.html',
  styleUrl: './admin-card.component.scss'
})
export class AdminCardComponent {
  @Input() title?: string;
  @Input() description?: string;

  @Input() stat?: string | number | null;
  @Input() statHint?: string;

  @Input() link?: string | any[];
  @Input() linkLabel?: string;

  @Input() badge?: string;
}

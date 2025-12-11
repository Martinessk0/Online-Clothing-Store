import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AdminCardComponent } from '../admin-card/admin-card.component';

@Component({
  selector: 'app-home-page',
  imports: [CommonModule,RouterLink,AdminCardComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {

}

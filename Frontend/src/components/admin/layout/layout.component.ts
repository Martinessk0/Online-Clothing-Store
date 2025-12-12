import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth-service';
import { NgIf } from '@angular/common';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { NavigationComponent } from '../navigation/navigation.component';

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet,NavigationComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {
constructor(public authService: AuthService) {}
 get year(): number {
    return new Date().getFullYear();
  }
}

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CartAddedDialogComponent } from './components/shared/cart-added-dialog/cart-added-dialog.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CartAddedDialogComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
}

import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CartAddedDialogComponent } from './components/shared/cart-added-dialog/cart-added-dialog.component';
import { LanguageService } from './services/language.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CartAddedDialogComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  constructor(private language: LanguageService) {}

  ngOnInit(): void {
    // Задава default (ако LanguageService пази/чете localStorage, ще си вземе избора)
    this.language.setLanguage('bg');
  }
}

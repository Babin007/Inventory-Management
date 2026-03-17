import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,NavbarComponent,FooterComponent,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'inventory-app';
  showNavbar = true;

  constructor(private router: Router) {
    const hideOn = ['/login', '/signup', '/checkout'];
    router.events.subscribe(() => {
      this.showNavbar = !hideOn.includes(router.url);
    });
  }
}


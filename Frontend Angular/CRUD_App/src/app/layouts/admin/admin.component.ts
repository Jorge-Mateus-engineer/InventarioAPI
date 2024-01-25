import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent {
  constructor(private router: Router) {}

  home(): void {
    this.router.navigate(['admin', 'home']);
  }

  profile(): void {
    this.router.navigate(['admin', 'profile']);
  }

  logout(): void {
    this.router.navigate(['auth', 'login']);
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [MatButtonModule],
})
export class LoginComponent {
  constructor(private router: Router) {}

  home(): void {
    this.router.navigate(['admin', 'home']);
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
})
export class AuthenticationComponent {
  navLinks: any[];
  activeLinkIndex = -1;

  constructor(private router: Router) {
    this.navLinks = [
      {
        label: 'Log In',
        link: '/auth/login',
        icon: 'account_circle',
      },
      {
        label: 'Register',
        link: '/auth/register',
        icon: 'note_add',
      },
    ];
  }
}

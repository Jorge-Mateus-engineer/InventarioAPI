import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
})
export class AuthenticationComponent implements OnInit {
  navLinks: any[];
  activeLinkIndex = -1;

  constructor(
    private router: Router,
    private _authService: AuthenticationService
  ) {
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
  ngOnInit(): void {
    const currentToken = localStorage.getItem('token');
    if (currentToken) {
      this._authService.verifyToken(currentToken).subscribe(
        (res) => {
          if (res.tokenValidity === 'Valid Token') {
            this.router.navigateByUrl('/admin');
          } else {
            console.log('Token is no longer valid');
            // Handle the case where the token is no longer valid
          }
        },
        (error) => {
          console.error('Error validating token', error);
          // Handle the error case
        }
      );
    }
  }
}

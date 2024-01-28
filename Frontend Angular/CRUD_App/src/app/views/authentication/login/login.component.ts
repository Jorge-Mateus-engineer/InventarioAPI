import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from 'src/app/services/shared/authentication.service';
import { AuthenticationModel } from 'src/app/models/Authentication/authentication.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  userCredentials: AuthenticationModel = new AuthenticationModel();
  constructor(
    private router: Router,
    private _authenticationService: AuthenticationService
  ) {}

  home(): void {
    this.router.navigate(['admin', 'home']);
  }

  onSubmit() {
    this._authenticationService
      .loginToAPI(this.userCredentials)
      .subscribe((val) => console.log(val));
  }
}

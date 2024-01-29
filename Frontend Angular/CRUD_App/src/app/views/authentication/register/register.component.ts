import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ClienteModel } from 'src/app/models/Clientes/cliente.model';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  newUser: ClienteModel = new ClienteModel();
  passwordConfirm: String = '';

  constructor(private _authenticationService: AuthenticationService) {}

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  onSubmit(): void {
    if (this.passwordConfirm == this.newUser.contrasena) {
      this._authenticationService
        .createAccount(this.newUser)
        .subscribe((val) => console.log(val));
    } else {
      alert('Las contraseñas no coinciden');
    }
  }
}

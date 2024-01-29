import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { AdminComponent } from './layouts/admin/admin.component';
import { AuthenticationComponent } from './layouts/authentication/authentication.component';
import { LoginComponent } from './views/authentication/login/login.component';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { LoginModule } from './views/authentication/login/login.module';
import { HttpClientModule } from '@angular/common/http';
import { ReadComponent } from './views/shared/read/read.component';
import { UpdateComponent } from './views/shared/update/update.component';
import { DeleteComponent } from './views/shared/delete/delete.component';
import { RegisterComponent } from './views/authentication/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    AuthenticationComponent,
    LoginComponent,
    RegisterComponent,
    ReadComponent,
    DeleteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatSidenavModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatButtonModule,
    LoginModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

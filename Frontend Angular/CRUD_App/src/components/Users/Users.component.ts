import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatDrawer } from '@angular/material/sidenav';

@Component({
  selector: 'app-Users',
  templateUrl: './Users.component.html',
  styleUrls: ['./Users.component.css'],
  standalone: true,
  imports: [MatButtonModule, MatSidenavModule],
})
export class UsersComponent implements OnInit {
  showFiller = false;
  constructor() {}

  ngOnInit() {}
}

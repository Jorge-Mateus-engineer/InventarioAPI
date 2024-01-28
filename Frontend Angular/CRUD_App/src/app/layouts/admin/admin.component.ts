import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  navLinks: any[];
  activeLinkIndex = -1;

  constructor(private router: Router) {
    this.navLinks = [
      {
        label: 'Bodegas',
        link: '/admin/home',
        icon: 'account_balance',
      },
      {
        label: 'Categorias',
        link: '/admin/table',
        icon: 'shop',
      },
      {
        label: 'Clientes',
        link: '/auth/login',
        icon: 'face',
      },
      {
        label: 'Compras',
        link: '/admin/home',
        icon: 'shopping_cart',
      },
      {
        label: 'Detalle Compras',
        link: '/admin/home',
        icon: 'search',
      },
      {
        label: 'Productos',
        link: '/admin/home',
        icon: 'shopping_cart',
      },
      {
        label: 'Disponibilidad Productos',
        link: '/admin/home',
        icon: 'ballot',
      },
      {
        label: 'Proveedores',
        link: '/admin/home',
        icon: 'perm_identity',
      },
    ];
  }

  ngOnInit(): void {
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(
        this.navLinks.find((tab) => tab.link === '.' + this.router.url)
      );
    });
  }
}

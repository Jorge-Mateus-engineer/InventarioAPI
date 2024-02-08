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
        link: '/admin/bodegas',
        icon: 'account_balance',
      },
      {
        label: 'Categorias',
        link: '/admin/categorias',
        icon: 'shop',
      },
      {
        label: 'Clientes',
        link: '/admin/clientes',
        icon: 'face',
      },
      {
        label: 'Compras',
        link: '/admin/compras',
        icon: 'shopping_cart',
      },
      {
        label: 'Detalle Compras',
        link: '/admin/detalleCompras',
        icon: 'search',
      },
      {
        label: 'Productos',
        link: '/admin/productos',
        icon: 'shopping_cart',
      },
      {
        label: 'Disponibilidad Productos',
        link: '/admin/disponibilidad',
        icon: 'ballot',
      },
      {
        label: 'Proveedores',
        link: '/admin/proveedores',
        icon: 'perm_identity',
      },
    ];
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['auth']);
  }

  ngOnInit(): void {
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(
        this.navLinks.find((tab) => tab.link === '.' + this.router.url)
      );
    });
  }
}

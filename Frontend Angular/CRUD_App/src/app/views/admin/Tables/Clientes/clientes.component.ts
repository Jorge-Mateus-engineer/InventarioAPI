import { Component, OnInit } from '@angular/core';
import { ClienteModel } from 'src/app/models/Clientes/cliente.model';
import { ClientesService } from 'src/app/services/Clientes/clientes.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss'],
})
export class ClientesComponent implements OnInit {
  models: Array<ClienteModel> = [];
  headersAndProperties: any[];

  constructor(private clienteService: ClientesService) {
    this.headersAndProperties = [
      { header: 'Id Cliente', property: 'id_cliente' },
      { header: 'Primer Nombre', property: 'primer_nombre' },
      { header: 'Segundo Nombre', property: 'segundo_nombre' },
      { header: 'Primer Apellido', property: 'primer_apellido' },
      { header: 'Segundo Apellido', property: 'segundo_apellido' },
      { header: 'Correo', property: 'correo' },
      { header: 'Telefono', property: 'telefono' },
    ];
  }

  list(): void {
    this.clienteService.listClients().subscribe(
      (clients) => {
        this.models = clients;
      },
      (error) => {
        console.error('Error fetching clients', error);
      }
    );
  }

  ngOnInit(): void {
    this.list();
  }
}

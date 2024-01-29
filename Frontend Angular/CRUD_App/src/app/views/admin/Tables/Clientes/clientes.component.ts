import { Component, OnInit } from '@angular/core';
import { ClienteModel } from 'src/app/models/Clientes/cliente.model';
import { ClientesService } from 'src/app/services/Clientes/clientes.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss'],
})
export class ClientesComponent implements OnInit {
  /**
   *List of models to send to the generic CRUD components
   *
   * @type {Array<ClienteModel>}
   * @memberof ClientesComponent
   */
  models: Array<ClienteModel> = [];
  /**
   *Model of the client that will be edited in the database
   *
   * @type {ClienteModel}
   * @memberof ClientesComponent
   */
  clientToEdit: ClienteModel = new ClienteModel();
  /**
   *Model of the client that will be deleted on the database
   *
   * @type {ClienteModel}
   * @memberof ClientesComponent
   */
  clientToDelete: ClienteModel = new ClienteModel();
  /**
   * Array of objects of the schema { header: 'string' , property: 'string'}
   * used to populate column tittles/form labels and acces the model's preperty using array notation model[property]
   * @type {any[]}
   * @memberof ClientesComponent
   */
  headersAndProperties: any[] = [
    { header: 'Id Cliente', property: 'id_cliente' },
    { header: 'Primer Nombre', property: 'primer_nombre' },
    { header: 'Segundo Nombre', property: 'segundo_nombre' },
    { header: 'Primer Apellido', property: 'primer_apellido' },
    { header: 'Segundo Apellido', property: 'segundo_apellido' },
    { header: 'Correo', property: 'correo' },
    { header: 'Telefono', property: 'telefono' },
  ];

  constructor(private clienteService: ClientesService) {}

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

  saveEditedClient(confirmation: boolean): void {
    if (confirmation) {
      this.clienteService
        .updateClient(this.clientToEdit)
        .subscribe((val) => console.log(val));
    }
  }

  ngOnInit(): void {
    this.list();
  }
}

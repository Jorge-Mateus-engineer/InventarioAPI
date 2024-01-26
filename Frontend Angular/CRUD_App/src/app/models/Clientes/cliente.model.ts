export class ClienteModel {
  id_cliente: Number;
  primer_nombre: String;
  segundo_mobre: String;
  primer_apellido: String;
  segundo_apellido: String;
  correo: String;
  telefono: String;

  constructor() {
    this.id_cliente = 0;
    this.primer_nombre = '';
    this.segundo_mobre = '';
    this.primer_apellido = '';
    this.segundo_apellido = '';
    this.correo = '';
    this.telefono = '';
  }
}

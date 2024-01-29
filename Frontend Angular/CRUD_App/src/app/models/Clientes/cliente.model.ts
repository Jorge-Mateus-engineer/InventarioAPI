export class ClienteModel {
  id_cliente: Number;
  primer_nombre: String;
  segundo_nombre: String;
  primer_apellido: String;
  segundo_apellido: String;
  correo: String;
  telefono: String;
  contrasena: String;

  constructor() {
    this.id_cliente = 0;
    this.primer_nombre = '';
    this.segundo_nombre = '';
    this.primer_apellido = '';
    this.segundo_apellido = '';
    this.correo = '';
    this.contrasena = '';
    this.telefono = '';
  }
}

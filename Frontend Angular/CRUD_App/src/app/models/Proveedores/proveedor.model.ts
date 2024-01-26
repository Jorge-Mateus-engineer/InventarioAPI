export class ProveedorModel {
  id_proveedor: Number;
  nombre_proveedor: String;
  nombre_empresa: String;
  email: String;
  ciudad: String;
  direccion: String;

  constructor() {
    this.id_proveedor = 0;
    this.nombre_proveedor = '';
    this.nombre_empresa = '';
    this.email = '';
    this.ciudad = '';
    this.direccion = '';
  }
}

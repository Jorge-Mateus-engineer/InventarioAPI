export class ProductoModel {
  id_producto: Number;
  nombre: String;
  descricpion: String;
  id_categoria: Number;
  unidad: String;
  precio_unitario: Number;
  id_proveedor: Number;

  constructor() {
    this.id_producto = 0;
    this.nombre = '';
    this.descricpion = '';
    this.id_categoria = 0;
    this.unidad = '';
    this.precio_unitario = 0;
    this.id_proveedor = 0;
  }
}

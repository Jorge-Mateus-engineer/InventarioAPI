export class DetalleCompraModel {
  id_detalle_compra: Number;
  id_producto: Number;
  cantidad: Number;
  total_detalle: Number;
  id_compra: Number;

  constructor() {
    this.id_detalle_compra = 0;
    this.id_producto = 0;
    this.cantidad = 0;
    this.total_detalle = 0;
    this.id_compra = 0;
  }
}

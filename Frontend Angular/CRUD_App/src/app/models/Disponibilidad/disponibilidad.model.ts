export class DisponibilidadModel {
  id_producto: Number;
  id_bodega: Number;
  unidad: String;
  unidades_disponibles: Number;

  constructor() {
    this.id_producto = 0;
    this.id_bodega = 0;
    this.unidad = '';
    this.unidades_disponibles = 0;
  }
}

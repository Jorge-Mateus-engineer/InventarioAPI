export class BodegaModel {
  id_bodega: Number;
  nombre: String;
  hora_de_apertura: String;
  hora_de_cierre: String;
  direccion: String;

  constructor() {
    this.id_bodega = 0;
    this.nombre = '';
    this.hora_de_apertura = '09:00:00';
    this.hora_de_cierre = '18:00:00';
    this.direccion = '';
  }
}

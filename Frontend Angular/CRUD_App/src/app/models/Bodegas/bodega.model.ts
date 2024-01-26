export class BodegaModel {
  id_bodega: Number;
  nombre: String;
  hora_de_apertura: Date;
  hora_de_cierre: Date;
  direccion: string;

  constructor() {
    this.id_bodega = 0;
    this.nombre = '';
    this.hora_de_apertura = new Date();
    this.hora_de_cierre = new Date();
    this.direccion = ';';
  }
}

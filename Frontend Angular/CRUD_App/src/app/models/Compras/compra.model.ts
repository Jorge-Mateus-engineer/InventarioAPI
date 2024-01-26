export class CompraModel {
  id_compra: Number;
  id_cliente: Number;
  valor_total: Number;
  hora_de_compra: Date;

  constructor() {
    this.id_compra = 0;
    this.id_cliente = 0;
    this.valor_total = 0;
    this.hora_de_compra = new Date();
  }
}

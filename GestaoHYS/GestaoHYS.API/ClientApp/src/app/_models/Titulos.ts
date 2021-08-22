import { DateTime } from "luxon";
import { Invoice } from "./Invoice";

export class Titulos{
    idTitulos: number;
    dataCadastro: DateTime;
    dataVencimento: DateTime;
    valorTotal: number;
    salesInvoiceId: number;
    salesInvoice: Invoice;
    referenciaSalesInvoice: string;
    statusTitulo: number;
}
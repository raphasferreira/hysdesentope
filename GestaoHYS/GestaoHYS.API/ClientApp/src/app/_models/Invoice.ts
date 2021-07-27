import { DateTime } from "luxon";
import { DocumentLines } from "./DocumentLines";

export class Invoice{
    documentType: string;
    documentTypeDescription:string;
    documentTypeId:string;
    serie: string;
    serieDescription: string;
    serieId: string;
    seriesNumber: number;
    company: string;
    paymentTerm: string;
    paymentTermDescription: string;
    paymentTermId: string;
    paymentMethod: string;
    paymentMethodDescription: string;
    paymentMethodId: string;
    currency: string;
    documentDate: DateTime;
    postingDate: DateTime;
    dueDate: DateTime;
    buyerCustomerPartyId: string;
    buyerCustomerParty: string;
    buyerCustomerPartyName: string;
    accountingPartyName: string;
    accountingPartyTaxId: string;
    exchangeRate: number;
    discount: number;
    loadingCountry: string;
    unloadingCountry: string
    isExternal: boolean;
    isManual: boolean;
    isSimpleInvoice: boolean;
    isWsCommunicable: boolean;
    deliveryTerm: string;
    documentLines: Array<DocumentLines>;
    errosIntegracao: string;
    naturalKey:  string;
    note: string;
    isIntegration: boolean;
    constructor(){
    }
}
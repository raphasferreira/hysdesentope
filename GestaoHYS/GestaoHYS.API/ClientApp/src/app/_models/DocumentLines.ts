import { DateTime } from "luxon";
import { UnitPrice } from "./UnitPrice";

export class DocumentLines{
    id: string;
    idBaseLocal: number;
    salesItem: string;
    description: string;
    quantity: number;
    unitPrice: UnitPrice;
    unit: string;
    itemTaxSchema: string;
    deliveryDate: DateTime;
    warehouse:string;
    itemWithholdingTaxSchema: string;
    
    constructor(){
        this.unitPrice = new UnitPrice();
    }
}
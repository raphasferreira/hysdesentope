import { PriceAmount } from "./PriceAmount";

export class PriceListLine{
    priceList: string;
    priceAmount: PriceAmount;
    salesItemId: string;
    unit: string;
    unitId: string;
    unitDescription:  string;

    constructor(){
      
    }
}
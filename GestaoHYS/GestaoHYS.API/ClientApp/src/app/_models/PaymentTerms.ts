export class PaymentTerms{
    id: string;
    description: string;
    paymentTermKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.paymentTermKey = key;
    }
}
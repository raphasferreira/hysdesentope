export class PaymentTerms{
    id: string;
    description: string;
    paymentTermsKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.paymentTermsKey = key;
    }
}
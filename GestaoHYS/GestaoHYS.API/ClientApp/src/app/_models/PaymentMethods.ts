export class PaymentMethods{
    id: string;
    description: string;
    paymentMethodsKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.paymentMethodsKey = key;
    }
}
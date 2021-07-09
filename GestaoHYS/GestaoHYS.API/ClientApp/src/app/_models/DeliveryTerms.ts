export class DeliveryTerms{
    id: string;
    description: string;
    deliveryTermKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.deliveryTermKey = key;
    }
}
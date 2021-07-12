export class PriceLists{
    id: string;
    description: string;
    priceListKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.priceListKey = key;
    }
}
export class Currencies{
    id: string;
    description: string;
    currencyKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.currencyKey = key;
    }
}
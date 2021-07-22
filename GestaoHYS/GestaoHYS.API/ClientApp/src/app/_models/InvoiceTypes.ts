export class InvoiceTypes{
    id: string;
    description: string;
    typeKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.typeKey = key;
    }
}
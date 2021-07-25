export class ItemTaxSchemas{
    id: string;
    description: string;
    taxCodeItemGroupKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.taxCodeItemGroupKey = key;
    }
}
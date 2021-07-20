export class ItemTaxSchemas{
    id: string;
    description: string;
    taxCodeGroupKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.taxCodeGroupKey = key;
    }
}
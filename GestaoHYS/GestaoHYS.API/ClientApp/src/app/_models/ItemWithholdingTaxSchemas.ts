export class ItemWithholdingTaxSchemas{
    id: string;
    description: string;
    itemWithholdingTaxGroupKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.itemWithholdingTaxGroupKey = key;
    }
}
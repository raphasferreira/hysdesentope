export class ItemWithholdingTaxSchemas{
    id: string;
    description: string;
    itemWithholdingTaxSchemaKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.itemWithholdingTaxSchemaKey = key;
    }
}
export class PartyWithholdingTaxSchemas{
    id: string;
    description: string;
    partyWithholdingTaxSchemaKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.partyWithholdingTaxSchemaKey = key;
    }
}
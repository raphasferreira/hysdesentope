export class CustomerGroups{
    id: string;
    description: string;
    customerGroupKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.customerGroupKey = key;
    }
}
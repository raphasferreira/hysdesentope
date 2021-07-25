export class Warehouses{
    id: string;
    warehouseKey: string;
    description: string;

    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.warehouseKey = key;
    }
  
}
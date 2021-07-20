export class BaseUnit{
    id: string;
    unitKey: string;
    description: string;

    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.unitKey = key;
    }
  
}
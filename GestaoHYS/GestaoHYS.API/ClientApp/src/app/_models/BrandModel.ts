export class BrandModel{
    id: string;
    modelKey: string;
    description: string;

    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.modelKey = key;
    }
  
}
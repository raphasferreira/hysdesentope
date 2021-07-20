export class BrandModel{
    id: string;
    brandModelKey: string;
    description: string;

    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.brandModelKey = key;
    }
  
}
export class Brand{
    id: string;
    brandKey: string;
    description: string;

    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.brandKey = key;
    }
  
}
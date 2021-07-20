export class Assortments{
    id: string;
    assortmentKey: string;
    description: string;

    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.assortmentKey = key;
    }
  
}
export class Series{
    id: string;
    description: string;
    serieKey: string;
  
    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.serieKey = key;
    }
}
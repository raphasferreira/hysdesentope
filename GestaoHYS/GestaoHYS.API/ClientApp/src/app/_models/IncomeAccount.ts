export class IncomeAccount{
    id: string;
    incomeAccountKey: string;
    description: string;

    constructor(id : string, name: string, key: string){
        this.id = id;
        this.description = name;
        this.incomeAccountKey = key;
    }
  
}
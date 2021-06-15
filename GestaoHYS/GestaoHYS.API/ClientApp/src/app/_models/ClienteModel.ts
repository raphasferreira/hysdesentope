import { Country } from "@angular-material-extensions/select-country";

export class ClienteModel{
    id: number;
    nome: string;
    nif: string;
    endereco: string;
    cidade: string;
    pais: Country;
    moeda: string;
    usuario: string;
    senha: string;
    email: string;
    celular: string;  
}
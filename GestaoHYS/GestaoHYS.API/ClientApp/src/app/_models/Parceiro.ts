import { Country } from "@angular-material-extensions/select-country";

export class Parceiro{
    id: number;
    nome: string;
    nif: string;
    dtNascimento: string;
    endereco: string;
    email: string;
    telefone: string;
    parceiroPais: Country;
    parceiroPaisId: number;
    dsServico: string;
}

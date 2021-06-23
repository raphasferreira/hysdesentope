import { PerfilUsuario } from "./PerfilUsuario";

export class Usuario{
    id: number;
    nome: string;
    email: string;
    ativo: boolean;
    perfilId: number;
    perfil: PerfilUsuario;
    senha: string;
    senhaConfirm: string;

    constructor(usuario){
        this.id = usuario.id;
        this.nome = usuario.nome;
        this.email = usuario.email;
        this.ativo = usuario.ativo;
        this.perfilId = usuario.perfilId;
        this.senha = usuario.senha;
        this.senhaConfirm = usuario.senhaConfirm;
    }


}
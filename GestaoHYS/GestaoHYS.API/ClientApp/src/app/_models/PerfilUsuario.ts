export class PerfilUsuario{
    id: number;
    descricao: string;

    constructor(perfil){
        this.id = perfil.id;
        this.descricao = perfil.descricao;
    }
}
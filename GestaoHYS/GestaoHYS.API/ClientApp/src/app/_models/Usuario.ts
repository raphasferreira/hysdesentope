import { PerfilUsuario } from "./PerfilUsuario";

export class Usuario{
    id: number;
    nome: string;
    email: string;
    ativo: boolean;
    perfilId: number;
    perfil: PerfilUsuario;
}
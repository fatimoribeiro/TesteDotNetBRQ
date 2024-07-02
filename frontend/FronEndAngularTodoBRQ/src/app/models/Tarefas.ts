export interface Tarefa {
    id? : number;
    titulo: string;
    descricao: string;
    status: string;
    dataDeCriacao? : string;
    dataDeAlteracao? : string;
}
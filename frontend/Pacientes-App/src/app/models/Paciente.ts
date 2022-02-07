import { Telefone } from "./Telefone";

export interface Paciente {
  id:number;
  nome:string;
  cpf:string;
  rg:string;
  cns:string;
  dataNascimento?: Date;
  sexo:string;
  nomeMae:string;
  endereco:string;
  bairro:string;
  cep:number;
  uf:string;
  cidade:string;
  telefones:Telefone[];
}

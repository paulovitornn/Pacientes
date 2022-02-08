import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Paciente } from '../models/Paciente';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  constructor(private http: HttpClient) { }

  baseURL = "https://localhost:5001/Paciente/"

  public getAllPacientes(): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(`${this.baseURL}getAllPacientes`);
  }

  public getPacienteById(id:number): Observable<Paciente>{
    return this.http.get<Paciente>(`${this.baseURL}getPacienteById/${id}`);
  }

  public getPacientesByNome(nome:string): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(`${this.baseURL}getPacientesByNome/${nome}`);
  }

  public getPacientesByCPF(cpf:string): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(`${this.baseURL}getPacientesByCPF/${cpf}`);
  }

  public postNovoPaciente(paciente:Paciente) :Observable<Paciente> {
    return this.http.post<Paciente>(`${this.baseURL}novoPaciente`,paciente);
  }

  public putAtualizarCadastro(id:number, paciente:Paciente): Observable<Paciente>{
    return this.http.put<Paciente>(`${this.baseURL}atualizarCadastroPaciente/${id}`, paciente);
  }

  public deleteCadastro(id:number): Observable<string>{
    return this.http.delete<string>(`${this.baseURL}excluirCadastro/${id}`);
  }
}

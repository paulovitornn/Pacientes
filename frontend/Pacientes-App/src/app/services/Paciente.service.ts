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

  getAllPacientes(): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(`${this.baseURL}getAllPacientes`);
  }

  getPacienteById(id:number): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(`${this.baseURL}getPacienteById/${id}`);
  }

  getPacientesByNome(nome:string): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(`${this.baseURL}getPacientesByNome/${nome}`);
  }

  getPacientesByCPF(cpf:string): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(`${this.baseURL}getPacientesByCPF/${cpf}`);
  }

}

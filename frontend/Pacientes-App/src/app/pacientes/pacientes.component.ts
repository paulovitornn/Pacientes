import { Component, OnInit, TemplateRef } from '@angular/core';
import { Paciente } from '../models/Paciente';
import { PacienteService } from '../services/Paciente.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-pacientes',
  templateUrl: './pacientes.component.html',
  styleUrls: ['./pacientes.component.scss']
})
export class PacientesComponent implements OnInit {

  constructor(
    private pService : PacienteService,
    private modalService: BsModalService,
  ) { }

  modalRef?: BsModalRef;
  message?: string;
  public radioModelSex = 'Masculino';

  public testeButton(){
    console.log(this.radioModelSex);
  }


  public config = {
    backdrop: true,
    ignoreBackdropClick: true
  };

  public pacienteEdit: any;
  public pacientes:Paciente[] = [];
  public pacientesFitrados:Paciente[] = [];
  private _filtroCadastros: string = '';

  public get filtroCadastros(): string {
    return this._filtroCadastros;
  }

  public set filtroCadastros(value: string) {
    this._filtroCadastros = value;
    //Aqui faz a filtragem apenas no array já carregado
    //this.pacientesFitrados = this._filtroCadastros ? this.filtrarPacientes(this._filtroCadastros): this.pacientes;

    if(this.isNumber(value) && value.length>2){
      this.getPacientesByCPF(value);
    } else if(this.isNumber(value)==false && value.length>2) {
      this.getPacientesByNome(value);
    } else if (value.length==0){
      this.getAllPacientes();
    }
  }

  private getPacientesByNome(nome:string){
    this.pService.getPacientesByNome(nome).subscribe({
      next: (p:Paciente[]) => {
        this.pacientes = p;
        this.pacientesFitrados = p;
      },
      error:(error:any) =>{
        alert('Erro');
      },
      complete:()=>{
      }
    })
  }

  private getPacientesByCPF(cpf:string){
    this.pService.getPacientesByCPF(cpf).subscribe({
      next: (p:Paciente[]) => {
        this.pacientes = p;
        this.pacientesFitrados = p;
      },
      error:(error:any) =>{
        alert('Erro');
      },
      complete:()=>{
      }
    })
  }

  public eventHandler(event: KeyboardEvent) {
    //console.log('Key pressed is: ', event.code);
    /* usar essa função para otimizar a busca, para nao gerar uma nova requisicao a cada letra; */
 }

  private isNumber(str:any) {
    return !isNaN(str)
  }

  private getAllPacientes(){
    this.pService.getAllPacientes().subscribe({
      next: (p:Paciente[]) => {
        this.pacientes = p;
        this.pacientesFitrados = p;
      },
      error:(error:any) =>{
        alert('Erro');
      },
      complete:()=>{
      }

    })
  }

  filtrarPacientes(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.pacientesFitrados.filter(
      (paciente:any) =>
        paciente.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        paciente.cpf.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  openModalExcluirPaciente(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  /* openModalCadastroPaciente(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  } */

  confirmExcluirCadastro(): void {
    this.modalRef?.hide();
  }

  declineExcluirCadastro(): void {
    this.modalRef?.hide();
  }

  public editarCadastroPaciente(paciente:Paciente, template: TemplateRef<any>){
    console.log(this.pacienteEdit);
    this.pacienteEdit = paciente;
    this.openModalCadastroPaciente(template)
    console.log(this.pacienteEdit);
  }

  openModalCadastroPaciente(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template, this.config);
  }

  ngOnInit() {
    this.getAllPacientes();
  }

}

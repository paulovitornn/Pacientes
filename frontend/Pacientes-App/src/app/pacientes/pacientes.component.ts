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

  public config = {
    backdrop: true,
    ignoreBackdropClick: true
  };

  pacienteEdit = { } as Paciente;
  public pacientes:Paciente[] = [];
  public pacientesFitrados:Paciente[] = [];
  private _filtroCadastros: string = '';
  private idPacienteExcluir: number = 0;

  public get filtroCadastros(): string {
    return this._filtroCadastros;
  }

  public set filtroCadastros(value: string) {
    this._filtroCadastros = value;
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

  private limparPacienteEdit(){
    this.pacienteEdit = {
      id : 0,
      nome:'',
      cpf:'',
      rg:'',
      cns:'',
      dataNascimento: undefined,
      sexo:'',
      nomeMae:'',
      endereco:'',
      bairro:'',
      cep:0,
      uf:'',
      cidade:'',
      telefones:[]
    };
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

  public getDateNasc(dataNasc:any){
    var currentDate = new Date(dataNasc);
    var day = currentDate.getDate();
    var month = (currentDate.getMonth()+1);
    var year = currentDate.getFullYear();
    var dia;
    var mes;
    if(day<10){
      dia = "0"+day;
    } else {
      dia = day;
    }
    if(month<10){
      mes = "0"+month;
    } else {
      mes = month;
    }
    dataNasc = `${year}-${mes}-${dia}`;
    return dataNasc;
  }

  filtrarPacientes(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.pacientesFitrados.filter(
      (paciente:any) =>
        paciente.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        paciente.cpf.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  public openModalExcluirPaciente(template: TemplateRef<any>, idPacienteExcluir:number) {
    this.idPacienteExcluir = 0;
    this.idPacienteExcluir = idPacienteExcluir;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirmExcluirCadastro(): void {
    this.pService.deleteCadastro(this.idPacienteExcluir)
      .subscribe(
        ()=>
          alert("Cadastro excluido com sucesso!"),
        (error:any)=>{
          alert("Erro ao tentar excluir cadastro");
          console.error(error);
          this.modalRef?.hide();
          this.getAllPacientes();
        },
        ()=>{
          this.modalRef?.hide();
          this.getAllPacientes();
        }
      );
    this.modalRef?.hide();
  }

  public declineExcluirCadastro(): void {
    this.idPacienteExcluir = 0;
    this.modalRef?.hide();
  }

  public editarCadastroPaciente(paciente:Paciente, template: TemplateRef<any>){
    this.limparPacienteEdit();
    this.getPacienteById(paciente.id);
    this.openModalCadastroPaciente(template)
  }

  private getPacienteById(id:number){
    this.pService.getPacienteById(id).subscribe({
      next: (p:Paciente) => {
        this.pacienteEdit = p;
      },
      error:(error:any) =>{
        alert('Erro');
      },
      complete:()=>{
        this.pacienteEdit.dataNascimento = this.getDateNasc(this.pacienteEdit.dataNascimento);
      }
    })
  }

  public novoPaciente(template: TemplateRef<any>){
    this.limparPacienteEdit();
    console.log(this.pacienteEdit);
    console.log(this.pacienteEdit.id);
    this.openModalCadastroPaciente(template);
  }

  public openModalCadastroPaciente(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template, this.config);
  }

  public fecharModalCadastroPaciente():void {
    this.limparPacienteEdit();
    this.modalRef?.hide();
  }

  public salvarCadastro(){
    if(this.pacienteEdit.id!==undefined && this.pacienteEdit.id!==null && this.pacienteEdit.id > 0)
    {
      this.pService.putAtualizarCadastro(this.pacienteEdit.id, this.pacienteEdit)
      .subscribe(
        ()=>alert("Cadastro atualizado com sucesso!"),
        (error:any)=>{
          alert("Erro ao tentar salvar alteração")
        },
        ()=>{
          this.modalRef?.hide();
          this.getAllPacientes();
        }
      );
    }
    else
    {
      this.pService.postNovoPaciente(this.pacienteEdit)
      .subscribe(
        ()=>alert("Cadastro salvo com sucesso!"),
        (error:any)=>{
          alert("Erro ao tentar salvar cadastro")
        },
        ()=>{
          this.modalRef?.hide();
          this.getAllPacientes();
        }
      );
    }
    //this.modalRef?.hide();
    //this.getAllPacientes();
  }

  public novoTelefone():void {
    this.pacienteEdit.telefones.push(
      {
        id:0,
        tipo: '',
        ddd: 0,
        numero: 0
      }
    );
  }

  public removeTelefone(index:any):void{
    this.pacienteEdit.telefones.splice((index),1);
    console.log(index);
  }

  clearPacientes(){
    this.pacientes = [];
  }

  ngOnInit() {
    this.getAllPacientes();
  }

}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  isCollapsed = true;
  iconClass: string = 'fa fa-user';
  subtitulo: string= " Cadastro de Paciente";
  titulo: string= "CRUD";

  constructor() { }

  ngOnInit() {
  }

}

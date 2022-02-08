import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxSpinner, NgxSpinnerModule } from 'ngx-spinner';
/* Componentes */
import { AppComponent } from './app.component';
import { PacientesComponent } from './pacientes/pacientes.component';

/* services */
import { PacienteService } from './services/Paciente.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
      PacientesComponent,
      DateTimeFormatPipe,
      NavbarComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ModalModule.forRoot(),
    NgxSpinnerModule
  ],
  providers: [PacienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }

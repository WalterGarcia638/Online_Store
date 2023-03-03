import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { DetalleProductoComponent } from './components/detalle-producto/detalle-producto.component';
import { MantenimientoUsuarioComponent } from './components/mantenimiento-usuario/mantenimiento-usuario.component';
import { BarraNavegacionComponent } from './components/barra-navegacion/barra-navegacion.component';

import { NavbarModule } from './navbar/navbar.module';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DetalleProductoComponent,
    MantenimientoUsuarioComponent,
    BarraNavegacionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NavbarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

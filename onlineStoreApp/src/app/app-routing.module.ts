import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetalleProductoComponent } from './components/detalle-producto/detalle-producto.component';
import { LoginComponent } from './components/login/login.component';
import { MantenimientoUsuarioComponent } from './components/mantenimiento-usuario/mantenimiento-usuario.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';


const routes: Routes = [
  {path: 'login', component: LoginComponent},
  //{path: 'detalleProducto', component: DetalleProductoComponent},
  //{path: 'mantenimientousuario', component: MantenimientoUsuarioComponent},
  {
    path: 'navBar', 
    component:NavbarComponent,
    loadChildren: ()=> import('../app/navbar/navbar.module').then(p=> p.NavbarModule)
  },
  {path: '**', pathMatch: 'full', redirectTo: 'navBar'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

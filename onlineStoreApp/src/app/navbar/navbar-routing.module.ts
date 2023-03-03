import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MantenimientoUsuarioComponent } from '../components/mantenimiento-usuario/mantenimiento-usuario.component';
import { DetalleProductoComponent } from '../components/detalle-producto/detalle-producto.component';
import { LoginComponent } from '../components/login/login.component';

const routes: Routes = [
  {
    path:'Usuarios',
    component: MantenimientoUsuarioComponent,
    loadChildren: () => import('../navbar/navbar.module').then(p => p.NavbarModule)
  },
  {
    path: 'Productos',
    component: DetalleProductoComponent,
    loadChildren: () => import('../navbar/navbar.module').then(P => P.NavbarModule)
  },
  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NavbarRoutingModule { }

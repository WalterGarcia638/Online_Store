import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(private router: Router) {
    
    
  }
  CerrarSesion(){
    sessionStorage.clear();
    setTimeout(()=>{
     this.refresh();
     this.router.navigate(['login'])
   }, 2000)
  }

  refresh(){
    window.location.reload();
   }
}

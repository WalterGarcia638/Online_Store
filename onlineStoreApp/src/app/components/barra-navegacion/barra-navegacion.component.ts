import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-barra-navegacion',
  templateUrl: './barra-navegacion.component.html',
  styleUrls: ['./barra-navegacion.component.css']
})
export class BarraNavegacionComponent implements OnInit {
  isLogin =true;

  constructor(private router: Router){
    /*if(!sessionStorage.getItem('login')){
      this.router.navigate(['Login']);
    }*/
    
  }

  ngOnInit(): void {
    if(!sessionStorage.getItem('email')){
      this.isLogin = false;
      this.router.navigate(['login']);
    }
  }
  

  CerrarSesion(){
    sessionStorage.clear();
    setTimeout(()=>{
     this.refresh();
    
   }, 2000)
  }

  refresh(){
    window.location.reload();
   }
}

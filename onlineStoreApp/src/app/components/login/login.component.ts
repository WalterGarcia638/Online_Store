import { Component } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  form:FormGroup;
  usuario  = "omargarcia638";
  password = "123456";

  
  constructor(private formBuilder: FormBuilder,
              private router: Router) {
    this.form = this.formBuilder.group({
      email:[""],
      password:[""],      
    })      
  }

  EnviarDatosUsuario(){
    var formulario = this.form.value;
    console.log(formulario)
    this.login()
  }

  login()
  {
    if( this.usuario == this.form.get('email')?.value || this.password == this.form.get('password')?.value){
      sessionStorage.setItem('email', this.usuario);
      sessionStorage.setItem('password', this.password)
      this.router.navigate(['detalleProducto'])
    }
  }
}

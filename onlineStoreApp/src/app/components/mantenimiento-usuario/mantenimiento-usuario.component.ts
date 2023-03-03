import { Component } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-mantenimiento-usuario',
  templateUrl: './mantenimiento-usuario.component.html',
  styleUrls: ['./mantenimiento-usuario.component.css']
})
export class MantenimientoUsuarioComponent {

  form:FormGroup;

  
  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      id:0,
      nombre:[],
      apellido:[],
      correoElectronico:[],
      nombreUsuario:[],
      rol:[]
    })  
    
  }

  EnviarDatosUsuario(){
    var formulario = this.form.value;
    console.log(formulario)

  }

}

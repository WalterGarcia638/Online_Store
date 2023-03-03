import { Component } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-detalle-producto',
  templateUrl: './detalle-producto.component.html',
  styleUrls: ['./detalle-producto.component.css']
})
export class DetalleProductoComponent {

  form:FormGroup;

  
  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      id:0,
      nombre:[],
      precio:[],
      stock:[],
      color:[],
      URLImagen:[],
      idCategoria:[],
      descripcion:[]      
    })      
  }

  EnviarDatosUsuario(){
    var formulario = this.form.value;
    console.log(formulario)

  }
}

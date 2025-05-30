import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-olvidar-contrasena',
  templateUrl: './olvidar-contrasena.component.html',
  styleUrls: ['./olvidar-contrasena.component.css']
})
export class OlvidarContrasenaComponent {

  // Declara un Output para emitir un evento al componente padre
  @Output() cerrar = new EventEmitter<void>();

  // Método para emitir el evento al cerrar el modal
  cerrarModal() {
    this.cerrar.emit(); // Emitir el evento al padre
  }
}
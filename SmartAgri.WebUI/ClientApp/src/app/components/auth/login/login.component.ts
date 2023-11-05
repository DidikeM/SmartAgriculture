import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faEnvelope, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  faEnvelope = faEnvelope;
  faLock = faLock;
  faEyeSlash = faEyeSlash;
  faEye = faEye;

  showPassword = true;

  constructor(private router: Router) {}

  navigateToRegister() {
    this.router.navigate(['/auth/register']); 
  }

  navigateToForgotPassword(){
    this.router.navigate(['/auth/forgot-password']); 

  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }
}

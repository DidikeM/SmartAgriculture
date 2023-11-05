import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faEnvelope, faUser, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  faUser = faUser;
  faEnvelope = faEnvelope;
  faLock = faLock;
  faEyeSlash = faEyeSlash;
  faEye = faEye;

  showPassword = true;

  selectedOption: string = '';

  constructor(private router: Router) {}

  navigateToLogin(){
    this.router.navigate(["/auth/login"]);
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }
}

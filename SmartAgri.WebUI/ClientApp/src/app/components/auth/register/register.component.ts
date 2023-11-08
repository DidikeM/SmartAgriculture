import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { faEnvelope, faUser, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';
import { ValidationService } from '../../../services/validation.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  faUser = faUser;
  faEnvelope = faEnvelope;
  faLock = faLock;
  faEyeSlash = faEyeSlash;
  faEye = faEye;

  showPassword = true;

  selectedOption: string = '';

  constructor(private router: Router, public validationService: ValidationService) {}
 
  registerForm!: FormGroup;

  ngOnInit() {
    this.registerForm = new FormGroup({
      'username': new FormControl(null, [this.validationService.usernameValidation]),
      'email': new FormControl(null, [this.validationService.emailValidation]),
      'password': new FormControl(null, [this.validationService.passwordValidation]),
      'confirmPassword': new FormControl(null, Validators.required),
      'userType': new FormControl(null, Validators.required),
    }, this.validationService.passwordMatch('password', 'confirmPassword'));
  }

  getControl(name:any) : AbstractControl | null{
    return this.registerForm.get(name);
  }

  onSubmit(){
    console.log(this.registerForm.value);
  }

  navigateToLogin(){
    this.router.navigate(["/auth/login"]);
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }
}

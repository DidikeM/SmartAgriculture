import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { faEnvelope, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';

import { ValidationService } from '../../../services/validation.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit{
  faEnvelope = faEnvelope;
  faLock = faLock;
  faEyeSlash = faEyeSlash;
  faEye = faEye;

  showPassword = true;

  constructor(private router: Router, public validationService: ValidationService) {}

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = new FormGroup({
        email: new FormControl(null, this.validationService.emailValidation),
        password: new FormControl(null, this.validationService.passwordValidation) 
    })
  }

  getControl(name:any) : AbstractControl | null{
    return this.loginForm.get(name);
  }

  onSubmit(){
    console.log(this.loginForm.value);
  }

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

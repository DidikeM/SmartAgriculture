import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { faEnvelope, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';

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

  loginForm!: FormGroup;
  emailRegex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,5}){1,2}$/;;
  
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.maxLength(32),Validators.pattern(this.emailRegex)]),
      'password': new FormControl(null, [Validators.required, Validators.maxLength(32), Validators.minLength(8)]),
    })
  }

  getControl(name:any) : AbstractControl | null{
    return this.loginForm.get(name);
  }

  onSubmit(){
    console.log(this.loginForm);
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

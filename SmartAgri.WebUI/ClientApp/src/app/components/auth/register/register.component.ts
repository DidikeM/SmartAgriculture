import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { faEnvelope, faUser, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';
import { passwordMatch } from '../validators/passwordMatch';

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

  registerForm!: FormGroup;
  emailRegex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,5}){1,2}$/;

  constructor(private router: Router) {}

  ngOnInit() {
    this.registerForm = new FormGroup({
      'username': new FormControl(null, [Validators.required, Validators.minLength(3)]),
      'email': new FormControl(null, [Validators.required, Validators.maxLength(32),Validators.pattern(this.emailRegex)]),
      'password': new FormControl(null, [Validators.required, Validators.maxLength(32), Validators.minLength(8)]),
      'confirmPassword': new FormControl(null, Validators.required),
      'userType': new FormControl(null, Validators.required),
    }, [passwordMatch("password", "confirmPassword")]);
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

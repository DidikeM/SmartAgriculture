import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { faEnvelope, faUser, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';
import { ValidationService } from '../../../services/validation.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { UserForRegistrationDto } from 'src/app/dtos/userforregistrationdto ';

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

  constructor(private router: Router, private authService: AuthenticationService ,public validationService: ValidationService) {}
 
  registerForm!: FormGroup;

  ngOnInit() {
    this.registerForm = new FormGroup({
      'name': new FormControl(null, [this.validationService.nameValidation]),
      'surname': new FormControl(null, [this.validationService.surnameValidation]),
      'email': new FormControl(null, [this.validationService.emailValidation]),
      'password': new FormControl(null, [this.validationService.passwordValidation]),
      'confirmPassword': new FormControl(null, Validators.required),
      // 'userType': new FormControl(null, Validators.required),
    }, this.validationService.passwordMatch('password', 'confirmPassword'));
  }

  getControl(name:any) : AbstractControl | null{
    return this.registerForm.get(name);
  }

  onSubmit(){
    // console.log(this.registerForm.value);

    const name = this.registerForm.get('name')?.value;
    const surname = this.registerForm.get('surname')?.value;
    const email = this.registerForm.get('email')?.value;
    const password = this.registerForm.get('password')?.value;
    const confirmPassword = this.registerForm.get('confirmPassword')?.value;

    const user: UserForRegistrationDto  = {
      name: name,
      surname: surname,
      email: email,
      password: password,
      confirmPassword: confirmPassword
    }

    this.authService.registerUser(user)
    .subscribe({
      next: (_) => {
        // this.router.navigate(["/auth/login"])
        console.log("Successful registration")
      },
    })
  }

  navigateToLogin(){
    this.router.navigate(["/auth/login"]);
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }
}

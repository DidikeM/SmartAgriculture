import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { faEnvelope, faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';
import { ValidationService } from '../../../services/validation.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { UserForAuthenticationDto } from 'src/app/dtos/userforauthenticationdto';
import { AuthResponseDto } from 'src/app/dtos/authResponsedto';

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
  private returnUrl!: string;

  constructor(private router: Router, private route: ActivatedRoute, private authService: AuthenticationService, public validationService: ValidationService) {}

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = new FormGroup({
        email: new FormControl(null, this.validationService.emailValidation),
        password: new FormControl(null, this.validationService.passwordValidation) 
    })

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  getControl(name:any) : AbstractControl | null{
    return this.loginForm.get(name);
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  onSubmit(){
    const email = this.loginForm.get('email')?.value;
    const password = this.loginForm.get('password')?.value;

    const userForAuth: UserForAuthenticationDto = {
      email: email,
      password: password
    }

    this.authService.loginUser(userForAuth)
    .subscribe({
      next: (res: AuthResponseDto) => {
        console.log(res.token);
        localStorage.setItem("token", res.token);
        this.authService.sendAuthStateChangeNotification();
        this.router.navigate([this.returnUrl]);
      }
    })
    // .subscribe({
    //   next: (res:AuthResponseDto) => {
    //    localStorage.setItem("token", res.token);
    //    this.router.navigate([this.returnUrl]);
    // },})
  }  
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

import { faLock, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ValidationService } from 'src/app/services/validation.service';
import { ResetPasswordDto } from 'src/app/dtos/resetpassworddto';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})

export class ResetPasswordComponent implements OnInit{
  faEyeSlash = faEyeSlash;
  faEye = faEye;
  faLock = faLock;

  resetPasswordForm!: FormGroup;
  showSuccess!: boolean;
  showError!: boolean;
  errorMessage!: string;
  successMessage!: string;
  
  showPassword = true;

  private token!: string;
  private email!: string;

  constructor(private authService: AuthenticationService, private route: ActivatedRoute, public validationService: ValidationService) { }

  ngOnInit() {
    console.log('ResetPasswordComponent initialized');

    this.resetPasswordForm = new FormGroup({
      'password': new FormControl(null, [this.validationService.passwordValidation]),
      'confirmPassword': new FormControl(null, Validators.required),
    }, this.validationService.passwordMatch('password', 'confirmPassword'));
  
    this.token = this.route.snapshot.queryParams['token'];

    // this.email = this.route.snapshot.paramMap.get('email') ?? 'default@example.com';
    this.email = this.route.snapshot.queryParams['email'];
  }

  getControl(name:any) : AbstractControl | null{
    return this.resetPasswordForm.get(name);
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  onSubmit(){
    this.showError = this.showSuccess = false;

    const password = this.resetPasswordForm.get('password')?.value;
    // const confirmPassword = this.resetPasswordForm.get('confirmPassword')?.value;

    const resetPassDto: ResetPasswordDto = {
      password: password,
      // confirmPassword: confirmPassword,
      token: this.token,
      email: this.email
    }

    this.authService.resetPassword(resetPassDto)
    .subscribe({
      next:(_) => this.showSuccess = true,
      error: (err: HttpErrorResponse) => {
        this.showError = true;
        this.errorMessage = err.message;
      }
    })
  }
}

import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';

import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { ValidationService } from 'src/app/services/validation.service';
import { ForgotPasswordDto } from 'src/app/dtos/forgotpassworddto';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit{
  faEnvelope = faEnvelope;

  forgotPasswordForm!: FormGroup;
  successMessage!: string;
  errorMessage!: string;
  showSuccess!: boolean;
  showError!: boolean;

  constructor(private authService: AuthenticationService,  private router: Router, private route: ActivatedRoute, public validationService: ValidationService) {}

  ngOnInit() {
    this.forgotPasswordForm = new FormGroup({
      'email': new FormControl(null, [this.validationService.emailValidation]),
    });
  }

  getControl(name:any) : AbstractControl | null{
    return this.forgotPasswordForm.get(name);
  }

  onSubmit(){
    this.showError = this.showSuccess = false;
    const email = this.forgotPasswordForm.get('email')?.value;

    const forgotPassDto: ForgotPasswordDto = {
      email: email,
      clientURI: 'https://localhost:44408/auth/resetpassword'
    }

    this.authService.forgotPassword(forgotPassDto)
    .subscribe({
      next: (_) => {
      this.showSuccess = true;
      this.successMessage = 'The link has been sent, please check your email to reset your password.';

      // this.router.navigate(['/auth/resetpassword'], {queryParams: { email: email }});
    },
    error: (err: HttpErrorResponse) => {
      this.showError = true;
      this.errorMessage = err.message;
    }})
  }
}

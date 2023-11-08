import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';

import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { ValidationService } from '../../../services/validation.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit{
  faEnvelope = faEnvelope;

  forgotPasswordForm!: FormGroup;

  constructor(public validationService: ValidationService) {}

  ngOnInit() {
    this.forgotPasswordForm = new FormGroup({
      'email': new FormControl(null, [this.validationService.emailValidation]),
    });
  }

  getControl(name:any) : AbstractControl | null{
    return this.forgotPasswordForm.get(name);
  }

  onSubmit(){
    console.log(this.forgotPasswordForm);
  }
}

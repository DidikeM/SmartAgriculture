import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';

import { faEnvelope } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit{
  faEnvelope = faEnvelope;

  forgotPasswordForm!: FormGroup;
  emailRegex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,5}){1,2}$/;

  ngOnInit() {
    this.forgotPasswordForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.maxLength(32),Validators.pattern(this.emailRegex)]),
    });
  }

  getControl(name:any) : AbstractControl | null{
    return this.forgotPasswordForm.get(name);
  }

  onSubmit(){
    console.log(this.forgotPasswordForm);
  }
}

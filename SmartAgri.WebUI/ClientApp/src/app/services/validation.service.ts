import { Injectable } from '@angular/core';
import { Validators, AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})

export class ValidationService {
  
  emailValidation(control: AbstractControl) {
    return Validators.compose([
      Validators.required,
      Validators.maxLength(32),
      Validators.pattern(/^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,5}){1,2}$/)
    ])!(control);
  }

  passwordValidation(control: AbstractControl) {
    return Validators.compose([
      Validators.required,
      Validators.minLength(8),
      Validators.maxLength(32),
      ])!(control)
  }

  nameValidation(control: AbstractControl){
    return Validators.compose([
      Validators.required,
      Validators.minLength(3),
    ])!(control)
  }

  surnameValidation(control: AbstractControl){
    return Validators.compose([
      Validators.required,
      Validators.minLength(3),
    ])!(control)
  }

  passwordMatch(password: string, confirmPassword: string) {
    return function(form: AbstractControl) {
      const passwordValue = form.get(password)?.value;
      const confirmPasswordValue = form.get(confirmPassword)?.value;

      if (passwordValue === confirmPasswordValue) {
          return null;
      }
      return{ passswordMismatchError: true }
    }
  }

  getErrorMessageForControl(controlName: string, control: AbstractControl): string {
    if (control.hasError('required')) {
      return `${controlName} is required`;
    }

    if (control.hasError('pattern')) {
      return `Please enter a valid ${controlName}`;
    }

    if (controlName == "Name" && control.hasError('minlength')) {
      return `${controlName} minimum 3 characters required`;
    }

    if (controlName == "Surname" && control.hasError('minlength')) {
      return `${controlName} minimum 3 characters required`;
    }

    if (controlName == "Password" && control.hasError('maxlength') || control.hasError('minlength')) {
      return `${controlName} should be between 8 and 32 characters`;
    }   
    
    if (control.hasError('minlength')) {
      return `${controlName} minimum 3 characters required`;
    }

    if (control.hasError('maxlength')) {
      return `${controlName} should be at most 32 characters`;
    }

    if (control.hasError('maxlength') || control.hasError('minlength')) {
      return `${controlName} should be between 8 and 32 characters`;
    }
  
    return 'An unknown error occurred';
  }
}

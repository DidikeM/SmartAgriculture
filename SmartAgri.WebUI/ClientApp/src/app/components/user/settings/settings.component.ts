import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';

import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent {

  constructor(public validationService: ValidationService) {}

  settingsForm!: FormGroup;

  ngOnInit() {
    this.settingsForm = new FormGroup({
      'password': new FormControl(null, [this.validationService.passwordValidation]),
      'confirmPassword': new FormControl(null, Validators.required),
    }, this.validationService.passwordMatch('password', 'confirmPassword'));
  }

  getControl(name:any) : AbstractControl | null{
    return this.settingsForm.get(name);
  }

  onSubmit(){

  }
}

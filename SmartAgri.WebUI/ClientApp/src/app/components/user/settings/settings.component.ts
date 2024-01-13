import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';

import { User } from 'src/app/models/user';
import { UserManagementService } from 'src/app/services/usermanagement.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent {

  constructor(private userManagementService: UserManagementService, public validationService: ValidationService) {}

  settingsForm!: FormGroup;
  user!: User;

  ngOnInit() {
    this.settingsForm = new FormGroup({
      'password': new FormControl('', [this.validationService.passwordValidation]),
      'confirmPassword': new FormControl('', Validators.required),
      'ecoinaddress': new FormControl('', Validators.required),
    }, this.validationService.passwordMatch('password', 'confirmPassword'));

    this.userManagementService.getUserInfo().subscribe(
      (user) => {
        this.user = user;
        console.log("getuserinfo", this.user);
        this.settingsForm.patchValue({
          'password': this.user.password,
          'confirmPassword': '', 
          'ecoinaddress': this.user.externalCoinAddress,
        });
      }
    );
  }

  getControl(name:any) : AbstractControl | null{
    return this.settingsForm.get(name);
  }

  onSubmit(){
    const password = this.settingsForm.get('password')?.value;
    const ecoinaddress = this.settingsForm.get('ecoinaddress')?.value;

    this.user.password = password;
    this.user.externalCoinAddress = ecoinaddress;

    this.userManagementService.postUserInfo(this.user)

  }
}

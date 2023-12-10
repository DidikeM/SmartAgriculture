import { Component } from '@angular/core';
import { FormGroup, FormControl, AbstractControl, Validators } from '@angular/forms';

import { ValidationService } from 'src/app/services/validation.service';
@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})

export class ContactComponent {
  contactForm!: FormGroup;

  constructor(public validationService: ValidationService) {}

  ngOnInit() {
    this.contactForm = new FormGroup({ 
      'name': new FormControl(null, [this.validationService.nameValidation]),
      'email': new FormControl(null, [this.validationService.emailValidation]),
      'message': new FormControl(null, [Validators.required]),
    });
  }

  getControl(name:any) : AbstractControl | null{
    return this.contactForm.get(name);
  }

  onSubmit() {
    const name = this.contactForm.get('name')?.value;
    const email = this.contactForm.get('email')?.value;
    const message = this.contactForm.get('message')?.value;

    console.log(name, email, message);
  }
}

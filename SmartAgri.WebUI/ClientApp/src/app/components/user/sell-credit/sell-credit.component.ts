import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-sell-credit',
  templateUrl: './sell-credit.component.html',
  styleUrls: ['./sell-credit.component.css']
})
export class SellCreditComponent {
  sellcreditForm!: FormGroup;
  balance!: number;

  constructor(private userManagementService: UserManagementService){}

  ngOnInit() {
    this.sellcreditForm = new FormGroup({ 
      'amount': new FormControl(null, [Validators.required]),
    });

    this.userManagementService.getBalanceForUser().subscribe(balance =>{
      this.balance = balance;
    })
  }


  onSubmit() {
    const amount = this.sellcreditForm.get('amount')?.value;

    this.userManagementService.sellCredit(amount);
    console.log(amount);
  }
}

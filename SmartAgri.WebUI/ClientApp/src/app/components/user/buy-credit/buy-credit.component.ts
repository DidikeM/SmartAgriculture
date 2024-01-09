import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-buy-credit',
  templateUrl: './buy-credit.component.html',
  styleUrls: ['./buy-credit.component.css']
})
export class BuyCreditComponent {
  buycreditForm!: FormGroup;
  balance!: number;

  constructor(private userManagementService: UserManagementService){}
  
  ngOnInit() {
    this.buycreditForm = new FormGroup({ 
      'amount': new FormControl(null, [Validators.required]),
    });

    this.userManagementService.getBalanceForUser().subscribe(balance =>{
      this.balance = balance;
    })
    
    console.log(this.balance);
  }

  onSubmit() {
    const amount = this.buycreditForm.get('amount')?.value;

    this.userManagementService.buyCredit(amount)
    console.log(amount);
  }
}

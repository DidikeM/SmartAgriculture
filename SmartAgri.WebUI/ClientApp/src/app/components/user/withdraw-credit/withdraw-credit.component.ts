import { Component } from '@angular/core';

import { FormGroup, FormControl, Validators } from '@angular/forms';
import { WithDrawDto } from 'src/app/dtos/withdrawdto';
import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-withdraw-credit',
  templateUrl: './withdraw-credit.component.html',
  styleUrls: ['./withdraw-credit.component.css']
})
export class WithdrawCreditComponent {
  withdrawcreditForm!: FormGroup;
  balance!: number;

  constructor(private userManagementService: UserManagementService){}

  ngOnInit() {
    this.withdrawcreditForm = new FormGroup({ 
      'coinaddress': new FormControl(null, [Validators.required]),
      'amount': new FormControl(null, [Validators.required]),
    });

    this.userManagementService.getBalanceForUser().subscribe(balance =>{
      this.balance = balance;
    })
  }


  onSubmit() {
    const amount = this.withdrawcreditForm.get('amount')?.value;
    const coinaddress = this.withdrawcreditForm.get('coinaddress')?.value;

    const withdrawdto: WithDrawDto = {
      address: coinaddress,
      amount: amount
    }

    this.userManagementService.withDrawCredit(withdrawdto)
    console.log(amount, coinaddress);
  }
}

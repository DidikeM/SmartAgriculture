import { Component } from '@angular/core';
import { UserManagementCustomersDto } from 'src/app/dtos/usermanagementcustomersdto';
import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent {
  customers: UserManagementCustomersDto[] = []; 
  isFetching = false;

  constructor(private usermanagementservice: UserManagementService) {}

  ngOnInit() {
    this.isFetching = true;
    this.usermanagementservice.getCustomers().subscribe(
      (data: UserManagementCustomersDto[]) => {
        this.isFetching = false;
        this.customers = data;
        console.log(this.customers)
      }
    );  
  }

}

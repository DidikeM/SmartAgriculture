import { Component } from '@angular/core';

import { faCheck, faBox, faCoins, faWallet} from '@fortawesome/free-solid-svg-icons';
import { UserManagementService } from 'src/app/services/usermanagement.service';
import { UserManagementStaticticsDto } from 'src/app/dtos/usermanagementstaticticsdto';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  faCheck = faCheck;
  faBox = faBox;
  faCoins = faCoins;
  faWallet = faWallet;

  adminStatistics: UserManagementStaticticsDto = {};

  constructor(private userManagementService: UserManagementService) {}

  ngOnInit() {
    this.userManagementService.getAdminStatistics().subscribe(
      (data: UserManagementStaticticsDto) => {
        this.adminStatistics = data;
      }
    );  
  }
}

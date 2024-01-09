import { Component } from '@angular/core';

import { faBars, faRightFromBracket, faUsers, faGauge, faMoneyBillTransfer, faCartShopping, faMoneyBill } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html',
  styleUrls: ['./dashboard-layout.component.css']
})

export class DashboardLayoutComponent {
  faBars = faBars;
  faRightFromBracket = faRightFromBracket;
  faUsers = faUsers;
  faGauge = faGauge;
  faMoneyBillTransfer = faMoneyBillTransfer;
  faCartShopping = faCartShopping;
  faMoneyBill = faMoneyBill;
  
  public isNavigationActive = false;

  public toggleNavigation(): void {
    this.isNavigationActive = !this.isNavigationActive;
  }
}

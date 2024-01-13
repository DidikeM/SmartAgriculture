import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faBars, faRightFromBracket, faUsers, faGauge, faMoneyBillTransfer, faCartShopping, faMoneyBill, faClockRotateLeft, faChartLine, faGear, faRectangleAd} from '@fortawesome/free-solid-svg-icons';
import { AuthenticationService } from 'src/app/services/authentication.service';

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
  faClockRotateLeft = faClockRotateLeft;
  faChartLine = faChartLine;
  faGear = faGear;
  faRectangleAd = faRectangleAd;
  
  roleId!: number;
  public isNavigationActive = false;

  constructor(private authService: AuthenticationService, private router: Router) { }

  public toggleNavigation(): void {
    this.isNavigationActive = !this.isNavigationActive;
  }

  ngOnInit() {
    this.roleId = Number(localStorage.getItem("roleId"));
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
  }
}

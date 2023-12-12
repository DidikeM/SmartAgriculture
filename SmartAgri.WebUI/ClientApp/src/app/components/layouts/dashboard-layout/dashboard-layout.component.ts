import { Component } from '@angular/core';

import { faBars, faMessage, faPlus, faRightFromBracket, faGear, faReceipt,faChartSimple, faUsers, faGauge } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html',
  styleUrls: ['./dashboard-layout.component.css']
})
export class DashboardLayoutComponent {
  faBars = faBars;
  faMessage = faMessage;
  faPlus = faPlus;
  faRightFromBracket = faRightFromBracket;
  faGear = faGear;
  faReceipt = faReceipt;
  faChartSimple = faChartSimple;
  faUsers = faUsers;
  faGauge = faGauge;
  
  public isNavigationActive = false;

  public toggleNavigation(): void {
    this.isNavigationActive = !this.isNavigationActive;
  }
}

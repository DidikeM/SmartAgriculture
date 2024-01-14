import { AfterViewInit, Component, ElementRef, OnDestroy, ViewChild } from '@angular/core';

import { faCheck, faBox, faCoins, faWallet} from '@fortawesome/free-solid-svg-icons';
import { UserManagementService } from 'src/app/services/usermanagement.service';
import { UserManagementStaticticsDto } from 'src/app/dtos/usermanagementstaticticsdto';

import Chart from 'chart.js/auto';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements AfterViewInit, OnDestroy{
  faCheck = faCheck;
  faBox = faBox;
  faCoins = faCoins;
  faWallet = faWallet;

  satistics: UserManagementStaticticsDto = {};
  roleId!: number;
  
  @ViewChild('polarChartCanvas') polarChartCanvas!: ElementRef<HTMLCanvasElement>;
  polarChart!: Chart;

  constructor(private userManagementService: UserManagementService) { }
  
  ngOnInit() {
    this.roleId = Number(localStorage.getItem("roleId"));

    if (this.roleId == 1) {
      this.userManagementService.getAdminStatistics().subscribe(
        (data: UserManagementStaticticsDto) => {
          this.satistics = data;
        }
      );  
    }
   else if (this.roleId == 2) {
    this.userManagementService.getUserSpecializedStatistics().subscribe(
      (data: UserManagementStaticticsDto) => {
        this.satistics = data;
      }
    );  
   }
  }

  ngAfterViewInit(): void {
    this.userManagementService.getCompletedAdvertStatusCount().subscribe(
      (responseData: any[]) => {
        this.createChart(this.polarChartCanvas, responseData);
      }
    );
  }

  ngOnDestroy(): void {
  }

  createChart(canvas: ElementRef<HTMLCanvasElement>, products: any[])
  {
    let labels: any[] = [];
    let datasetValues: number[] = [];
  
    Object.entries(products).forEach(product => {
      labels.push(product[1].item1.name);
      datasetValues.push(product[1].item2);
    });

    new Chart(canvas.nativeElement, {
      type: 'polarArea',
      data: {
        labels: labels,
        datasets: [{
          label: 'Product Sell Ratios',
          data: datasetValues,
          backgroundColor: [
            'rgb(234, 57, 67)',
            'rgb(234, 140, 0)',
            'rgb(243, 212, 47)',
            'rgb(147, 217, 0)',
            'rgb(22, 199, 132)'
          ]
        }]
      }
    })
  }
}


import { Component, OnInit } from '@angular/core';
import { UserManagementAdminAdvertDto } from 'src/app/dtos/usermanagementadminadvertdto';
import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-recent-adverts',
  templateUrl: './recent-adverts.component.html',
  styleUrls: ['./recent-adverts.component.css']
})
export class RecentAdvertsComponent implements OnInit {
  recentBuyAdverts: UserManagementAdminAdvertDto[] = [];
  recentSellAdverts: UserManagementAdminAdvertDto[] = [];
  isFetching = false;

  constructor(private userManagementService: UserManagementService) {}

  ngOnInit() {
    this.isFetching = true;
    this.userManagementService.getRecentBuyAdvertForAdmin().subscribe(
      (data) => {
        this.recentBuyAdverts = data;
      }
    );    
    this.userManagementService.getRecentSellAdvertForAdmin().subscribe(
      (data) => {
        this.isFetching = false;
        this.recentSellAdverts = data;
      }
    );
  }
}
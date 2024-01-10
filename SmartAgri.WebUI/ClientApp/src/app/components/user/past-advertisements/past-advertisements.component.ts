import { Component } from '@angular/core';

import { UserManagementAdvertDto } from 'src/app/dtos/usermanagementadvertdto';
import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-past-advertisements',
  templateUrl: './past-advertisements.component.html',
  styleUrls: ['./past-advertisements.component.css']
})
export class PastAdvertisementsComponent {
  pastBuyAdverts: UserManagementAdvertDto[] = [];
  pastSellAdverts: UserManagementAdvertDto[] = [];

  constructor(private userManagementService: UserManagementService) { }

  ngOnInit() {
    this.userManagementService.getPastBuyAdvertsForUser().subscribe(
      (buyAdverts) => {
        this.pastBuyAdverts = buyAdverts;
        console.log("pastbuyadvert", this.pastBuyAdverts)
      }
    );

    this.userManagementService.getPastSellAdvertsForUser().subscribe(
      (sellAdverts) => {
        this.pastSellAdverts = sellAdverts;
        console.log("pastSellAdverts", this.pastSellAdverts)

      }
    );
  }
}

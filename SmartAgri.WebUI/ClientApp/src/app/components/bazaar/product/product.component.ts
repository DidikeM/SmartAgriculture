import { Component } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent {
  tabs: string [] = ['Buy', 'Sell'];
  activatedTabIndex: number = 0;

  tabChange(tabIndex: number){
    this.activatedTabIndex = tabIndex;
  }
}

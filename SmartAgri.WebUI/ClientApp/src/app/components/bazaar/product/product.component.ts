import { AfterViewInit, Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { AdvertDto } from 'src/app/dtos/advertdto';
import { ProductDto } from 'src/app/dtos/productdto';
import { BazaarService } from 'src/app/services/bazaar.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent {
  imagesPath = "assets/images/bazaar/";
  tabs: string [] = ['Buy', 'Sell'];
  activatedTabIndex: number = 0;
  isFetching = false;

  tabChange(tabIndex: number){
    this.activatedTabIndex = tabIndex;
  }

  product: ProductDto = {};
  buyAdverts: AdvertDto[] = [];
  sellAdverts: AdvertDto[] = [];

  constructor(private bazaarService: BazaarService, private route: ActivatedRoute) {}
  
  ngOnInit() {
    this.isFetching = true;
    console.log("before")
    this.route.params.subscribe(params => {
      console.log("sub")
      const productId = +params['id'];

      this.bazaarService.getProduct(productId).subscribe(
        (product) => {
          this.isFetching = false;
          this.product = product;
          if (!this.product.imagePath || this.product.imagePath.length === 0 || this.product.imagePath === "")
            this.imagesPath = this.imagesPath.concat("default-image.png");
          else
            this.imagesPath = this.imagesPath.concat("wheat.png");
        }
      );

      this.bazaarService.getBuyAdvertsByProduct(productId).subscribe(
        (buyAdverts) => {
          this.buyAdverts = buyAdverts;
        }
      );

      this.bazaarService.getSellAdvertsByProduct(productId).subscribe(
        (sellAdverts) => {
          this.sellAdverts = sellAdverts;
        }
      );
    });
  }

  // ngAfterViewInit(): void {
  //   this.isFetching = false;
  //   console.log("after")
  // }
}

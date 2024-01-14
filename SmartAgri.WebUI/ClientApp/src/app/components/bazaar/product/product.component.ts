import { Component, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { AdvertDto } from 'src/app/dtos/advertdto';
import { ProductDto } from 'src/app/dtos/productdto';
import { BazaarService } from 'src/app/services/bazaar.service';
import { faLock,faLockOpen } from '@fortawesome/free-solid-svg-icons';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent {
  faLock = faLock;
  faLockOpen= faLockOpen;
  
  @ViewChild('myModal') modalElement!: ElementRef;

  imagesPath = "assets/images/bazaar/";
  tabs: string [] = ['Buy', 'Sell'];
  activatedTabIndex: number = 0;
  isFetching = false;
  isCalculating = false;
  advertForm!: FormGroup;
  calculationLock: Map<string, boolean>;
  product: ProductDto = {};
  buyAdverts: AdvertDto[] = [];
  sellAdverts: AdvertDto[] = [];

  tabChange(tabIndex: number){
    this.activatedTabIndex = tabIndex;
  }

  constructor(private bazaarService: BazaarService, private route: ActivatedRoute, validationService:ValidationService) {
    this.calculationLock = new Map<string, boolean>();
    this.initializeLocks()

    this.advertForm = new FormGroup({
      'unitPrice': new FormControl(null, Validators.required),
      'quantity': new FormControl(null, Validators.required),
      'totalPrice': new FormControl(null, Validators.required)
    });
  }

  fnCalculateOther = () => {
    if(this.calculationLock.get("quantity"))
      this.calculateOther("unitPrice","quantity");
    else if(this.calculationLock.get("unitPrice"))
      this.calculateOther("quantity","unitPrice");
      
  }

  onFocused(valueToChange: string, func: () => void): void {
    this.advertForm.get(valueToChange)?.valueChanges.subscribe(() => {
      console.log("Called to change ", valueToChange," with function ", func.name)
      if (!this.isCalculating) {
        this.isCalculating = true;
        func.call(this);
        this.isCalculating = false;
      }
    });
  }
  
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
            this.imagesPath = this.imagesPath.concat(this.product.imagePath);
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
  
  initializeLocks(): void
  {
    this.calculationLock.set("quantity", true);
    this.calculationLock.set("unitPrice", false);
  }

  checkLocks(clickedItem: string)
  {
    if (clickedItem === "quantity")
    {
      this.calculationLock.set("quantity", true);
      this.calculationLock.set("unitPrice", false);
    }
    else if (clickedItem === "unitPrice")
    {
      this.calculationLock.set("quantity", false);
      this.calculationLock.set("unitPrice", true);
    }
  }


  calculateTotalPrice(): void {
    const unitPrice = this.advertForm.get('unitPrice')?.value;
    const quantity = this.advertForm.get('quantity')?.value;
    const totalPrice = this.advertForm.get('totalPrice')?.value;
  
    if (unitPrice !== null && quantity !== null)
    {
      this.advertForm.get('totalPrice')?.setValue(quantity * unitPrice);
    }
  }
  
  calculateOther(valueBase: string, valueChange: string): void
  {
    const other = this.advertForm.get(valueBase)?.value;
    const totalPrice = this.advertForm.get('totalPrice')?.value;
  
    if (other !== null && totalPrice !== null && other !== 0)
    {
      this.advertForm.get(valueChange)?.setValue(totalPrice / other);
    } else if (other === 0)
    {
      this.advertForm.get(valueChange)?.setValue(0);
    }
  }

  openModal()
  {
    if (this.modalElement)
    {
      this.modalElement.nativeElement.style.display = 'block';
    }
  }

  closeModal()
  {
    if (this.modalElement)
    {
      this.modalElement.nativeElement.style.display = 'none';
    }
  }

  getColorForTab(): string {
    return this.activatedTabIndex === 0 ? 'Buy' : 'Sell';
  }

  onBuySell(selladvertId: number){
    console.log("component",selladvertId)
    this.bazaarService.buySellAdvert(selladvertId);
  }

  onSellBuy(selladvertId: number){
    this.bazaarService.sellBuyAdvert(selladvertId);
  }
  
  onSubmit() {
    if (this.activatedTabIndex === 0) {
      this.createSellAdvert();
    } else if (this.activatedTabIndex === 1) {
      this.createBuyAdvert();
    }

    this.closeModal();
  }

  createBuyAdvert() {
    const buyAdvertData = {
      productId: this.product.id,
      unitPrice: this.advertForm.get('unitPrice')?.value,
      quantity: this.advertForm.get('quantity')?.value,
    };

    this.bazaarService.addBuyAdvert(buyAdvertData);
  }

  createSellAdvert() {
    const sellAdvertData = {
      productId: this.product.id,
      unitPrice: this.advertForm.get('unitPrice')?.value,
      quantity: this.advertForm.get('quantity')?.value,
    };

    this.bazaarService.addSellAdvert(sellAdvertData);
  }
}

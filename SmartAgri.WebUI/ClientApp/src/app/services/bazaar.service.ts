import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ProductDto } from '../dtos/productdto';
import { AdvertDto } from '../dtos/advertdto';
import { AddBuyAdvertDto } from '../dtos/addbuyadvertdto';
import { AddSellAdvertDto } from '../dtos/addselladvertdto';
 
@Injectable({
    providedIn: 'root',
})

export class BazaarService {
    private apiUrl = 'https://localhost:7119/bazaar'; 

    constructor(private http: HttpClient){}

    getProducts(){
        return this.http.get<ProductDto[]>(`${this.apiUrl}/getproducts`);
    }

    getProduct(productId: number){
        return this.http.get<ProductDto>(`${this.apiUrl}/getProduct/${productId}`);
    }

    getBuyAdvertsByProduct(productId: number){
        return this.http.get<AdvertDto[]>(`${this.apiUrl}/getbuyadvertsbyproduct/${productId}`);
    }
    
    getSellAdvertsByProduct(productId: number){
        return this.http.get<AdvertDto[]>(`${this.apiUrl}/getselladvertsbyproduct/${productId}`);
    }

    addBuyAdvert(body: AddBuyAdvertDto) {
        console.log("addBuy", body);
        return this.http.post<AddBuyAdvertDto>(`${this.apiUrl}/addbuyadvert`, body).subscribe();
    }

    addSellAdvert(body: AddSellAdvertDto) {
        console.log("addSell", body);
        return this.http.post<AddSellAdvertDto>(`${this.apiUrl}/addselladvert`, body).subscribe();
    }

    buySellAdvert(selladvertId: number) {
        console.log("service",selladvertId)
        return this.http.post(`${this.apiUrl}/buyselladvert`, selladvertId).subscribe((response) => {
            console.log('Buy Advert created successfully:', response)});
    }

    sellBuyAdvert(buyAdvertId: number) {
        return this.http.post(`${this.apiUrl}/sellbuyadvert`, buyAdvertId).subscribe((response) => {
            console.log('Sell Advert created successfully:', response)});
    }
}
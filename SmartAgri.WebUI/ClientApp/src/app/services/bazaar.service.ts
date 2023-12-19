import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ProductDto } from '../dtos/productdto';
import { AdvertDto } from '../dtos/advertdto';
 
@Injectable({
    providedIn: 'root',
})

export class BazaarService {
    private apiUrl = 'http://localhost:5172/bazaar'; 

    constructor(private http: HttpClient){}

    getProducts(){
        return this.http.get<ProductDto[]>(`${this.apiUrl}/getproducts`);
    }

    getProduct(productId: number){
        return this.http.get<ProductDto>(`${this.apiUrl}/getProduct/${productId}`);
    }

    getBuyAdvertsByProduct(productId: number){
        return this.http.get<AdvertDto>(`${this.apiUrl}/getselladvertsbyproduct/${productId}`);
    }
    
    getSellAdvertsByProduct(productId: number){
        return this.http.get<AdvertDto>(`${this.apiUrl}/getselladvertsbyproduct/${productId}`);
    }
}
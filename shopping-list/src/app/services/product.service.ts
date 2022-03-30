import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl=environment.apiEndpoint;

  constructor(private http: HttpClient) { }

  public GetProducts() {
    let url = `${this.baseUrl}/Product`;
    return this.http.get<Product[]>(url);
  }
}

export const PRODUCTS: Product[] = [
    {
      id: "ae99ec58-6deb-42d1-92e8-8eb15540f7df",
      name: "Eggs",
      description: "12 count cage free eggs. Great for giant omelets.",
      price: 3,
      imageUrl: "/assets/eggs-thumbnail.png",
      imageAlt: "A carton of eggs"
    },
    {
      id: "49c22827-5dd7-4d50-bd66-8792e204e912",
      name: "Milk",
      description: "2% fat, 1 gallon jug of milk. Conveniently expires before you can drink all of it.",
      price: 5,
      imageUrl: "/assets/milk-thumbnail.png",
      imageAlt: "A jug of milk"
    },
    {
      id: "61fad516-1684-4eb6-b2bf-334d37fb5a81",
      name: "2022 Peterbilt Model 579",
      description: "A New Era of Class. The Model 579 sets the standard for technology, fuel efficiency and driver comfort.",
      price: 160420,
      imageUrl: "/assets/peterbilt-579-thumbnail.png",
      imageAlt: "A peterbilt 579"
    },
    {
      id: "f02870e7-6f9c-430b-b241-8aacfef6c28f",
      name: "2022 Peterbilt Model 365",
      description: "Durable, reliable and ready to be configured with a compact 115” BBC for a wide range of demanding applications.",
      price: 133900,
      imageUrl: "/assets/peterbilt-379-thumbnail.png",
      imageAlt: "A peterbilt 367"
    }
];
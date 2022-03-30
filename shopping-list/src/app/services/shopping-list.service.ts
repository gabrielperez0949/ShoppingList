import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ShoppingListItem } from '../models/shopping-list-item';

@Injectable({
  providedIn: 'root'
})
export class ShoppingListService {

  private baseUrl=environment.apiEndpoint;

  constructor(private http: HttpClient) { }

  public GetListItems(userId: string) {
    let url = `${this.baseUrl}/ShoppingList/${userId}`;
    return this.http.get<ShoppingListItem[]>(url);
  }

  public AddListItem(userId: string, productId: string) {
    let url = `${this.baseUrl}/ShoppingList/${userId}/product/${productId}`;
    return this.http.post(url, {});
  }

  public RemoveListItem(id: string) {
    let url = `${this.baseUrl}/ShoppingList/item/${id}`;
    return this.http.delete(url);
  }
}

export const SHOPPING_LIST_ITEMS: ShoppingListItem[] = [
  {
    id: "ae99ec58-6deb-42d1-92e8-8eb15540f7df",
    product: {
      id: "ae99ec58-6deb-42d1-92e8-8eb15540f7df",
      name: "eggs",
      description: "12 count cage free eggs. Great for giant omelets.",
      price: 3,
      imageUrl: "/assets/eggs-thumbnail.png",
      imageAlt: "A carton of eggs"
    }
  },
  {
    id: "ae99ec58-6deb-42d1-92e8-8eb15540f7df",
    product: {
      id: "49c22827-5dd7-4d50-bd66-8792e204e912",
      name: "milk",
      description: "2% fat, 1 gallon jug of milk. Conveniently expires before you can drink all of it.",
      price: 5,
      imageUrl: "/assets/milk-thumbnail.png",
      imageAlt: "A jug of milk"
    }
  },
  {
    id: "ae99ec58-6deb-42d1-92e8-8eb15540f7df",
    product: {
      id: "f02870e7-6f9c-430b-b241-8aacfef6c28f",
      name: "2022 Peterbilt Model 365",
      description: "Durable, reliable and ready to be configured with a compact 115” BBC for a wide range of demanding applications.",
      price: 133900,
      imageUrl: "/assets/peterbilt-379-thumbnail.png",
      imageAlt: "A peterbilt 379"
    }
  }
];
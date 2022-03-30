import { Component } from '@angular/core';
import { catchError } from 'rxjs';
import { Product } from './models/product';
import { ShoppingListItem } from './models/shopping-list-item';
import { User } from './models/user';
import { ProductService } from './services/product.service';
import { ShoppingListService } from './services/shopping-list.service';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  constructor(private userService: UserService, private productService: ProductService, private shoppingListService: ShoppingListService) { }

  public title = 'Shopping List';

  public products: Product[] = [];

  public shoppingList: ShoppingListItem[] = [];

  public users: User[] = [];

  public selectedUser: User;

  public initialLoad: boolean = true;

  ngOnInit(): void {
    this.getProducts();
    this.getUsers();
  }

  private getUsers() {
    this.userService.getUsers()
      .subscribe({
        next: (data: User[]) => {
          this.users = data;
          this.selectedUser = data[0];
          this.initialLoad = false;

          this.getListItems(this.selectedUser.id);
        },
        error: (error) => console.log(error) // Todo: push error to a messaging service, and display with toast.
      });
  }

  private getListItems(userid: string) {
    this.shoppingListService.GetListItems(userid)
      .subscribe({
        next: (data: ShoppingListItem[]) => this.shoppingList = data,
        error: (error) => console.log(error)
      });
  }

  private getProducts() {
    this.productService.GetProducts()
      .subscribe({
        next: (data: Product[]) => this.products = data,
        error: (error) => console.log(error)
      });
  }

  public removeShoppingCartItem(id: string) {
    this.shoppingListService.RemoveListItem(id)
      .subscribe({
        next: () => this.getListItems(this.selectedUser.id),
        error: (error) => console.log(error)
      });
  }

  public addShoppingCartItem(id: string) {
    this.shoppingListService.AddListItem(this.selectedUser.id, id)
      .subscribe({
        next: () => this.getListItems(this.selectedUser.id),
        error: (error) => console.log(error)
      });
  }

}

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ShoppingListItem } from 'src/app/models/shopping-list-item';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent implements OnInit {

  @Input() listItem: ShoppingListItem;

  @Output() removeShoppingCartItem = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

}

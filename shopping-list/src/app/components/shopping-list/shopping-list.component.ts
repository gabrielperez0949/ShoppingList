import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { ShoppingListItem } from 'src/app/models/shopping-list-item';
import { User } from 'src/app/models/user';
import { ShoppingListService } from 'src/app/services/shopping-list.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit {

  @Input() listItems : ShoppingListItem[] = [];

  @Output() removeShoppingCartItem = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void { }
}

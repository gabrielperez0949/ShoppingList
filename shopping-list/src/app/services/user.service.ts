import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl=environment.apiEndpoint;

  constructor(private http: HttpClient) { }

  public getUsers() {
    let url = `${this.baseUrl}/User`;
    return this.http.get<User[]>(url);
  }
}

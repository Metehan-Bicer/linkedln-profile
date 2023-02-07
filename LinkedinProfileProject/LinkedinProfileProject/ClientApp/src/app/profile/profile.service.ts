import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from './profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) {

  }

  getUser(): Observable<UserModel> {
    return this.http.get<UserModel>('api/user/getUser');
  }

}

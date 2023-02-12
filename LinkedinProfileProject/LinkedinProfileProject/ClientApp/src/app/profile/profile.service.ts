import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityModel, DistrictModel, ExperienceModel, UserModel } from './profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) {

  }

  getUser(): Observable<UserModel> {
    return this.http.get<UserModel>('api/user/getUser');
  }
  getUserById(userId: number): Observable<UserModel> {
    return this.http.get<UserModel>('api/user/getUserById/' + userId);
  }
  getCityList(): Observable<CityModel[]> {
    return this.http.get<CityModel[]>('api/base/getCity');
  }
  getDistrictByCityId(cityId: number): Observable<DistrictModel[]> {
    return this.http.get<DistrictModel[]>('api/base/getDistrictByCityId/' + cityId);
  }
  saveUpdateUser(userModel: UserModel): Observable<UserModel> {
    return this.http.post<UserModel>('api/user/saveUpdateUser', userModel);
  }
  saveUpdateExperience(model: ExperienceModel): Observable<ExperienceModel> {
    return this.http.post<ExperienceModel>('api/experience/saveUpdateExperience', model);
  }

}

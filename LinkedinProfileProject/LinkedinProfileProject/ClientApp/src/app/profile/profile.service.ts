import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AbilitiesModel, CityModel, DistrictModel, EducationModel, ExperienceModel, FileUploadModel, FileUploadModelImage, UserModel } from './profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) {

  }
  userId: number = 0;
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
  getExperienceList(userId: number): Observable<ExperienceModel[]> {
    return this.http.get<ExperienceModel[]>('api/experience/getExperienceList/' + userId);
  }
  getExperienceById(expId: number): Observable<ExperienceModel> {
    return this.http.get<ExperienceModel>('api/experience/getExperienceById/' + expId);
  }
  getEducationList(userId: number): Observable<EducationModel[]> {
    return this.http.get<EducationModel[]>('api/education/getEducationList/' + userId);
  }
  getEducationById(educationId: number): Observable<ExperienceModel> {
    return this.http.get<ExperienceModel>('api/education/getEducationById/' + educationId);
  }
  saveUpdateEducation(model: EducationModel): Observable<EducationModel> {
    return this.http.post<EducationModel>('api/education/saveUpdateEducation', model);
  }
  getAbilitiesList(userId: number): Observable<AbilitiesModel[]> {
    return this.http.get<AbilitiesModel[]>('api/abilities/getAbilitiesList/' + userId);
  }
  saveUpdateAbilities(model: AbilitiesModel): Observable<AbilitiesModel> {
    return this.http.post<AbilitiesModel>('api/abilities/saveUpdateAbilities', model);
  }
  getAbilitiesById(abilitiesId: number): Observable<AbilitiesModel> {
    return this.http.get<AbilitiesModel>('api/abilities/getAbilitiesById/' + abilitiesId);
  }
  deleteAbilitiesById(abilitiesId: number): Observable<boolean> {
    return this.http.post<boolean>('api/abilities/deleteAbilitiesById', abilitiesId);
  }
  deleteEducationById(educationId: number): Observable<boolean> {
    return this.http.post<boolean>('api/education/deleteEducationById', educationId);
  }
  deleteExperienceById(experienceId: number): Observable<boolean> {
    return this.http.post<boolean>('api/experience/deleteExperienceById', experienceId);
  }
  fileUpload(data: FileUploadModel): Observable<boolean> {
    const formData: FormData = new FormData();
    formData.append("file", data.file, data.file.name);
    if (data.userId) {
      formData.append("userId", data.userId.toString());
    }
    return this.http.post<boolean>("api/base/fileUpload/", formData);
  }
  getProfilePhoto(userId: number): Observable<FileUploadModelImage> {
    return this.http.get<FileUploadModelImage>('api/base/getProfilePhoto/' + userId);
  }
  setUserId(userId: number) {
    this.userId = userId;
  }
  getUserId() {
    return this.userId;
  }
}

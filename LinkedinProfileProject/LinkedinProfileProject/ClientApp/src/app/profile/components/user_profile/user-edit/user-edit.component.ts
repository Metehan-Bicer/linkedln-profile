import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CityModel, DistrictModel, UserModel } from 'src/app/profile/profile.model';
import { ProfileService } from 'src/app/profile/profile.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  @Input("bindForEdit")
  public set bindForEdit(val: number) {
    this.userId = val;
    if (this.userId != null || this.userId != 0 || this.userId != undefined) {
      //todo mete get metodu
      this.getUser();
    }
    else {
      this.userId = 0;
    }
  }
  @Output("cancel-event") public cancelEvent: EventEmitter<void> = new EventEmitter();
  display = "block";
  userId: number = 0;
  userEditForm: FormGroup;
  cityModel: CityModel[] = [];
  districtModel: DistrictModel[] = [];
  public cityId: number = 0;
  public districtId: number = 0;

  constructor(
    private readonly fb: FormBuilder,
    private readonly profileService: ProfileService
  ) {
  }
  getUser() {
    this.profileService.getUserById(this.userId).subscribe(res => {
      this.userEditForm.setValue(res);
      this.onSelectCity(res.cityId);
    })
  }

  ngOnInit(): void {
    this.initUserEditForm();
    this.getCityList();
  }

  onCloseUserEdit() {
    this.cancelEvent.emit();
  }
  onSave() {
    let requestModel = new UserModel();
    requestModel = this.userEditForm.getRawValue();
    this.profileService.saveUpdateUser(requestModel).subscribe(res => {
      this.cancelEvent.emit();
    })
  }

  get formControls() {
    return this.userEditForm.controls;
  }

  initUserEditForm() {
    this.userEditForm = this.fb.group({
      id: 0,
      name: [null, [Validators.required]],
      surName: [null, [Validators.required]],
      job: [null, [Validators.required]],
      districtId: [null],
      districtName: [null],
      cityName: [null],
      cityId: [null],
      company: [null, [Validators.required]],
    });
  }

  getCityList() {
    this.profileService.getCityList().subscribe(res => {
      this.cityModel = res;
    })
  }
  onSelectCity(cityId: number) {
    if (cityId != 0 || cityId != null) {
      this.profileService.getDistrictByCityId(cityId).subscribe(res => {
        this.districtModel = res;
      })
    }
    else {
      this.districtModel = [];
    }
  }

}

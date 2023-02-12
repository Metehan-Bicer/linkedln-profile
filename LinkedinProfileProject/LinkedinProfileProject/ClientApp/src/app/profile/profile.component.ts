import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { UserModel } from './profile.model';
import { ProfileService } from './profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  @ViewChild("profileEditModal") ngbmd: TemplateRef<any>;
  userId: number = 0;
  userModel: UserModel = new UserModel();

  constructor(
    private readonly profileService: ProfileService) {
  }
  userEditVisible: boolean = false

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.profileService.getUser().subscribe(res => {
      this.userModel = res;
      this.userId = res.id
    })
  }

  openUserEdit() {
    this.userEditVisible = true;
  }
  onCloseUserEdit() {
    this.getUser();
    this.userEditVisible = false;

  }

}

import { Component, OnInit } from '@angular/core';
import { UserModel } from './profile.model';
import { ProfileService } from './profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userModel: UserModel = new UserModel();

  constructor(
    private readonly profileService: ProfileService) {
  }

  ngOnInit(): void {
    // this.getUser();
  }

  // getUser() {
  //   this.profileService.getUser().subscribe(res => {
  //     this.userModel = res;
  //     console.log(res);
  //   })
  // }

}

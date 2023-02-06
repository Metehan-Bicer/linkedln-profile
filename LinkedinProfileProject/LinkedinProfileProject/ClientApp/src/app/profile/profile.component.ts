import { Component, OnInit } from '@angular/core';
import { UserModel } from './profile.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userModel: UserModel = new UserModel();


  constructor() { }

  ngOnInit(): void {
  }

}

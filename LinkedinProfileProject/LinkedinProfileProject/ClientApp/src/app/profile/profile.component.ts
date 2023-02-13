import { AfterViewInit, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FileUploadModelImage, UserModel } from './profile.model';
import { ProfileService } from './profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit, AfterViewInit {
  @ViewChild("profileEditModal") ngbmd: TemplateRef<any>;
  userId: number = 0;
  userModel: UserModel = new UserModel();
  imageModel: FileUploadModelImage;
  images: string[] = [];
  imageViewerVisibility: boolean = false;
  constructor(
    private readonly profileService: ProfileService) {
  }
  userEditVisible: boolean = false
  userFotoVisible: boolean = false

  ngOnInit(): void {
    this.getUser();
  }

  ngAfterViewInit(): void {

  }

  getUser() {
    this.profileService.getUser().subscribe(res => {
      this.userModel = res;
      this.userId = res.id
      this.profileService.setUserId(this.userId);

      this.profileService.getProfilePhoto(this.userId).subscribe(res => {
        this.imageModel = res;
        this.images.push("data:" + res.contentType + ";base64," + res.base64);
        if (res.base64 != null) {
          this.imageViewerVisibility = true;
        }
      })
    })
  }

  openPhoto() {
    this.userFotoVisible = true;

  }

  openUserEdit() {
    this.userEditVisible = true;
  }
  onCloseUserEdit() {
    this.getUser();
    this.userEditVisible = false;
  }
  onCloseUserPhoto() {
    this.getUser();
    this.userFotoVisible = false;
  }

}

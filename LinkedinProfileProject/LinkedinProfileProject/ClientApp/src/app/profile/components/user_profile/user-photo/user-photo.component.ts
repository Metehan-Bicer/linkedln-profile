import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FileUploadModel, FileUploadModelImage } from 'src/app/profile/profile.model';
import { ProfileService } from 'src/app/profile/profile.service';

@Component({
  selector: 'app-user-photo',
  templateUrl: './user-photo.component.html',
  styleUrls: ['./user-photo.component.css']
})
export class UserPhotoComponent implements OnInit {
  userId: number = 0;
  public fileUploadRequest = new FileUploadModel();
  imageModel: FileUploadModelImage;
  images: string[] = [];
  imageViewerVisibility: boolean = false;
  display = "block";
  @Output("cancel-event") public cancelEvent: EventEmitter<void> = new EventEmitter();
  @Input("bindForEdit")
  public set bindForEdit(val: number) {
    this.userId = val;
    if (this.userId != null || this.userId != 0 || this.userId != undefined) {
    }
    else {
      this.userId = 0;
    }
  }
  constructor(
    private readonly profileService: ProfileService
  ) { }

  ngOnInit(): void {
    this.profileService.getProfilePhoto(this.userId).subscribe(res => {
      this.imageModel = res;
      this.images.push("data:" + res.contentType + ";base64," + res.base64);
      if (res.base64 != null) {
        this.imageViewerVisibility = true;
      }
    })
  }

  onClose() {
    this.cancelEvent.emit();
  }

  submitFileUpload() {
    this.fileUploadRequest.userId = this.userId;
    this.fileUploadRequest.id = this.imageModel.id;
    this.profileService.fileUpload(this.fileUploadRequest).subscribe((res) => {
      this.cancelEvent.emit();
    });
  }
  handleFileInput(e: any) {
    this.fileUploadRequest.file = e.target.files[0];
  }
}

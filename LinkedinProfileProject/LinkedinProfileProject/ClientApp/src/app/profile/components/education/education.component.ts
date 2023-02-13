import { Component, Input, OnInit } from '@angular/core';
import { EducationModel } from '../../profile.model';
import { ProfileService } from '../../profile.service';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {

  educationEditVisible: boolean = false
  educationId: number = 0;
  educationModel: EducationModel[] = [];
  userId: number = 0;
  @Input("bindForEditUserId")
  public set bindForEditUserId(val: number) {
    this.userId = val;


  }
  constructor(private readonly profileService: ProfileService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    new Promise<void>((resolve) => setTimeout(() => resolve(), 100)).then(() => {
      this.getEducationList()
    });

  }
  newEducation() {
    this.educationId = 0;
    this.educationEditVisible = true;

  }
  openEducationEdit(educationId?: number) {
    if (educationId != null) {
      this.educationId = educationId;
    }
    this.educationEditVisible = true;
  }

  onCloseEducationEdit() {
    this.getEducationList();
    this.educationEditVisible = false;
  }

  getEducationList() {
    if (this.userId != 0) {
      this.profileService.getEducationList(this.userId).subscribe(res => {
        this.educationModel = res;
      })
    }

  }

}

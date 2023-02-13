import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { ExperienceModel } from '../../profile.model';
import { ProfileService } from '../../profile.service';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})
export class ExperienceComponent implements OnInit, AfterViewInit {
  experienceEditVisible: boolean = false
  experienceId: number = 0;
  experienceModel: ExperienceModel[] = [];



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
      this.getExperienceList()
    });

  }

  openExperinceEdit(expId?: number) {
    if (expId != null) {
      this.experienceId = expId;
    }
    this.experienceEditVisible = true;
  }
  newExperience() {
    this.experienceId = 0;
    this.experienceEditVisible = true;
  }

  onCloseExperinceEdit() {
    this.getExperienceList();
    this.experienceEditVisible = false;
  }

  getExperienceList() {
    if (this.userId != 0) {
      this.profileService.getExperienceList(this.userId).subscribe(res => {
        this.experienceModel = res;
      })
    }

  }
}

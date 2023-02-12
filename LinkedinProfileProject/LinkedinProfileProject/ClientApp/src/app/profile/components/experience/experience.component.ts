import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})
export class ExperienceComponent implements OnInit {
  experienceEditVisible: boolean = false
  experienceId: number = 0;
  userId: number = 0;
  @Input("bindForEditUserId")
  public set bindForEditUserId(val: number) {
    this.userId = val;
  }
  constructor() { }

  ngOnInit(): void {
  }

  openExperinceEdit() {
    this.experienceEditVisible = true;
  }

  onCloseExperinceEdit() {
    // this.getExperienceList();
    this.experienceEditVisible = false;

  }
}

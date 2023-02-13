import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExperienceModel } from 'src/app/profile/profile.model';
import { ProfileService } from 'src/app/profile/profile.service';

@Component({
  selector: 'app-experience-edit',
  templateUrl: './experience-edit.component.html',
  styleUrls: ['./experience-edit.component.css']
})
export class ExperienceEditComponent implements OnInit {
  @Input("bindForEdit")
  public set bindForEdit(val: number) {
    this.experinceId = val;
    if (this.experinceId != null || this.experinceId != 0 || this.experinceId != undefined) {
      this.getExperience();
    }
    else {
      this.experinceId = 0;
    }
  }
  @Input("bindForEditUserId")
  public set bindForEditUserId(val: number) {
    this.userId = val;
  }
  @Output("cancel-event") public cancelEvent: EventEmitter<void> = new EventEmitter();
  editForm: FormGroup;
  display = "block";
  experinceId: number = 0;
  userId: number = 0;
  experienceEditForm: FormGroup;
  constructor(private readonly fb: FormBuilder,
    private readonly profileService: ProfileService) { }

  ngOnInit(): void {
    this.initEditForm();
  }

  onCloseEdit() {
    this.cancelEvent.emit();
  }
  get formControls() {
    return this.editForm.controls;
  }
  initEditForm() {
    this.editForm = this.fb.group({
      id: 0,
      title: [null, [Validators.required]],
      companyName: [null, [Validators.required]],
      sector: [null, [Validators.required]],
      userId: [null],
      comment: [null],
    });
  }

  onSave() {
    let requestModel = new ExperienceModel();
    requestModel = this.editForm.getRawValue();
    requestModel.userId = this.userId;
    this.profileService.saveUpdateExperience(requestModel).subscribe(res => {
      this.cancelEvent.emit();
    })
  }

  getExperience() {
    this.profileService.getExperienceById(this.experinceId).subscribe(res => {
      this.editForm.setValue(res);
    })
  }

  onDelete() {
    this.profileService.deleteExperienceById(this.experinceId).subscribe(res => {
      this.cancelEvent.emit();
    })
  }

}

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EducationModel, ExperienceModel } from 'src/app/profile/profile.model';
import { ProfileService } from 'src/app/profile/profile.service';

@Component({
  selector: 'app-education-edit',
  templateUrl: './education-edit.component.html',
  styleUrls: ['./education-edit.component.css']
})
export class EducationEditComponent implements OnInit {

  @Input("bindForEdit")
  public set bindForEdit(val: number) {
    this.educationId = val;
    if (this.educationId != null || this.educationId != 0 || this.educationId != undefined) {
      this.getEducation();
    }
    else {
      this.educationId = 0;
    }
  }
  @Input("bindForEditUserId")
  public set bindForEditUserId(val: number) {
    this.userId = val;
  }
  @Output("cancel-event") public cancelEvent: EventEmitter<void> = new EventEmitter();
  editForm: FormGroup;
  display = "block";
  educationId: number = 0;
  userId: number = 0;
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
      school: [null, [Validators.required]],
      department: [null, [Validators.required]],
      userId: [null],
      comment: [null],
    });
  }

  onSave() {
    let requestModel = new EducationModel();
    requestModel = this.editForm.getRawValue();
    requestModel.userId = this.userId;
    this.profileService.saveUpdateEducation(requestModel).subscribe(res => {
      this.cancelEvent.emit();
    })
  }

  getEducation() {
    this.profileService.getEducationById(this.educationId).subscribe(res => {
      this.editForm.setValue(res);
    })
  }

  onDelete() {
    this.profileService.deleteEducationById(this.educationId).subscribe(res => {
      this.cancelEvent.emit();
    })
  }

}

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AbilitiesModel } from 'src/app/profile/profile.model';
import { ProfileService } from 'src/app/profile/profile.service';

@Component({
  selector: 'app-abilities-edit',
  templateUrl: './abilities-edit.component.html',
  styleUrls: ['./abilities-edit.component.css']
})
export class AbilitiesEditComponent implements OnInit {

  @Input("bindForEdit")
  public set bindForEdit(val: number) {
    this.abilitiesId = val;
    if (this.abilitiesId != null || this.abilitiesId != 0 || this.abilitiesId != undefined) {
      this.getAbilities();
    }
    else {
      this.abilitiesId = 0;
    }
  }
  @Input("bindForEditUserId")
  public set bindForEditUserId(val: number) {
    this.userId = val;
  }
  @Output("cancel-event") public cancelEvent: EventEmitter<void> = new EventEmitter();
  editForm: FormGroup;
  display = "block";
  abilitiesId: number = 0;
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
      abilitiesName: [null, [Validators.required]],
      userId: [null],
    });
  }

  onSave() {
    let requestModel = new AbilitiesModel();
    requestModel = this.editForm.getRawValue();
    requestModel.userId = this.userId;
    this.profileService.saveUpdateAbilities(requestModel).subscribe(res => {
      this.cancelEvent.emit();
    })
  }
  onDelete() {
    this.profileService.deleteAbilitiesById(this.abilitiesId).subscribe(res => {
      this.cancelEvent.emit();
    })
  }

  getAbilities() {
    this.profileService.getAbilitiesById(this.abilitiesId).subscribe(res => {
      this.editForm.setValue(res);
    })
  }

}

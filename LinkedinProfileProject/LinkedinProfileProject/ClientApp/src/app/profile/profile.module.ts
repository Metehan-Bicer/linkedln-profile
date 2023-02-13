import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceComponent } from './components/experience/experience.component';
import { ProfileComponent } from './profile.component';
import { EducationComponent } from './components/education/education.component';
import { AbilitiesComponent } from './components/abilities/abilities.component';
import { UserEditComponent } from './components/user_profile/user-edit/user-edit.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExperienceEditComponent } from './components/experience/experience-edit/experience-edit.component';
import { EducationEditComponent } from './components/education/education-edit/education-edit.component';
import { AbilitiesEditComponent } from './components/abilities/abilities-edit/abilities-edit.component';
import { UserPhotoComponent } from './components/user_profile/user-photo/user-photo.component';



@NgModule({
  declarations: [
    ExperienceComponent,
    ProfileComponent,
    EducationComponent,
    AbilitiesComponent,
    UserEditComponent,
    ExperienceEditComponent,
    EducationEditComponent,
    AbilitiesEditComponent,
    UserPhotoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [

  ]
})
export class ProfileModule { }

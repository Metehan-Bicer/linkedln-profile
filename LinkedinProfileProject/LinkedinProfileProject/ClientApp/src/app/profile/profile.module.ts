import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceComponent } from './components/experience/experience.component';
import { ProfileComponent } from './profile.component';
import { EducationComponent } from './components/education/education.component';
import { AbilitiesComponent } from './components/abilities/abilities.component';



@NgModule({
  declarations: [
    ExperienceComponent,
    ProfileComponent,
    EducationComponent,
    AbilitiesComponent
  ],
  imports: [
    CommonModule,
  ],
  exports: [

  ]
})
export class ProfileModule { }

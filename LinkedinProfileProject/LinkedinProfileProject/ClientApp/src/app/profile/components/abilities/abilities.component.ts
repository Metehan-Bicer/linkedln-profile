import { Component, Input, OnInit } from '@angular/core';
import { AbilitiesModel } from '../../profile.model';
import { ProfileService } from '../../profile.service';

@Component({
  selector: 'app-abilities',
  templateUrl: './abilities.component.html',
  styleUrls: ['./abilities.component.css']
})
export class AbilitiesComponent implements OnInit {

  abilitiesEditVisible: boolean = false
  abilitiesId: number = 0;
  abilitiesModel: AbilitiesModel[] = [];
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
      this.getAbilitiesList()
    });

  }
  newAbilities() {
    this.abilitiesId = 0;
    this.abilitiesEditVisible = true;

  }
  openAbilitiesEdit(abilitiesId?: number) {
    if (abilitiesId != null) {
      this.abilitiesId = abilitiesId;
    }
    this.abilitiesEditVisible = true;
  }

  onCloseAbilitiesEdit() {
    this.getAbilitiesList();
    this.abilitiesEditVisible = false;
  }

  getAbilitiesList() {
    if (this.userId != 0) {
      this.profileService.getAbilitiesList(this.userId).subscribe(res => {
        this.abilitiesModel = res;
      })
    }

  }

}

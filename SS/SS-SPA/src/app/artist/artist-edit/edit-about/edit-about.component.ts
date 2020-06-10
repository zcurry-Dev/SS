import { Component, OnInit, Input, HostListener } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { ArtistApiService } from 'src/app/_services/artist.service/artist.api.service';
import { FormControl, Validators, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import {
  map,
  filter,
  switchMap,
  distinctUntilChanged,
  count,
} from 'rxjs/operators';
import { ArtistService } from 'src/app/_services/artist.service/artist.subject.service';
import { UtilityApiService } from 'src/app/_services/utility.service/utility.api.service';
import { UsState } from 'src/app/_models/usState';

@Component({
  selector: 'app-edit-about',
  templateUrl: './edit-about.component.html',
  styleUrls: ['./edit-about.component.css'],
})
export class EditAboutComponent implements OnInit {
  @Input() artist: Artist;
  editArtistAboutForm = this.fb.group({
    name: new FormControl(this.artist?.name, [Validators.required]),
    usHomeCountry: new FormControl('', [Validators.required]),
    // ushomestate: new FormControl('', [Validators.required]),
  });

  usStates: UsState[];

  // usStates: string[] = ['Texas', 'Virginia', 'Tennessee'];

  // //Commented out while editing to make it easier
  // @HostListener('window:beforeunload', ['$event'])
  // unloadNotification($event: any) {
  //   if (this.editArtistAboutForm.dirty) {
  //     $event.returnValue = true;
  //   }
  // }

  constructor(
    private alertify: AlertifyService,
    private artistService: ArtistApiService,
    private router: Router,
    private fb: FormBuilder,
    private _artist: ArtistService,
    private _utility: UtilityApiService
  ) {}

  ngOnInit() {
    this.getStates();
    this.watchArtist();
    this.setFormValues();
  }

  updateArtist() {
    this.updateValues();
    this.artistService.Save(this.artist).subscribe(
      (next) => {
        console.log(this.editArtistAboutForm);
        console.log(this.editArtistAboutForm.controls.usHomeCountry.value);

        this.alertify.success('Artist updated successfully');
        this.editArtistAboutForm.reset(this.artist);
        this.router.navigate(['/artist', this.artist.id]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  setFormValues() {
    this.editArtistAboutForm.patchValue(this.artist);
  }

  updateValues() {
    this.artist.name = this.editArtistAboutForm.value.name;
    const countryId = this.editArtistAboutForm.value.homeCountryId;
    if (countryId === 1) {
      this.artist.homeCountryId = 1;
    }
    console.log(countryId);

    // else {
    //   this.artist.homeCountryId = 2;
    // }
  }

  watchArtist() {
    this._artist.artist$.pipe(distinctUntilChanged()).subscribe((artist) => {
      this.artist = artist;
      console.log(this.artist);
    });
  }

  getStates() {
    this._utility.ListUsStates().subscribe((usStates) => {
      this.usStates = usStates;
    });
  }

  setCountry() {
    if (this.artist.homeCountryId === 1) {
    }
  }
}

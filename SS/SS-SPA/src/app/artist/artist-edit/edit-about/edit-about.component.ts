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
import { UtilityService } from 'src/app/_services/utility.service/utility.subject.service';

@Component({
  selector: 'app-edit-about',
  templateUrl: './edit-about.component.html',
  styleUrls: ['./edit-about.component.css'],
})
export class EditAboutComponent implements OnInit {
  @Input() artist: Artist;
  updatedArtist: Artist = new Artist();
  editArtistAboutForm = this.fb.group({
    name: new FormControl(this.artist?.name, [Validators.required]),
    usHomeCountry: new FormControl('', [Validators.required]),
    homeUsState: new FormControl(),
    homeWorldRegion: new FormControl(),
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
    private _utilityApi: UtilityApiService,
    private _utility: UtilityService
  ) {}

  ngOnInit() {
    console.log(this.artist);

    this.getUsStates();
    this.watchArtist();
    this.setCountry();
    this.setFormValues();
  }

  updateArtist() {
    this.updateValues();

    // this.artistService.Save(this.artist).subscribe(
    //   (next) => {

    //     this.alertify.success('Artist updated successfully');
    //     this.editArtistAboutForm.reset(this.artist);
    //     this.router.navigate(['/artist', this.artist.id]);
    //   },
    //   (error) => {
    //     this.alertify.error(error);
    //   }
    // );
  }

  setFormValues() {
    this.editArtistAboutForm.patchValue(this.artist);
  }

  updateValues() {
    console.log(this.artist);
    // this.artist.name = this.editArtistAboutForm.value.name;
    // const countryId = this.editArtistAboutForm.value.homeCountryId;
    // if (countryId === 1) {
    //   this.artist.homeCountryId = 1;
    // }
    // this.artist.homeStateId = this.editArtistAboutForm.value.homeStateId;
    console.log(this.artist);
  }

  watchArtist() {
    this._artist.artist$.pipe(distinctUntilChanged()).subscribe((artist) => {
      this.artist = artist;
    });
  }

  watchUtilities() {
    // this._utility.update;
  }

  // getArtist() {
  //   this.route.data
  //     .subscribe((data) => {
  //       this._artist.update({ artist: data['artist'] });
  //     })
  //     .unsubscribe();
  // }

  // getStates() {
  //   this._utilityApi.ListUsStates().subscribe((usStates) => {
  //     this.usStates = usStates;
  //   });
  // }

  getUsStates() {
    this._utilityApi.ListUsStates().subscribe((usStates) => {
      this.usStates = usStates;
    });
  }

  setCountry() {
    if (this.artist.homeCountryId === 1) {
      this.editArtistAboutForm.controls.usHomeCountry.patchValue('US');
    } else {
      this.editArtistAboutForm.controls.usHomeCountry.patchValue('Other');
    }
  }
}

import { Component, OnInit, Input, HostListener } from '@angular/core';
import { Artist } from 'src/app/_models/artist';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service/alertify.service';
import { ArtistApiService } from 'src/app/_services/artist.service/artist.api.service';
import { FormControl, Validators, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import {
  map,
  distinctUntilChanged,
  startWith,
  debounceTime,
} from 'rxjs/operators';
import { ArtistService } from 'src/app/_services/artist.service/artist.subject.service';
import { UtilityApiService } from 'src/app/_services/utility.service/utility.api.service';
import { UsState } from 'src/app/_models/usState';
import { UtilityService } from 'src/app/_services/utility.service/utility.subject.service';
import { UsCity } from 'src/app/_models/city';

interface ArtistForm {
  name: string;
  usHomeCountry: boolean;
  homeCountryId: number;
  homeUsState: number;
  homeWorldRegion: any;
  homeUsCity: any;
  homeUsCityId: number;
}

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
    homeCountryId: new FormControl(1, [Validators.required]),
    homeUsState: new FormControl(),
    homeWorldRegion: new FormControl(),
    homeUsCity: new FormControl({ value: '', disabled: true }),
  });

  // form: ArtistForm = this.editArtistAboutForm.value;

  usStates: UsState[];
  usCities: UsCity[] = [];
  filteredCities: Observable<any[]>;
  question = 'Add "';

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
    console.log('artist', this.artist);
    this.watchArtist();
    this.watchUtilities();
    this.setArtistForm();
    this.usCityFilterPipe();
  }

  updateArtist() {
    console.log(this.artist);
    this.setArtistValues();
    console.log(this.artist);

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

  // there has to be a better way
  setArtistValues() {
    const f = this.editArtistAboutForm.value;
    console.log(f);

    this.artist.name = f.name;
    if (f.usHomeCountry) {
      this.setUSArtist(f);
    } else {
      this.setNonUSArtist(f);
    }
  }

  setUSArtist(f: ArtistForm) {
    this.artist.homeCountryId = f.homeCountryId;
    this.artist.homeRegionId = f.homeUsState;
    this.artist.homeCityId = f.homeUsCityId;
  }

  setNonUSArtist(f: ArtistForm) {
    this.artist.homeCountryId = 2;
    this.artist.homeRegionId = f.homeWorldRegion;
  }

  usRadioChange(bool) {
    this._utility.update({ usCountry: bool.value });
  }

  changeUSState() {
    const newStateId = this.editArtistAboutForm.controls.homeUsState.value;
    this.artist.homeRegionId = newStateId;

    this._artist.update({ artist: this.artist });

    this.getUSStateCities();
  }

  watchArtist() {
    this._artist.artist$
      .pipe(distinctUntilChanged())
      .subscribe((artist: Artist) => {
        this.artist = artist;
        if (this.artist.homeRegionId) {
          this.editArtistAboutForm.controls.homeUsCity.enable();
          this.getUSStateCities();
        } else {
          this._utility.update({ usCities: null });
        }
      });
  }

  watchUtilities() {
    this._utility.usCountry$.pipe(distinctUntilChanged()).subscribe((data) => {
      if (!this.usStates) {
        this.getUsStates();
      }
    });

    this._utility.usStates$
      .pipe(distinctUntilChanged())
      .subscribe((states: UsState[]) => {
        this.usStates = states;
      });

    this._utility.usCities$
      .pipe(distinctUntilChanged())
      .subscribe((cities: UsCity[]) => {
        if (cities) {
          this.usCities = cities;
          this.editArtistAboutForm.controls.homeUsCity.enable();
          if (
            this.usCities.some((entry) => entry.id === this.artist.homeCityId)
          ) {
            this.editArtistAboutForm.controls.homeUsCity.patchValue(
              this.usCities.find((x) => x.id === this.artist.homeCityId).name
            );
          }
        } else {
          this.usCities = [];
        }
      });
  }

  getUsStates() {
    this._utilityApi.ListUsStates().subscribe((usStates: UsState[]) => {
      this._utility.update({ usStates });
    });
  }

  getUSStateCities() {
    console.log('test for new artist', this.artist.homeRegionId);

    this._utilityApi
      .ListUSStateCities(this.artist.homeRegionId)
      .subscribe((usCities: UsCity[]) => {
        this._utility.update({ usCities });
      });
  }

  setArtistForm() {
    const controls = this.editArtistAboutForm.controls;
    controls.name.patchValue(this.artist.name);
    if (this.artist.homeCountryId === 1) {
      controls.usHomeCountry.patchValue(true);
      controls.homeUsState.patchValue(this.artist.homeRegionId);
    } else {
      controls.usHomeCountry.patchValue(false);
    }
  }

  // better name for this?
  usCityFilterPipe() {
    this.filteredCities = this.editArtistAboutForm.controls.homeUsCity.valueChanges.pipe(
      debounceTime(500),
      startWith(''),
      map((state: string) =>
        state
          ? this.filterCities(state)
          : this.usCities.map((c) => c.name).slice()
      )
    );
  }

  filterCities(name: string) {
    let results = this.usCities
      .map((c) => c.name)
      .filter((city) => city.toLowerCase().indexOf(name.toLowerCase()) === 0);

    if (results.length < 1) {
      results = [this.question + name + '"?'];
    }

    return results;
  }

  optionSelected(option) {
    if (option.value.indexOf(this.question) === 0) {
      const newCityName = option.value
        .substring(this.question.length)
        .split('"?')[0];
      const newCity = {} as UsCity;
      newCity.name = newCityName;
      this.usCities.push(newCity);
      this.editArtistAboutForm.controls.homeUsCity.setValue(newCityName);
    }
  }

  enterNewCity() {
    const newCityName = this.editArtistAboutForm.controls.homeUsCity.value;
    if (
      !this.usCities.map((c) => c.name).some((entry) => entry === newCityName)
    ) {
      const newCity = {} as UsCity;
      newCity.name = newCityName;
      this.usCities.push(newCity);
      this.editArtistAboutForm.controls.homeUsCity.setValue(newCityName);
    }
  }
}

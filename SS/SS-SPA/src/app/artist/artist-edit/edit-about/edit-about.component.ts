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
import { UsCity } from 'src/app/_models/usCity';
import { UsZipCode } from 'src/app/_models/usZipCode';

interface ArtistForm {
  name: string;
  usHomeCountry: boolean;
  homeCountryId: number;
  homeUsState: UsState;
  homeWorldRegion: any;
  homeUsCity: UsCity;
  homeUsZipCode: UsZipCode;
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
    homeUsCity: new FormControl({ value: '', disabled: true }),
    homeUsZipCode: new FormControl({ value: '', disabled: true }),
    //
    homeWorldRegion: new FormControl(),
  });

  controls = this.editArtistAboutForm.controls;

  usStates: UsState[];
  usCities: UsCity[] = [];
  usZipCodes: UsZipCode[] = [];
  filteredCities: Observable<any[]>;
  filteredZipCodes: Observable<any[]>;
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
    this.usZipCodeFilterPipe();
  }

  updateArtist() {
    // console.log(this.artist);
    this.setArtistValues();
    console.log(this.artist);

    this.artistService.Save(this.artist).subscribe(
      (next) => {
        this.alertify.success('Artist updated successfully');
        this.editArtistAboutForm.reset(this.artist);
        this.router.navigate(['/artist', this.artist.id]);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
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
    const a = this.artist;
    a.homeCountryId = 1;
    a.homeWorldRegionId = null;
    a.homeWorldCityId = null;
  }

  setNonUSArtist(f: ArtistForm) {
    const a = this.artist;
    a.homeCountryId = 2;
    a.homeUsState = null;
    a.homeUsCity = null;
    a.homeUsZipCode = null;
  }

  usRadioChange(bool) {
    this._utility.update({ usCountry: bool.value });
  }

  changeUSState() {
    const newStateId = this.controls.homeUsState.value;
    this.artist.homeUsStateId = newStateId;

    this.controls.homeUsCity.patchValue('');
    if (this.controls.homeUsZipCode) {
      this.controls.homeUsZipCode.patchValue('');
      this.controls.homeUsZipCode.disable();
    }

    this._artist.update({ artist: this.artist });

    this.getUSStateCities();
  }

  watchArtist() {
    this._artist.artist$
      .pipe(distinctUntilChanged())
      .subscribe((artist: Artist) => {
        this.artist = artist;
        if (this.artist.homeUsStateId) {
          this.controls.homeUsCity.enable();
          this.getUSStateCities();
          if (this.artist.homeUsCityId) {
            this.controls.homeUsZipCode.enable();
            this.getUSCityZipCodes();
          }
        } else {
          this._utility.update({ usCities: null });
          this._utility.update({ usZipCodes: null });
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
          this.controls.homeUsCity.enable();
          const city = this.usCities.find(
            (c) => c.id === this.artist.homeUsCityId
          );
          if (city) {
            this.controls.homeUsCity.patchValue(city.name);
          }
        } else {
          this.usCities = [];
        }
      });

    this._utility.usZipCodes$
      .pipe(distinctUntilChanged())
      .subscribe((zipCodes: UsZipCode[]) => {
        if (zipCodes) {
          this.usZipCodes = zipCodes;
          this.controls.homeUsZipCode.enable();
          const zip = this.usZipCodes.find(
            (z) => z.id === this.artist.homeUsZipCodeId
          );
          if (zip) {
            this.controls.homeUsZipCode.patchValue(zip.zipCode);
          }
        } else {
          this.usZipCodes = [];
        }
      });
  }

  getUsStates() {
    this._utilityApi.ListUsStates().subscribe((usStates: UsState[]) => {
      this._utility.update({ usStates });
    });
  }

  getUSStateCities() {
    this._utilityApi
      .ListUSStateCities(this.artist.homeUsStateId)
      .subscribe((usCities: UsCity[]) => {
        this._utility.update({ usCities });
      });
  }

  getUSCityZipCodes() {
    this._utilityApi
      .ListUSZipCodes(this.artist.homeUsCityId)
      .subscribe((usZipCodes: UsZipCode[]) => {
        this._utility.update({ usZipCodes });
      });
  }

  setArtistForm() {
    this.controls.name.patchValue(this.artist.name);
    if (this.artist.homeCountryId === 1) {
      this.controls.usHomeCountry.patchValue(true);
      this.controls.homeUsState.patchValue(this.artist.homeUsStateId);
    } else {
      this.controls.usHomeCountry.patchValue(false);
    }
  }

  // better name for this?
  usCityFilterPipe() {
    this.filteredCities = this.controls.homeUsCity.valueChanges.pipe(
      debounceTime(500),
      startWith(''),
      map((cityName: string) =>
        cityName
          ? this.filterCities(cityName)
          : this.usCities.map((c) => c.name).slice()
      )
    );
  }

  // better name for this?
  usZipCodeFilterPipe() {
    this.filteredZipCodes = this.controls.homeUsZipCode.valueChanges.pipe(
      debounceTime(500),
      startWith(''),
      map((zipCodeDigits: string) =>
        zipCodeDigits
          ? this.filterZipCodes(zipCodeDigits)
          : this.usZipCodes.map((z) => z.zipCode).slice()
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

  filterZipCodes(name: string) {
    let results = this.usZipCodes
      .map((z) => z.zipCode)
      .filter(
        (zipCode) => zipCode.toLowerCase().indexOf(name.toLowerCase()) === 0
      );

    if (results.length < 1) {
      results = [this.question + name + '"?'];
    }

    return results;
  }

  citySelected(option) {
    if (option.value.indexOf(this.question) === 0) {
      const newCityName: string = option.value
        .substring(this.question.length)
        .split('"?')[0];
      this.setUsCityFormField(newCityName);
    } else {
      this.updateArtistUsCityId(option.value);
    }
  }

  citySelectOnEnterKey() {
    const cityName: string = this.controls.homeUsCity.value;
    if (!this.usCities.map((c) => c.name).some((entry) => entry === cityName)) {
      this.setUsCityFormField(cityName);
    } else {
      this.updateArtistUsCityId(cityName);
    }
  }

  updateArtistUsCityId(cityName) {
    const city = this.usCities.find((c) => c.name === cityName);
    if (city) {
      this.artist.homeUsCityId = city.id;
    }
  }

  setUsCityFormField(newCityName: string) {
    const newCity = {} as UsCity;
    newCity.name = newCityName;
    this.usCities.push(newCity);
    this.controls.homeUsCity.setValue(newCityName);
    this.controls.homeUsZipCode.setValue(null);
    this.artist.homeUsStateId = null;
    this.artist.homeUsZipCodeId = null;
  }

  loadZipCodesForCity(value: string) {
    if (value) {
      const city = this.usCities.find((c) => c.name === value);
      if (city) {
        this.artist.homeUsCityId = city.id;
        this.controls.homeUsZipCode.enable();
        this.getUSCityZipCodes();
      }
    }
  }

  zipCodeSelected(option) {
    if (option.value.indexOf(this.question) === 0) {
      const newZipCodeDigits: string = option.value
        .substring(this.question.length)
        .split('"?')[0];
      this.setUsZipCodeFormField(newZipCodeDigits);
    } else {
      this.updateArtistUsZipCodeId(option.value);
    }
  }

  zipCodeSelectOnEnterKey() {
    const zipCodeDigits: string = this.controls.homeUsZipCode.value;
    if (
      !this.usZipCodes
        .map((z) => z.zipCode)
        .some((entry) => entry === zipCodeDigits)
    ) {
      this.setUsZipCodeFormField(zipCodeDigits);
    } else {
      this.updateArtistUsZipCodeId(zipCodeDigits);
    }
  }

  updateArtistUsZipCodeId(zipCodeDigits) {
    const zipCode = this.usZipCodes.find((z) => z.zipCode === zipCodeDigits);
    if (zipCode) {
      this.artist.homeUsZipCodeId = zipCode.id;
    }
  }

  setUsZipCodeFormField(newZipCodeDigits: string) {
    const newZipCode = {} as UsZipCode;
    newZipCode.zipCode = newZipCodeDigits;
    this.usZipCodes.push(newZipCode);
    this.controls.homeUsZipCode.setValue(newZipCodeDigits);
    this.artist.homeUsZipCodeId = null;
  }
}

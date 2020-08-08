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

@Component({
  selector: 'app-edit-about',
  templateUrl: './edit-about.component.html',
  styleUrls: ['./edit-about.component.css'],
})
export class EditAboutComponent implements OnInit {
  artist: Artist;
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
    private fb: FormBuilder,
    private _artist: ArtistService,
    private _utility: UtilityService
  ) {}

  ngOnInit() {
    this.watchArtist();
    this.watchUtilities();
    this.setArtistForm();
    this.usCityFilterPipe();
    this.usZipCodeFilterPipe();
  }

  watchArtist() {
    this._artist.artist$
      .pipe(distinctUntilChanged())
      .subscribe((artist: Artist) => {
        this.artist = artist;
        if (this.artist.homeUsStateId) {
          this.setArtist();
        } else {
          this._utility.update({ usCities: null, usZipCodes: null });
        }
      });
  }

  watchUtilities() {
    this._utility.usStates$
      .pipe(distinctUntilChanged())
      .subscribe((states: UsState[]) => {
        this.usStates = states;
      });

    this._utility.usCities$
      .pipe(distinctUntilChanged())
      .subscribe((usCities: UsCity[]) => {
        this.usCities = usCities;
        if (usCities) {
          this.setHomeCity();
        } else {
          this.usCities = [];
        }
      });

    this._utility.usZipCodes$
      .pipe(distinctUntilChanged())
      .subscribe((zipCodes: UsZipCode[]) => {
        this.usZipCodes = zipCodes;
        if (zipCodes) {
          this.setZipCode();
        } else {
          this.usZipCodes = [];
        }
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

  private setArtist() {
    this.controls.homeUsCity.enable();
    this.getUSStateCities();
    if (this.artist.homeUsCityId) {
      this.controls.homeUsZipCode.enable();
      this.getUSCityZipCodes();
    }
  }

  private setHomeCity() {
    this.controls.homeUsCity.enable();
    const city = this.usCities.find((c) => c.id === this.artist.homeUsCityId);
    if (city) {
      this.controls.homeUsCity.patchValue(city.name);
      this.artist.homeUsCity = city;
    }
  }

  private setZipCode() {
    this.controls.homeUsZipCode.enable();
    const zip = this.usZipCodes.find(
      (z) => z.id === this.artist.homeUsZipCodeId
    );
    if (zip) {
      this.controls.homeUsZipCode.patchValue(zip.zipCode);
      this.artist.homeUsZipCode = zip;
    }
  }

  //
  updateArtist() {
    const f = this.editArtistAboutForm.value;
    this._artist.readyArtistForSave(f, this.artist);
    this._artist.saveArtist(this.artist);
  }

  usRadioChange(bool) {
    this._utility.update({ usCountry: bool.value });
  }

  changeUSState() {
    const newStateId = this.controls.homeUsState.value;
    this.artist.homeUsStateId = newStateId;
    this.controls.homeUsCity.patchValue('');
    this.controls.homeUsZipCode.patchValue('');
    this.controls.homeUsZipCode.disable();
    this._artist.update({ artist: this.artist });
    this.getUSStateCities();
  }

  filterCities(cityName: string) {
    let results = this.usCities
      .map((c) => c.name)
      .filter(
        (city) => city.toLowerCase().indexOf(cityName.toLowerCase()) === 0
      );

    if (results.length < 1) {
      results = [this.question + cityName + '"?'];
    }

    return results;
  }

  filterZipCodes(zipCodeDigits: string) {
    let results = this.usZipCodes
      .map((z) => z.zipCode)
      .filter(
        (zipCode) =>
          zipCode.toLowerCase().indexOf(zipCodeDigits.toLowerCase()) === 0
      );

    if (results.length < 1) {
      results = [this.question + zipCodeDigits + '"?'];
    }

    return results;
  }

  // Cities
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
      this.artist.homeUsCity = city;
    }
  }

  setUsCityFormField(newCityName: string) {
    const newCity = {} as UsCity;
    newCity.name = newCityName;
    this.usCities.push(newCity);
    this.controls.homeUsCity.patchValue(newCityName);
    this.controls.homeUsZipCode.patchValue(null);
    this.artist.homeUsCityId = null;
    this.artist.homeUsZipCodeId = null;
  }

  // ZipCodes
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
      this.artist.homeUsZipCode = zipCode;
    }
  }

  setUsZipCodeFormField(newZipCodeDigits: string) {
    const newZipCode = {} as UsZipCode;
    newZipCode.zipCode = newZipCodeDigits;
    this.usZipCodes.push(newZipCode);
    this.controls.homeUsZipCode.patchValue(newZipCodeDigits);
    this.artist.homeUsZipCodeId = null;
  }

  // API Calls
  getUSStateCities() {
    this._artist.getUSStateCities(this.artist.homeUsStateId);
  }

  getUSCityZipCodes() {
    this._artist.getUSCityZipCodes(this.artist.homeUsCityId);
  }
}

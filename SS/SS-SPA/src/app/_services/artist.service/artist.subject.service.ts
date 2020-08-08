import { ArtistApiService } from './artist.api.service';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject, Subscription } from 'rxjs';
import { distinctUntilChanged, map, filter } from 'rxjs/operators';
import { Artist, ArtistForm } from 'src/app/_models/artist';
import { PaginatedResult } from 'src/app/_models/pagination';
import { UtilityApiService } from '../utility.service/utility.api.service';
import { UsCity, initUsCity } from 'src/app/_models/usCity';
import { UsZipCode, initUsZipCode } from 'src/app/_models/usZipCode';
import { Router } from '@angular/router';
import { AlertifyService } from '../alertify.service/alertify.service';
import { UtilityService } from '../utility.service/utility.subject.service';

export interface Artists {
  artist: Artist;
  artistList: PaginatedResult<Artist[]>;
}

let _state: Artists = {
  artist: null,
  artistList: null,
};

@Injectable({
  providedIn: 'root',
})
export class ArtistService {
  private store = new BehaviorSubject<Artists>(_state);
  private state$ = this.store.asObservable();

  artist$ = this.state$.pipe(
    map((state) => state.artist),
    distinctUntilChanged()
  );
  artistList$ = this.state$.pipe(
    map((state) => state.artistList),
    distinctUntilChanged()
  );

  constructor(
    private _alertify: AlertifyService,
    private _artistApi: ArtistApiService,
    private _router: Router,
    private _utility: UtilityService,
    private _utilityApi: UtilityApiService
  ) {}

  public update(state: any) {
    // console.log('ArtistService Updating', state);
    this.updateState({ ..._state, ...state });
  }

  private updateState(state: Artists) {
    this.store.next((_state = state));
  }

  getUSStateCities(homeUsStateId: number) {
    this._utilityApi
      .ListUSStateCities(homeUsStateId)
      .subscribe((usCities: UsCity[]) => {
        this._utility.update({ usCities });
      });
  }

  getUSCityZipCodes(homeUsCityId: number) {
    this._utilityApi
      .ListUSZipCodes(homeUsCityId)
      .subscribe((usZipCodes: UsZipCode[]) => {
        this._utility.update({ usZipCodes });
      });
  }

  readyArtistForSave(f: ArtistForm, artist: Artist) {
    artist.name = f.name;
    if (f.usHomeCountry) {
      this.setUSArtist(f, artist);
    } else {
      this.setNonUSArtist(f, artist);
    }
  }

  saveArtist(artist: Artist) {
    this._artistApi.Save(artist).subscribe(
      (next) => {
        this._alertify.success('Artist updated successfully');
        // // this.editArtistAboutForm.reset(this.artist);
        this.update({ artist });
        this._router.navigate(['/artist', artist.id]);
      },
      (error) => {
        this._alertify.error(error);
      }
    );
  }

  private setUSArtist(f: ArtistForm, toSet: Artist) {
    const a = toSet;
    a.homeUsState = f.homeUsState;
    this.cityDiffent(f, a);
    this.zipCodeDiffent(f, a);

    a.homeCountryId = 1;
    a.homeWorldRegionId = null;
    a.homeWorldCityId = null;
  }

  private setNonUSArtist(f: ArtistForm, toSet: Artist) {
    const a = toSet;
    a.homeCountryId = 2;
    a.homeUsState = null;
    a.homeUsCity = null;
    a.homeUsZipCode = null;
  }

  private cityDiffent(f: ArtistForm, a: Artist) {
    if (a.homeUsCity) {
      if (a.homeUsCity.name.localeCompare(f.homeUsCity)) {
        a.homeUsCity = initUsCity();
        a.homeUsCityId = null;
        a.homeUsZipCode = initUsZipCode();
        f.homeUsZipCode = null;
        a.homeUsZipCodeId = -1;
      }
    } else {
      a.homeUsCity = initUsCity();
    }
    a.homeUsCity.name = f.homeUsCity;
  }

  private zipCodeDiffent(f: ArtistForm, a: Artist) {
    if (a.homeUsZipCode) {
      if (a.homeUsZipCode.zipCode.localeCompare(f.homeUsZipCode)) {
        a.homeUsZipCodeId = null;
        a.homeUsZipCode = initUsZipCode();
      }
    } else {
      a.homeUsZipCode = initUsZipCode();
    }
    a.homeUsZipCode.zipCode = f.homeUsZipCode;
  }
}

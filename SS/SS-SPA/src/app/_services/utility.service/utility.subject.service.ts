import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { distinctUntilChanged, map } from 'rxjs/operators';
import { Country } from 'src/app/_models/country';
import { UsState } from 'src/app/_models/usState';
import { UsCity } from 'src/app/_models/usCity';
import { UsZipCode } from 'src/app/_models/usZipCode';

export interface Utilities {
  usCountry: boolean;
  countries: Country[];
  usStates: UsState[];
  usCities: UsCity[];
  usZipCodes: UsZipCode[];
}

let _state: Utilities = {
  usCountry: true,
  countries: null,
  usStates: null,
  usCities: null,
  usZipCodes: null,
};

@Injectable({
  providedIn: 'root',
})
export class UtilityService {
  private store = new BehaviorSubject<Utilities>(_state);
  private state$ = this.store.asObservable();

  usCountry$ = this.state$.pipe(
    map((state) => state.usCountry),
    distinctUntilChanged()
  );
  countries$ = this.state$.pipe(
    map((state) => state.countries),
    distinctUntilChanged()
  );
  usStates$ = this.state$.pipe(
    map((state) => state.usStates),
    distinctUntilChanged()
  );
  usCities$ = this.state$.pipe(
    map((state) => state.usCities),
    distinctUntilChanged()
  );
  usZipCodes$ = this.state$.pipe(
    map((state) => state.usZipCodes),
    distinctUntilChanged()
  );

  constructor() {}

  public update(state: any) {
    // console.log('UtilityService Updating', state);
    this.updateState({ ..._state, ...state });
  }

  private updateState(state: Utilities) {
    this.store.next((_state = state));
  }
}

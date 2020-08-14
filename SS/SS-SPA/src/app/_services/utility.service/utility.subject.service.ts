import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { distinctUntilChanged, map } from 'rxjs/operators';
import { Country } from 'src/app/_models/country';
import { UsState } from 'src/app/_models/usState';
import { UsCity } from 'src/app/_models/usCity';
import { UsZipCode } from 'src/app/_models/usZipCode';

export interface Utilities {
  countries: Country[];
  usStates: UsState[];
  usCities: UsCity[];
  usZipCodes: UsZipCode[];
  artistHome: {
    usCities: UsCity[];
    usZipCodes: UsZipCode[];
  };
}

let _state: Utilities = {
  countries: null,
  usStates: null,
  usCities: null,
  usZipCodes: null,
  artistHome: null,
};

@Injectable({
  providedIn: 'root',
})
export class UtilityService {
  private store = new BehaviorSubject<Utilities>(_state);
  private state$ = this.store.asObservable();

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
  artistHome$ = this.state$.pipe(
    map((state) => state.artistHome),
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

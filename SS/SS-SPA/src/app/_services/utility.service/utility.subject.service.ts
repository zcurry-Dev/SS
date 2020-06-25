import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { distinctUntilChanged, map } from 'rxjs/operators';
import { Country } from 'src/app/_models/country';
import { UsState } from 'src/app/_models/usState';

export interface Utilities {
  countries: Country[];
  usStates: UsState[];
}

let _state: Utilities = {
  countries: null,
  usStates: null,
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

  constructor() {}

  public update(state: any) {
    // console.log('UtilityService Updating', state);
    this.updateState({ ..._state, ...state });
  }

  private updateState(state: Utilities) {
    this.store.next((_state = state));
  }
}

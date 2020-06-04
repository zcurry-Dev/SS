import { ArtistApiService } from './artist.api.service';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject, Subscription } from 'rxjs';
import { distinctUntilChanged, map, filter } from 'rxjs/operators';
import { Artist } from 'src/app/_models/artist';
import { PaginatedResult } from 'src/app/_models/pagination';

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

  constructor(private artistApiService: ArtistApiService) {}

  public update(state: any) {
    // console.log('ArtistService Updating', state);
    this.updateState({ ..._state, ...state });
  }

  private updateState(state: Artists) {
    this.store.next((_state = state));
  }
}

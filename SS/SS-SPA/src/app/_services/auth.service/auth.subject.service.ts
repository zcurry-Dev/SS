import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';

export interface Auth {
  decodedToken: any;
  jwtHelper: JwtHelperService;
}

let _state: Auth = {
  decodedToken: '',
  jwtHelper: new JwtHelperService(),
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private store = new BehaviorSubject<Auth>(_state);
  private state$ = this.store.asObservable();

  decodedToken$ = this.state$.pipe(
    map((state) => state.decodedToken),
    distinctUntilChanged()
  );
  jwtHelper$ = this.state$.pipe(
    map((state) => state.jwtHelper),
    distinctUntilChanged()
  );

  constructor() {}

  public update(state: any) {
    console.log('AuthService Updating', state);
    this.updateState({ ..._state, ...state });
  }

  private updateState(state: Auth) {
    this.store.next((_state = state));
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.store.value.jwtHelper.isTokenExpired(token);
  }

  roleMatch(allowedRoles): boolean {
    let isMatch = false;
    const userRoles = this.store.value.decodedToken.role as Array<string>;

    if (!userRoles) {
      return isMatch;
    }

    allowedRoles.forEach((element) => {
      if (userRoles.includes(element)) {
        isMatch = true;
        return;
      }
    });
    return isMatch;
  }

  decodeToken(token: any) {
    return this.store.value.jwtHelper.decodeToken(token);
  }

  returnDecodedToken() {
    return this.store.value.decodedToken;
  }
}

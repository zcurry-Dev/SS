import { SafeUrl } from '@angular/platform-browser';
import { Country } from './country';
import { UsState } from './usState';
import { UsCity } from './usCity';
import { UsZipCode } from './usZipCode';

export interface Artist {
  id: number;
  name: string;
  statusId: number;
  yearsActive: number;
  artistGroup: boolean;
  userId?: number;
  verified: boolean;
  usArtist: boolean;
  //
  currentLoc: ArtistLocation;
  //
  homeCountryId: number;
  homeCountry: Country;
  homeCity: string;
  homeUsStateId: number;
  homeUsState: UsState;
  homeUsCityId: number;
  homeUsCity: UsCity;
  homeUsZipCodeId: number;
  homeUsZipCode: UsZipCode;
  homeWorldRegionId: number;
  homeWorldCityId: number;
  currentCountryId: number;
  currentCityId: number;
  currentCity: string;
  mainPhotoURL: SafeUrl;
  careerBeginDate: Date;
  careerEndDate: Date;
  createdBy: number;
  createdDate: Date;
}

// export function initArtist(): Artist {
//   return {
//     id: -1,
//     name: null,
//   };
// }

export class Artist {
  public constructor(init?: Partial<Artist>) {
    Object.assign(this, init);
  }
}

export interface ArtistForm {
  name: string;
  usHomeCountry: boolean;
  homeCountryId: number;
  homeUsState: UsState;
  homeWorldRegion: any;
  homeUsCity: string;
  homeUsZipCode: string;
}

interface ArtistLocation {
  countryId: number;
  country: Country;
  city: string;
  usStateId: number;
  usState: UsState;
  usCityId: number;
  usCity: UsCity;
  usZipCodeId: number;
  usZipCode: UsZipCode;
}

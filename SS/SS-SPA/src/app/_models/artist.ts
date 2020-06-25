import { SafeUrl } from '@angular/platform-browser';
import { Country } from './country';

export interface Artist {
  id: number;
  name: string;
  statusId: number;
  yearsActive: number;
  artistGroup: boolean;
  userId?: number;
  verified: boolean;
  homeCountry: Country;
  homeCountryId: number;
  homeStateId: number;
  homeCityId: string;
  homeCity: string;
  currentCountryId: number;
  currentCityId: number;
  currentCity: string;
  mainPhotoId: number;
  mainPhotoURL: SafeUrl;
  usArtist: boolean;
  careerBeginDate: Date;
  createdBy: number;
  createdDate: Date;
}

// export function initArtist(): Artist {
//   return {
//     id: -1,
//     name: null,
//     statusId: -1,
//     yearsActive: -1,
//     artistGroup: false,
//     userId: -1,
//     verified: false,
//     homeCountryId: -1,
//     homeStateId: -1,
//     homeCityId: null,
//     homeCity: null,
//     currentCountryId: -1,
//     currentCityId: -1,
//     currentCity: null,
//     mainPhotoId: -1,
//     mainPhotoURL: null,
//     usArtist: false,
//     careerBeginDate: new Date(),
//     createdBy: -1,
//     createdDate: new Date(),
//   };
// }

export class Artist {
  public constructor(init?: Partial<Artist>) {
    Object.assign(this, init);
  }
}

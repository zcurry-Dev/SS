import { SafeUrl } from '@angular/platform-browser';

export interface Artist {
  id: number;
  name: string;
  statusId: number;
  yearsActive: number;
  artistGroup: boolean;
  userId?: number;
  verified: boolean;
  homeCountryId: number;
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

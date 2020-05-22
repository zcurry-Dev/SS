import { ArtistPhoto } from './artistPhoto';
import { SafeUrl } from '@angular/platform-browser';

export interface Artist {
  id: number;
  name: string;
  statusId: number;
  yearsActive: number;
  artistGroup: boolean;
  userId?: number;
  verified: boolean;
  currentCity: string;
  homeCity: string;
  mainPhotoId: number;
  mainPhotoURL: SafeUrl;

  careerBeginDate: Date;
  createdBy: number;
  createdDate: Date;
  photos?: ArtistPhoto[];
}

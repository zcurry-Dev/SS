import { ArtistPhoto } from './artistPhoto';
import { SafeUrl } from '@angular/platform-browser';

export interface Artist {
  id: number;
  name: string;
  statusId: number;
  yearsActive: number;
  solo: boolean;
  userId?: number;
  verified: boolean;
  currentCity: string;
  homeCity: string;
  photoId: number;
  mainPhotoURL: SafeUrl;

  careerBeginDate: Date;
  createdBy: number;
  createdDate: Date;
  photos?: ArtistPhoto[];
}

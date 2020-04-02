import { ArtistPhoto } from './artistPhoto';

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
  photoUrl: string;

  careerBeginDate: Date;
  createdBy: number;
  createdDate: Date;
  photos?: ArtistPhoto[];
}

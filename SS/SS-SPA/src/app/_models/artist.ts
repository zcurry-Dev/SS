import { ArtistPhoto } from './artistPhoto';

export interface Artist {
  artistId: number;
  artistName: string;
  statusId: number;
  yearsActive: number;
  solo: boolean;
  userId?: number;
  verified: boolean;
  photoUrl: string;

  careerBeginDate: Date;
  createdBy: number;
  createdDate: Date;
  photos?: ArtistPhoto[];
}

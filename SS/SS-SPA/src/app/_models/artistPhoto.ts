import { SafeUrl } from '@angular/platform-browser';

export interface ArtistPhoto {
  id: number;
  description: string;
  dateAdded: Date;
  isMain: boolean;
  photoURL: SafeUrl;
}

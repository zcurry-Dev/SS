import { Injectable, SecurityContext } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root',
})
export class ImageService {
  constructor(
    private httpClient: HttpClient,
    private sanitizer: DomSanitizer
  ) {}

  getImage(imageUrl: string): Observable<Blob> {
    return this.httpClient.get(imageUrl, { responseType: 'blob' });
  }

  sanitizeImage(image): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl(URL.createObjectURL(image));
  }

  sanitizeSecurityContextURL(image): string {
    return this.sanitizer.sanitize(
      SecurityContext.URL,
      this.sanitizer.bypassSecurityTrustUrl(URL.createObjectURL(image))
    );
  }
}

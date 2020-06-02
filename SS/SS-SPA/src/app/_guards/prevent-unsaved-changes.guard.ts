import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { ArtistEditComponent } from '../artist/artist-edit/artist-edit.component';

@Injectable()
export class PreventUnsavedChanges
  implements CanDeactivate<ArtistEditComponent> {
  canDeactivate(component: ArtistEditComponent) {
    // if (component.editArtistForm.dirty) {
    //   return confirm(
    //     'Are you sure you want to continue? Any unsaved changes will be lost'
    //   );
    // }
    return true;
  }
}

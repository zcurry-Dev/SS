import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { EditAboutComponent } from '../artist/artist-edit/edit-about/edit-about.component';

@Injectable()
export class PreventUnsavedChanges
  implements CanDeactivate<EditAboutComponent> {
  canDeactivate(component: EditAboutComponent) {
    // if (component.editArtistAboutForm.dirty) {
    //   return confirm(
    //     'Are you sure you want to continue? Any unsaved changes will be lost'
    //   );
    // }
    return true;
  }
}

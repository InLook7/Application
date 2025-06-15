import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { CoworkingListItem } from '../../models/coworking-list-item.model';
import { ImageUrlService } from '../../../../shared/services/image-url.service';
import * as CoworkingSelectors from '../../store/coworking.selectors';
import * as CoworkingActions from '../../store/coworking.actions';

@Component({
  selector: 'app-coworking-list',
  imports: [
    CommonModule
  ],
  templateUrl: './coworking-list.component.html',
  styleUrl: './coworking-list.component.css'
})
export class CoworkingListComponent {
  coworkingListItems$: Observable<CoworkingListItem[]>;
  
  constructor(
    private store: Store,
    private router: Router,
    private imageUrlService: ImageUrlService,
  ) {
    this.coworkingListItems$ = this.store.select(CoworkingSelectors.selectCoworkingList);
  }

  ngOnInit() {
    this.store.dispatch(CoworkingActions.loadCoworkingList());
  }

  getImageUrl(path: string): string {
    return this.imageUrlService.getImageUrl(path);
  }

  goToWorkspaces(id: number) {
    this.router.navigate(['/coworkings', id, 'workspaces']);
  }
}

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { CoworkingListItem } from '../../models/coworking-list-item.model';
import { CoworkingApiService } from '../../../../shared/services/coworking-api.service';
import { ImageUrlService } from '../../../../shared/services/image-url.service';

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
    private router: Router,
    private coworkingApi: CoworkingApiService,
    private imageUrlService: ImageUrlService,
  ) {
    this.coworkingListItems$ = this.coworkingApi.getCoworkingList();
  }

  getImageUrl(path: string): string {
    return this.imageUrlService.getImageUrl(path);
  }

  goToWorkspaces(id: number) {
    this.router.navigate(['/coworkings', id, 'workspaces']);
  }
}

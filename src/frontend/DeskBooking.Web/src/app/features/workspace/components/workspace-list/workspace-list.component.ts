import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { map, Observable } from 'rxjs';

import { WorkspaceTypeListItem } from '../../models/workspace-type-list-item.model';
import { CapacityQuantityGroup } from '../../models/capacity-quantity-group.model';
import { BookingListItem } from '../../../booking/models/booking-list-item.model';
import { ImageUrlService } from '../../../../shared/services/image-url.service';
import { BookingApiService } from '../../../booking/services/booking-api.service';
import { CoworkingApiService } from '../../../../shared/services/coworking-api.service';
import { ButtonComponent } from '../../../../../stories/button/button.component';

@Component({
  selector: 'app-workspace-list',
  imports: [
    CommonModule,
    ButtonComponent
  ],
  templateUrl: './workspace-list.component.html',
  styleUrl: './workspace-list.component.css'
})
export class WorkspaceListComponent {
  workspaceTypeListItems$: Observable<WorkspaceTypeListItem[]>;
  booking$: Observable<BookingListItem>;
  selectedImages: { [id: string]: string } = {};

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private coworkingTypeApi: CoworkingApiService,
    private bookingApi: BookingApiService,
    private imageUrlService: ImageUrlService
  ) {
    const coworkingId = Number(this.route.snapshot.paramMap.get('id'));

    this.workspaceTypeListItems$ = this.coworkingTypeApi.getWorkspaceTypeList(coworkingId);

    this.booking$ = this.bookingApi.getBookingList().pipe(
      map(bookings => bookings[0])
    );
  }

  getImageUrl(path: string): string {
    return this.imageUrlService.getImageUrl(path);
  }

  selectImage(workspaceId: number, imagePath: string) {
    this.selectedImages[workspaceId] = imagePath;
  }

  getSelectedImage(workspace: WorkspaceTypeListItem): string {
    return this.selectedImages[workspace.id] || workspace.photoFilePaths[0];
  }

  getQuantity(capacities: CapacityQuantityGroup[]): number {
    return capacities.reduce((sum, group) => sum + group.quantity, 0);
  }

  getCapacityList(capacities: CapacityQuantityGroup[]): string {
    return capacities.map(c => c.capacity).join(', ');
  }

  goToCreate() {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.router.navigate(['/coworkings', id, 'workspaces', 'create-booking']);
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { map, Observable } from 'rxjs';

import { WorkspaceTypeListItem } from '../../models/workspace-type-list-item.model';
import { CapacityQuantityGroup } from '../../models/capacity-quantity-group.model';
import { BookingListItem } from '../../../booking/models/booking-list-item.model';
import { WorkspaceTypeApiService } from '../../../../shared/services/workspace-type-api.service';
import { ImageUrlService } from '../../../../shared/services/image-url.service';
import { BookingApiService } from '../../../booking/services/booking-api.service';

@Component({
  selector: 'app-workspace-list',
  imports: [
    CommonModule
  ],
  templateUrl: './workspace-list.component.html',
  styleUrl: './workspace-list.component.css'
})
export class WorkspaceListComponent {
  workspaceTypeListItems$: Observable<WorkspaceTypeListItem[]>;
  firstBooking$: Observable<BookingListItem>;
  selectedImages: { [id: string]: string } = {};

  constructor(
    private router: Router,
    private workspaceTypeApi: WorkspaceTypeApiService,
    private bookingApi: BookingApiService,
    private imageUrlService: ImageUrlService
  ) {
    this.workspaceTypeListItems$ = this.workspaceTypeApi.getWorkspaceTypeList();

    this.firstBooking$ = this.bookingApi.getBookingList().pipe(
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
    this.router.navigate(['/workspaces/create-booking']);
  }
}

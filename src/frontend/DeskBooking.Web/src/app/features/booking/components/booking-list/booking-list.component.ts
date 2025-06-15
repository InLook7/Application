import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';

import { BookingListItem } from '../../models/booking-list-item.model';
import { BookingApiService } from '../../services/booking-api.service';
import { ImageUrlService } from '../../../../shared/services/image-url.service';
import { CancelConfirmationModalComponent } from '../../../../shared/ui/modals/cancel-confirmation-modal/cancel-confirmation-modal.component';
import { TimeAmPmPipe } from '../../pipes/timeAmPm.pipe';
import { DateRangeDurationPipe } from '../../pipes/dateRangeDuration.pipe';
import { AskBookingAssistantResponse } from '../../../../shared/models/ask-booking-assistant-response';
import { AssistantApiService } from '../../../../shared/services/assistant-api.service';
import { AskBookingAssistantRequest } from '../../../../shared/models/ask-booking-assistant-request';

@Component({
  selector: 'app-booking-list',
  imports: [
    CommonModule,
    TimeAmPmPipe,
    DateRangeDurationPipe
  ],
  templateUrl: './booking-list.component.html',
  styleUrl: './booking-list.component.css'
})
export class BookingListComponent {
  bookingListItems$: Observable<BookingListItem[]>;
  assistantResponse$!: Observable<AskBookingAssistantResponse>;

  constructor(
    private router: Router,
    private dialog: MatDialog,
    private bookingApi: BookingApiService,
    private assistantApi: AssistantApiService,
    private imageUrlService: ImageUrlService,
  ) {
    this.bookingListItems$ = this.bookingApi.getBookingList();
  }

  getImageUrl(path: string): string {
    return this.imageUrlService.getImageUrl(path);
  }

  goToEdit(id: number) {
    this.router.navigate(['/bookings/edit', id]);
  }

  goToCancelConfirmationModal(id: number) {
    const dialogRef = this.dialog.open(CancelConfirmationModalComponent, {
      data: id 
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirmed') {
        this.bookingListItems$ = this.bookingApi.getBookingList();
      }
    });
  }

  goToWorkspaces() {
    this.router.navigate([""]);
  }

  askAssistant(question: string) {
    const request: AskBookingAssistantRequest = {
      question: question
    };

    this.assistantResponse$ = this.assistantApi.askBookingAssistant(request);
  }
}

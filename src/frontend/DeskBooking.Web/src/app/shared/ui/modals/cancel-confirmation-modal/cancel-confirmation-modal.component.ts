import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BookingApiService } from '../../../../features/booking/services/booking-api.service';

@Component({
  selector: 'app-cancel-confirmation-modal',
  imports: [],
  templateUrl: './cancel-confirmation-modal.component.html',
  styleUrl: './cancel-confirmation-modal.component.css'
})
export class CancelConfirmationModalComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: number,
    private dialogRef: MatDialogRef<CancelConfirmationModalComponent>,
    private bookingApi: BookingApiService,
  ) {}

  confirmDeletion() {
    this.bookingApi.deleteBooking(this.data).subscribe(() => {
      this.dialogRef.close('confirmed');
    });
  }
  
  closeModal() {
    this.dialogRef.close();
  }
}

import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

import { Booking } from '../../../models/booking.model';

@Component({
  selector: 'app-success-modal',
  imports: [
    CommonModule,
    MatIconModule
  ],
  templateUrl: './success-modal.component.html',
  styleUrl: './success-modal.component.css'
})
export class SuccessModalComponent {
  constructor(
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: Booking,
    private dialogRef: MatDialogRef<SuccessModalComponent>
  ) {}
  
  goToBookings() {
    this.closeModal();
    this.router.navigate(['/bookings']);
  }
  
  closeModal() {
    this.dialogRef.close();
  }
}

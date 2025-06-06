import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable, map, startWith, switchMap, tap } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';

import { Booking } from '../../../../shared/models/booking.model';
import { WorkspaceType } from '../../../../shared/models/workspace-type.model';
import { Workspace } from '../../../../shared/models/workspace.model';
import { BookingApiService } from '../../services/booking-api.service';
import { WorkspaceTypeApiService } from '../../../../shared/services/workspace-type-api.service';
import { SuccessModalComponent } from '../../../../shared/ui/modals/success-modal/success-modal.component';
import { ErrorModalComponent } from '../../../../shared/ui/modals/error-modal/error-modal.component';
import { TimeAmPmPipe } from '../../pipes/timeAmPm.pipe';

@Component({
  selector: 'app-booking-edit',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TimeAmPmPipe
  ],
  templateUrl: './booking-edit.component.html',
  styleUrl: './booking-edit.component.css'
})
export class BookingEditComponent {
  bookingForm: FormGroup;
  booking$: Observable<Booking>;
  workspaceTypes$: Observable<WorkspaceType[]>;
  workspaces$!: Observable<Workspace[]>; 

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private dialog: MatDialog,
    private bookingApi: BookingApiService,
    private workspaceTypeApi: WorkspaceTypeApiService
  ) {
    this.bookingForm = this.formBuilder.group({
      bookedByName: ['', Validators.required],
      bookedByEmail: ['', [Validators.required, Validators.email]],
      workspaceTypeId: ['', Validators.required],
      workspaceId: ['', Validators.required],
      startDate: this.formBuilder.group({
        day: ['', Validators.required],
        month: ['', Validators.required],
        year: ['', Validators.required],
      }),
      endDate: this.formBuilder.group({
        day: ['', Validators.required],
        month: ['', Validators.required],
        year: ['', Validators.required],
      }),
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
    });

    this.workspaceTypes$ = this.workspaceTypeApi.getWorkspaceTypes();

    this.booking$ = this.route.paramMap.pipe(
      map(params => Number(params.get('id'))),
      switchMap(id => this.bookingApi.getBookingById(id)),
      tap(booking => {
        this.bookingForm.patchValue({
          bookedByName: booking.bookedByName,
          bookedByEmail: booking.bookedByEmail,
          workspaceTypeId: booking.workspaceTypeId,
          workspaceId: booking.workspaceId,
          startTime: booking.startTime,
          endTime: booking.endTime,
          startDate: this.parseDate(booking.startDate),
          endDate: this.parseDate(booking.endDate)
        });

        this.workspaces$ = this.bookingForm.get('workspaceTypeId')!.valueChanges.pipe(
          startWith(this.bookingForm.get('workspaceTypeId')!.value),
          switchMap(id => this.workspaceTypeApi.getWorkspacesByWorkspaceTypeId(id))
        );
      })
    );
  }

  onSubmit(id: number) {
    const formValue = this.bookingForm.value;

    const booking: Booking = {
      id,
      bookedByName: formValue.bookedByName,
      bookedByEmail: formValue.bookedByEmail,
      workspaceTypeId: formValue.workspaceTypeId,
      workspaceId: formValue.workspaceId,
      startTime: formValue.startTime,
      endTime: formValue.endTime,
      startDate: this.buildDate(formValue.startDate),
      endDate: this.buildDate(formValue.endDate)
    };

    this.bookingApi.patchBooking(id, booking).subscribe({
      next: (result) => {
        this.dialog.open(SuccessModalComponent, {
          data: result
        });
      },
      error: (error) => {
        const messages = error.error.errors;

        this.dialog.open(ErrorModalComponent, {
          data: { messages }
        });
      }
    });
  }

  parseDate(dateStr: string) {
    const [year, month, day] = dateStr.split('-').map(Number);
    const monthName = this.months.find(m => m.value === month)?.name || '';
    return { day, month: monthName, year };
  }

  buildDate(dateGroup: any): string {
    const pad = (n: number) => n.toString().padStart(2, '0');
    const monthValue = this.months.find(m => m.name === dateGroup.month)?.value;
    return `${dateGroup.year}-${pad(monthValue!)}-${pad(dateGroup.day)}`;
  }

  cancel() {
    this.router.navigate(['/bookings']);
  }

  // data 
  times = ['13:30:00', '14:00:00', '14:30:00', '15:00:00', '15:30:00'];
  days = Array.from({ length: 31 }, (_, i) => i + 1);
  months = [
    { name: 'January', value: 1 },
    { name: 'February', value: 2 },
    { name: 'March', value: 3 },
    { name: 'April', value: 4 },
    { name: 'May', value: 5 },
    { name: 'June', value: 6 },
    { name: 'July', value: 7 },
    { name: 'August', value: 8 },
    { name: 'September', value: 9 },
    { name: 'October', value: 10 },
    { name: 'November', value: 11 },
    { name: 'December', value: 12 }
  ];
  years = [2024, 2025, 2026];
}

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Observable, startWith, switchMap } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';

import { CreateBookingRequest } from '../../models/create-booking-request';
import { WorkspaceType } from '../../../../shared/models/workspace-type.model';
import { Workspace } from '../../../../shared/models/workspace.model';
import { BookingApiService } from '../../services/booking-api.service';
import { WorkspaceTypeApiService } from '../../../../shared/services/workspace-type-api.service';
import { SuccessModalComponent } from '../../../../shared/ui/modals/success-modal/success-modal.component';
import { ErrorModalComponent } from '../../../../shared/ui/modals/error-modal/error-modal.component';
import { TimeAmPmPipe } from '../../pipes/timeAmPm.pipe';
import { CoworkingApiService } from '../../../../shared/services/coworking-api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-booking-create',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TimeAmPmPipe
  ],
  templateUrl: './booking-create.component.html',
  styleUrl: './booking-create.component.css'
})
export class BookingCreateComponent {
  bookingForm: FormGroup;
  workspaceTypes$: Observable<WorkspaceType[]>;
  workspaces$: Observable<Workspace[]>; 

  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private dialog: MatDialog,
    private bookingApi: BookingApiService,
    private workspaceTypeApi: WorkspaceTypeApiService,
    private coworkingApi: CoworkingApiService
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

    const coworkingId = Number(this.route.snapshot.paramMap.get('id'));
    this.workspaces$ = this.bookingForm.get('workspaceTypeId')!.valueChanges.pipe(
      switchMap(workspaceTypeid => this.coworkingApi.getWorkspaces(coworkingId, workspaceTypeid))
    );
  }

  onSubmit() {
    const formValue = this.bookingForm.value;

    const booking: CreateBookingRequest = {
      bookedByName: formValue.bookedByName,
      bookedByEmail: formValue.bookedByEmail,
      workspaceId: formValue.workspaceId,
      startDate: this.buildDate(formValue.startDate),
      endDate: this.buildDate(formValue.endDate),
      startTime: formValue.startTime,
      endTime: formValue.endTime,
    };

    this.bookingApi.createBooking(booking).subscribe({
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

  buildDate(dateGroup: any): string {
    const pad = (n: number) => n.toString().padStart(2, '0');
    const monthValue = this.months.find(m => m.name === dateGroup.month)?.value;
    return `${dateGroup.year}-${pad(monthValue!)}-${pad(dateGroup.day)}`;
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

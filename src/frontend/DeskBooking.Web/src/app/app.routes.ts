import { Routes } from '@angular/router';
import { provideState } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';

import { WorkspaceListComponent } from './features/workspace/components/workspace-list/workspace-list.component';
import { BookingListComponent } from './features/booking/components/booking-list/booking-list.component';
import { BookingEditComponent } from './features/booking/components/booking-edit/booking-edit.component';
import { BookingCreateComponent } from './features/booking/components/booking-create/booking-create.component';
import { CoworkingListComponent } from './features/coworking/components/coworking-list/coworking-list.component';
import { coworkingReducer } from './features/coworking/store/coworking.reducer';
import { bookingReducer } from './features/booking/store/booking.reducer';
import { CoworkingEffects } from './features/coworking/store/coworking.effects';
import { BookingEffects } from './features/booking/store/booking.effects';

export const routes: Routes = [
  { path: '', redirectTo: '/coworkings', pathMatch: 'full' },
  { 
    path: 'coworkings',
    providers: [
      provideState({ name: 'coworkings', reducer: coworkingReducer }),
      provideEffects(CoworkingEffects),
    ],
    children: [
      { path: '', component: CoworkingListComponent },
      { 
        path: ':id/workspaces',
        children: [
          { path: '', component: WorkspaceListComponent },
          { path: 'create-booking', component: BookingCreateComponent }
        ]
      }
    ]
  },
  {
    path: 'bookings',
    providers: [
      provideState({ name: 'bookings', reducer: bookingReducer }),
      provideEffects(BookingEffects),
    ],
    children: [
      { path: '', component: BookingListComponent },
      { path: 'edit/:id', component: BookingEditComponent }
    ]
  }
];

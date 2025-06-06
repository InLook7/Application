import { Routes } from '@angular/router';

import { WorkspaceListComponent } from './features/workspace/components/workspace-list/workspace-list.component';
import { BookingListComponent } from './features/booking/components/booking-list/booking-list.component';
import { BookingEditComponent } from './features/booking/components/booking-edit/booking-edit.component';
import { BookingCreateComponent } from './features/booking/components/booking-create/booking-create.component';

export const routes: Routes = [
  { path: '', redirectTo: '/workspaces', pathMatch: 'full' },
  { 
    path: 'workspaces',
    children: [
      { path: '', component: WorkspaceListComponent },
      { path: 'create-booking', component: BookingCreateComponent }
    ]
  },
  {
    path: 'bookings',
    children: [
      { path: '', component: BookingListComponent },
      { path: 'edit/:id', component: BookingEditComponent }
    ]
  }
];

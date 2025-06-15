import { createAction, props } from '@ngrx/store';

import { BookingListItem } from '../models/booking-list-item.model';

export const loadBookingList = createAction('[Booking] Load List');

export const loadBookingListSuccess = createAction(
  '[Booking] Load List Success',
  props<{ items: BookingListItem[] }>()
);

export const loadBookingListFailure = createAction(
  '[Booking] Load List Failure',
  props<{ error: any }>()
);
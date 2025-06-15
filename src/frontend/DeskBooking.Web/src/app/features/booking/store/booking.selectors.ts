import { createFeatureSelector, createSelector } from '@ngrx/store';

import { BookingState } from './booking.reducer';

export const selectBookingState = createFeatureSelector<BookingState>('bookings');

export const selectBookingList = createSelector(
  selectBookingState,
  (state) => state.list
);

export const selectBookingLoading = createSelector(
  selectBookingState,
  (state) => state.loading
);
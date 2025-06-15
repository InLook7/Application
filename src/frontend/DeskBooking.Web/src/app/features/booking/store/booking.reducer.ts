import { createReducer, on } from '@ngrx/store';

import { BookingListItem } from '../models/booking-list-item.model';
import * as BookingActions from './booking.actions';

export interface BookingState {
  list: BookingListItem[];
  loading: boolean;
  error: any;
}

export const initialState: BookingState = {
  list: [],
  loading: false,
  error: null,
};

export const bookingReducer = createReducer(
  initialState,
  on(BookingActions.loadBookingList, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(BookingActions.loadBookingListSuccess, (state, { items }) => ({
    ...state,
    list: items,
    loading: false,
  })),
  on(BookingActions.loadBookingListFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  }))
);
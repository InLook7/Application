import { Injectable, inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';

import { BookingApiService } from '../services/booking-api.service';
import * as BookingActions from './booking.actions';

@Injectable()
export class BookingEffects {
  private actions$ = inject(Actions);
  private api = inject(BookingApiService);

  loadBookingList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BookingActions.loadBookingList),
      mergeMap(() =>
        this.api.getBookingList().pipe(
          map(items => BookingActions.loadBookingListSuccess({ items })),
          catchError(error => of(BookingActions.loadBookingListFailure({ error })))
        )
      )
    )
  );
}
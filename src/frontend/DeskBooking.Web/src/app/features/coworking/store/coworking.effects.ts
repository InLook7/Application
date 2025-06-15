import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';

import { CoworkingApiService } from '../../../shared/services/coworking-api.service';
import * as CoworkingActions from './coworking.actions';

@Injectable()
export class CoworkingEffects {
  private actions$ = inject(Actions);
  private api = inject(CoworkingApiService);

  loadCoworkingList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoworkingActions.loadCoworkingList),
      mergeMap(() =>
        this.api.getCoworkingList().pipe(
          map(items => CoworkingActions.loadCoworkingListSuccess({ items })),
          catchError(error => of(CoworkingActions.loadCoworkingListFailure({ error })))
        )
      )
    )
  );
}
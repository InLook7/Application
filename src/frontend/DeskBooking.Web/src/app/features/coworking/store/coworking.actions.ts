import { createAction, props } from '@ngrx/store';

import { CoworkingListItem } from '../models/coworking-list-item.model';

export const loadCoworkingList = createAction('[Coworking] Load List');

export const loadCoworkingListSuccess = createAction(
  '[Coworking] Load List Success',
  props<{ items: CoworkingListItem[] }>()
);

export const loadCoworkingListFailure = createAction(
  '[Coworking] Load List Failure',
  props<{ error: any }>()
);
import { createReducer, on } from '@ngrx/store';

import { CoworkingListItem } from '../models/coworking-list-item.model';
import * as CoworkingActions from './coworking.actions';

export interface CoworkingState {
  list: CoworkingListItem[];
  loading: boolean;
  error: any;
}

const initialState: CoworkingState = {
  list: [],
  loading: false,
  error: null,
};

export const coworkingReducer = createReducer(
  initialState,
  on(CoworkingActions.loadCoworkingList, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(CoworkingActions.loadCoworkingListSuccess, (state, { items }) => ({
    ...state,
    list: items,
    loading: false,
  })),
  on(CoworkingActions.loadCoworkingListFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  }))
);
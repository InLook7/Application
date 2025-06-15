import { createFeatureSelector, createSelector } from '@ngrx/store';

import { CoworkingState } from './coworking.reducer';

export const selectCoworkingState = createFeatureSelector<CoworkingState>('coworkings');

export const selectCoworkingList = createSelector(
  selectCoworkingState,
  (state) => state.list
);

export const selectCoworkingLoading = createSelector(
  selectCoworkingState,
  (state) => state.loading
);
// src/redux/reducer.ts

import { State, CounterActionTypes } from './types';

const initialState: State = {
  count: 0
};

export function counterReducer(
  state = initialState,
  action: CounterActionTypes
): State {
  switch (action.type) {
    case 'INCREMENT':
      return { count: state.count + 1 };
    case 'DECREMENT':
      return { count: state.count - 1 };
    default:
      return state;
  }
}

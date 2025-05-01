import { IncrementAction, DecrementAction } from './types';

export const increment = (): IncrementAction => ({
  type: 'INCREMENT'
});

export const decrement = (): DecrementAction => ({
  type: 'DECREMENT'
});

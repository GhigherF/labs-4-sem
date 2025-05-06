import { IncrementAction, DecrementAction, Reset } from './types';

export const increment = (): IncrementAction => ({
  type: 'INCREMENT'
});

export const decrement = (): DecrementAction=> ({
  type: 'DECREMENT'
});

export const reset = ():Reset=>({
type:'RESET'
});

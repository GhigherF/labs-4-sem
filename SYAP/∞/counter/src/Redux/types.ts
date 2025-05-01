export interface State {
    count: number;
  }
  
  import { Action } from 'redux';

  export interface IncrementAction extends Action<'INCREMENT'> {}
  export interface DecrementAction extends Action<'DECREMENT'> {}
  
  export type CounterActionTypes = IncrementAction | DecrementAction;
  
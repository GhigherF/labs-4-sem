export interface State {
    count: number;
  }
  
  import { Action } from 'redux';

  export interface IncrementAction extends Action<'INCREMENT'> {}
  export interface DecrementAction extends Action<'DECREMENT'> {}
  export interface Reset extends Action<'RESET'>{}
  
  export type CounterActionTypes = IncrementAction | DecrementAction|Reset;
  
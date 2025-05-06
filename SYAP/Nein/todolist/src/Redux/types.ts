export interface Todo {
    id: number;
    text: string;
    completed: boolean;
  }
  
  // Типы действий
  export const ADD_TODO = 'ADD_TODO' as const;
  export const TOGGLE_TODO = 'TOGGLE_TODO' as const;
  export const EDIT_TODO = 'EDIT_TODO' as const;
  export const DELETE_TODO = 'DELETE_TODO' as const;
  
  export type ActionType =
    | { type: typeof ADD_TODO; payload: { text: string } }
    | { type: typeof TOGGLE_TODO; payload: { id: number } }
    | { type: typeof EDIT_TODO; payload: { id: number; text: string } }
    | { type: typeof DELETE_TODO; payload: { id: number } };
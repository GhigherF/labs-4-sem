// actions.ts
import { ADD_TODO, TOGGLE_TODO, EDIT_TODO, DELETE_TODO, ActionType } from './types';

export const addTodo = (text: string): ActionType => ({
  type: ADD_TODO,
  payload: { text }
});

export const toggleTodo = (id: number): ActionType => ({
  type: TOGGLE_TODO,
  payload: { id }
});

export const editTodo = (id: number, text: string): ActionType => ({
  type: EDIT_TODO,
  payload: { id, text }
});

export const deleteTodo = (id: number): ActionType => ({
  type: DELETE_TODO,
  payload: { id }
});

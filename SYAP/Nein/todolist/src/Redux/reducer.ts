// reducer.ts
import { Todo, ActionType, ADD_TODO, TOGGLE_TODO, EDIT_TODO, DELETE_TODO } from './types';

const initialState: Todo[] = [];
let nextId = 1;

export const todoReducer = (state = initialState, action: ActionType): Todo[] => {
  switch (action.type) {
    case ADD_TODO:
      return [
        ...state,
        {
          id: nextId++,
          text: action.payload.text,
          completed: false
        }
      ];
    case TOGGLE_TODO:
      return state.map(todo =>
        todo.id === action.payload.id
          ? { ...todo, completed: !todo.completed }
          : todo
      );
    case EDIT_TODO:
      return state.map(todo =>
        todo.id === action.payload.id
          ? { ...todo, text: action.payload.text }
          : todo
      );
    case DELETE_TODO:
      return state.filter(todo => todo.id !== action.payload.id);
    default:
      return state;
  }
};

export default todoReducer; 
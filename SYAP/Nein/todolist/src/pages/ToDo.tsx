import { useDispatch, useSelector } from "react-redux";
import { useState } from "react";
import { addTodo,toggleTodo,deleteTodo,editTodo} from "@/Redux/actions";
import {Todo} from "../Redux/types";

const ToDO = ({ todo, onEdit }: { todo: Todo, onEdit: (todo: Todo) => void }) => {
    const dispatch = useDispatch();
  
    const handleToggle = () => dispatch(toggleTodo(todo.id));
    const handleDelete = () => dispatch(deleteTodo(todo.id));
    const handleEdit = () => onEdit(todo);
  
    return (
      <div className="ml-[20px] w-[350px] bg-violet-500 rounded-[5px] text-white mb-[4px]">
        <div className="flex items-center me-4">
          <input
            checked={todo.completed}
            id={`checkbox-${todo.id}`}
            type="checkbox"
            onChange={handleToggle}
            className="collapse"
          />
          <label htmlFor={`checkbox-${todo.id}`} className="checkbox-label flex items-center cursor-pointer text-sm font-medium">
            <span
              className={`w-4 h-4 border-2 border-black rounded-sm  mr-3 flex justify-center items-center 
              ${todo.completed ? 'bg-green-500 ' : 'bg-transparent'}`}
            >
              {todo.completed && <span className="text-lg scale-70">✔</span>}
            </span>
            <span className={`${todo.completed ? "line-through" : ""} break-words whitespace-normal max-w-[160px]`}>
              {todo.text}
            </span>
          </label>
          <button
            onClick={handleDelete}
            className="bg-red-500 ml-[20px] w-[70px] h-[15px] text-[11px] rounded-[4px] hover:bg-red-400"
          >
            Удалить
          </button>
          <button
            onClick={handleEdit}
            className="bg-yellow-500 ml-[10px] w-[120px] h-[15px] text-[11px] rounded-[4px] hover:bg-yellow-300"
          >
            Редактировать
          </button>
        </div>
      </div>
    );
  };
  
  
 
  
  const ToDoList = () => {
    const dispatch = useDispatch();
    const todos = useSelector((state: Todo[]) => state);
    
    const [inputValue, setInputValue] = useState("");
    const [editingId, setEditingId] = useState<number | null>(null);
  
    const handleAddOrEdit = () => {
      if (!inputValue.trim()) return;
  
      if (editingId !== null) {
        dispatch(editTodo(editingId, inputValue));
        setEditingId(null);
      } else {
        dispatch(addTodo(inputValue));
      }
      setInputValue("");
    };
  
    const handleEditClick = (todo: Todo) => {
      setInputValue(todo.text);
      setEditingId(todo.id);
    };
  
    const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
      if (e.key === "Enter") handleAddOrEdit();
    };
  
    return (
      <div>
        <input
          value={inputValue}
          onChange={(e) => setInputValue(e.target.value)}
          onKeyDown={handleKeyDown}
          className="absolute left-[10px] w-[300px] top-[5px] rounded-[4px] h-[30px] bg-white text-black px-2"
        />
        <button
          className="bg-violet-500 text-white text-[30px] flex items-center justify-center absolute left-[320px] top-[5px] w-[60px] h-[30px] rounded-[4px] hover:bg-violet-400"
          onClick={handleAddOrEdit}
        >
          {editingId !== null ? "✓" : "+"}
        </button>
  
        <div className="absolute top-[45px]">
          {todos.map((todo: Todo) => (
            <ToDO key={todo.id} todo={todo} onEdit={handleEditClick} />
          ))}
        </div>
      </div>
    );
  };
  

export default ToDoList;

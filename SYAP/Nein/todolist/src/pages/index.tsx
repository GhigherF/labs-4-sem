import { Provider } from "react-redux";
import store from "../Redux/store"
import ToDoList  from "./ToDo";

export default function Home() {
  return (
       <Provider store={store}>
      <ToDoList/>
   </Provider>
  );
}

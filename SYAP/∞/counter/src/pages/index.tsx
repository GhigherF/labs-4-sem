import { Provider } from 'react-redux';
import { store } from '../Redux/store';
import Counter from '../pages/Counter'; 

export default function HomePage() {
  return (
    <Provider store={store}>
      <Counter />
    </Provider>
  );
}

import { useSelector, useDispatch } from 'react-redux';
import { increment, decrement } from '../Redux/actions';
import { RootState } from '../Redux/store';

const Counter = () => { 
  const count = useSelector((state: RootState) => state.count);
  const dispatch = useDispatch();

  return (
    <div>
      <h1>{count}</h1>
      <button onClick={() => dispatch(decrement())}>-</button>
      <button onClick={() => dispatch(increment())}>+</button>
    </div>
  );
};

export default Counter;

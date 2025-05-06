import { useSelector, useDispatch } from 'react-redux';
import { increment, decrement, reset } from '../Redux/actions';
import { RootState } from '../Redux/store';

const Counter = () => { 
  const count = useSelector((state: RootState) => state.count);
  const dispatch = useDispatch();

  return (
    <div>
      <h1 className="bg-violet-400 rounded-[7px] text-center  text-[22px] h-[30px] w-[126px]">{count}</h1>
      <button className="bg-violet-500 absolute left-[32px] top-[40px] w-[60px] h-[30px] rounded-[4px] hover:bg-violet-400"  onClick={() => dispatch(decrement())}>-</button>
      <button className="bg-violet-500 absolute left-[32px] top-[80px] w-[60px] h-[30px] rounded-[4px] hover:bg-violet-400" onClick={() => dispatch(increment())}>+</button>
      <button className="bg-violet-500 absolute left-[32px] top-[120px] w-[60px] h-[30px] rounded-[4px] hover:bg-violet-400" onClick={()=>dispatch(reset())}>RESET</button> 
    </div>
  );
};

export default Counter;

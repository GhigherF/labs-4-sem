import React from 'react';
import ReactDOM from 'react-dom/client';

import { useState } from 'react';

function Counter() 
{

  const [count, setCount] = useState(0);

  const Num = ({count})=>
  (
    <p className={count>=5?"stop":""}>{count}</p>
  );

const Button = ({title,func,disabled}) => 
(
<button onClick={func} disabled = {disabled}className="active">{title}</button>
);


return(
  <div>
<Num count = {count}/>
<Button title = "INC"  func = {() => setCount(count + 1)} disabled = {count >= 5}/>
<Button title = "reset"  func = {() => setCount(0)} disabled = {count == 0}/>
</div>
);

}

export default Counter;



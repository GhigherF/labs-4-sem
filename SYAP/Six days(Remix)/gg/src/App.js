import './App.css';
import * as Code from './code.js';
import { useState } from 'react';

export function App() {
  
    const Log=()=>
    (
        <label></label>
    );
const Button = ({ value}) => {  
    return (
      <button>
        {value} 
      </button>
    );
  };

  const NumTable = () => (
    <ul>
      <li>
        <Button value="1" />
        <Button value="2" />
        <Button value="3" />
      </li>
      <li>
        <Button value="4" />
        <Button value="5" />
        <Button value="6" />
      </li>
      <li>
        <Button value="7" />
        <Button value="8" />
        <Button value="9" />
      </li>
      <li>
        <Button value="0" />
        <Button value="C" func={() => Code.Clear()} />
        <Button value="=" func ={()=>Code.Equals()}/>
      </li>
    </ul>
  );

  const Display = () => (
    <input type="text"/>
  );

  const Calculations = () => (
    <ul className="calc">
      <li>
        <Button value="+" />
      </li>
      <li>
        <Button value="-"/>
      </li>
      <li>
        <Button value="*" />
      </li>
      <li>
        <Button value="/" />
      </li>
    </ul>
  );

  return (
    <div>
        <Log />
      <Display />
      <NumTable />
      <Calculations />
    </div>
  );
}

export default App;

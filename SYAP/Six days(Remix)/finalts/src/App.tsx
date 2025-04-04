export{}

import { Console } from 'console';
import './App.css';
import {Code} from "./Code";
import React, { useState, MouseEventHandler } from 'react';


function App() {

     let key=false;
  document.addEventListener('keydown', function(event) {
    if (event.key=="Enter")key=true;
  });
  document.addEventListener('keyup', function(event) {
    if (event.key=="Enter") 
      {
        key=false;
    Code.Calculus();
      }
   });
 

  const [theme,setTheme]=useState(false);
  const CSS=
  {
  divDark:`w-[410px] h-[500px] bg-gray-400 absolute top-[105px] left-[565px]`,
  divWhite:`w-[410px] h-[500px] bg-blue-200 absolute top-[105px] left-[565px]`,
   buttonWhite:`w-[100px] h-[100px] bg-white border-4 border-blue-300 border-solid`,
   font:`text-[50px]`,
   inputWhite:`w-[400px] h-[80px] border-4 border-blue-400 absolute top-[110px] left-[570px] bg-blue-500 `,
  
   buttonDark:`w-[100px] h-[100px] bg-black border-2 border-gray-300  border-solid text-white`,
   inputDark:`w-[400px] h-[80px] absolute top-[110px] left-[570px] bg-yellow-500 text-white border-4 border-black `,
   
   cntrlButtonDark:`w-[100px] h-[100px] bg-yellow-500 border-4 border-gray-300 border-solid`,
   cntrlButtonWhite:`w-[100px] h-[100px] bg-blue-500 border-4 border-blue-300 border-solid `
  }
  
  interface DigitButtonProps
  {
    value:string;
    func?: MouseEventHandler<HTMLButtonElement>;  
    digit:boolean;
  }
  
  const Button = ({ value, func, digit }: DigitButtonProps) => (
    <button
      className={`${theme && digit ? CSS.buttonWhite : !theme && digit ? CSS.buttonDark : theme && !digit ? CSS.cntrlButtonWhite : CSS.cntrlButtonDark}`}
      onClick={func ? func : () => Code.Digit(value)}
    >
      {value}
    </button>
  );
const ThemeButton=()=>
(
  <button className = {`bg-red-500 absolute top-[200px] left-[480px] w-[80px] h-[70px] rounded-[10px]`} onClick={()=>setTheme(!theme)}>Реальная тема</button>
);
const Phone=()=>
(
  <div  className={theme?CSS.divWhite:CSS.divDark}></div>
);
const History=()=>
(
  <p className={`absolute top-[100px] left-[1000px]`}>
      </p>
);
const Input=()=>
(
  <input className={theme?CSS.inputWhite+CSS.font:CSS.inputDark+CSS.font} 
  onChange={Code.Check} maxLength={14}></input>
);
const Body=()=>
(
<div className={`grid grid-cols-4 w-[400px] h-[400px] absolute top-[200px] left-[570px] ${CSS.font}`}> 
    <Button value="1" digit={true} />
    <Button value="2" digit={true} />
    <Button value="3"digit={true}/>
    <Button value="+" digit={false}/>
    <Button value="4" digit={true}/>
    <Button value="5" digit={true}/>
    <Button value="6" digit={true} />
    <Button value="-" digit={false}/>
    <Button value="7" digit={true}/>
    <Button value="8"digit={true} />
    <Button value="9"digit={true} />
    <Button value="*" digit={false} />
    <Button value="0" digit={true} />
    <Button value="C" func={Code.Clear} digit={false}/>
    <Button value="=" func={Code.Calculus} digit={false}/>   
    <Button value="/" digit={false} />
   </div>
);
const Calculator = ()=>
(
 <div>
  <Phone/>
 <History/>
<ThemeButton/>
<Input/>
<Body></Body>
</div>
);
  return (
   <Calculator></Calculator>
  );
}

export default App;

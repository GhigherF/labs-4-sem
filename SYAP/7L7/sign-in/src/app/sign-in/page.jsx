'use client'
import Link from 'next/link';
import { useState } from 'react';

export default function  SignIn(){ 

  const [email,setEmail] = useState('');
  const [password,setPassword] = useState('');
  const [EmailErrorVisibility,setEmailErrorVisibility] = useState(true);
  const [PasswordErrorVisibility,setPasswordErrorVisibility] = useState(true);
  const [EmailEnabled,setEmailEnable]=useState(false);
  const [passwordEnabled,setPasswordEnable]=useState(false);
  
function Show()
{
alert("Вход выполнен");
}

  const Email=(event)=>
    {
        setEmail(event.target.value);
        const regex = /^[a-zA-Z0-9_%+-]+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,5}$/;
        regex.test(event.target.value)?setEmailErrorVisibility(false):setEmailErrorVisibility(true);
        regex.test(event.target.value)?setEmailEnable(true):setEmailEnable(false);
    }    
  
    const Password=(event)=>
      {
          setPassword(event.target.value);
          const regex= /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^\s]{8,}$/;
          regex.test(event.target.value)?setPasswordErrorVisibility(false):setPasswordErrorVisibility(true);
          regex.test(event.target.value)?setPasswordEnable(true):setPasswordEnable(false);
      }    

    const Button=()=>
      {
      if (EmailEnabled&&passwordEnabled){
  return <button onClick={Show} className="bg-violet-500 w-[350px] h-[50px] rounded-[10px]  
  absolute top-[340px] left-[75px] text-[25px] text-black  font-serif hover:bg-violet-400 cursor-pointer">Войти</button>
      }
      else
      {
           return <button onClick={Show} className="bg-violet-400 w-[350px] h-[50px] rounded-[10px]  
           absolute top-[340px] left-[75px] text-[25px] text-black font-serif cursor-not-allowed" disabled>Войти</button>
      }
  }
  
  return (<div className = "w-[500px]  h-[600px] bg-violet-300 ">
  <h1 className="text-[70px] absolute top-[20px] left-[165px] font-serif">Вход</h1>
  
  {EmailErrorVisibility
   &&  <h2 className="text-[#e72511] absolute top-[153px] left-[285px]">Неверный e-mail</h2>}
  <h2 className="text-black font-serif text-[25px] absolute top-[140px] left-[65px]">E-MAIL</h2>
  <input onInput={Email} id="e-mail" type="text" className="bg-white w-[350px] h-[50px] rounded-[10px]  
  absolute top-[180px] left-[75px] text-[25px] text-black font-serif" ></input>
  
  {PasswordErrorVisibility &&
  <h2 className="text-[#e72511] absolute top-[245px] left-[285px]">Неверный пароль</h2>}
  <h1 className="text-black font-serif text-[25px] absolute top-[230px] left-[65px]">Пароль</h1>
  <input onInput={Password} id="password" type="password" className=" t bg-white w-[350px] h-[50px] rounded-[10px]  
  absolute top-[270px] left-[75px] text-[25px] text-black font-serif" ></input>
  
  
  <Button/>
   
   
   <h3 className="text-indigo-500 absolute top-[400px] left-[210px] hover:text-indigo-400 cursor-pointer">
     <Link href="/sign-up">
   Регистрация
    </Link> </h3> 
     
   <h3 className="text-indigo-500 absolute top-[420px] left-[197px] hover:text-indigo-400 cursor-pointer">
   <Link href="/reset-password">
    Забыли пароль?
    </Link> 
   </h3>
   </div>);
}
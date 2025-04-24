'use client'; 
import Link from 'next/link';
import { useState } from 'react';



export default function  SignIn(){ 
    const [email,setEmail] = useState('');
    const [EmailErrorVisibility,setEmailErrorVisibility] = useState(true);
    const [ButtonEnabled,setEnabled]=useState(false);

    const Email=(event)=>
    {
        setEmail(event.target.value);
        const regex = /^[a-zA-Z0-9_%+-]+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,5}$/;
        regex.test(event.target.value)?setEmailErrorVisibility(false):setEmailErrorVisibility(true);
        regex.test(event.target.value)?setEnabled(true):setEnabled(false);
    }


    function generatePassword(length = 12) {
        const lowercase = 'abcdefghijklmnopqrstuvwxyz';
        const uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        const numbers = '0123456789';
        const symbols = '!@#$%^&*()_+[]{}|;:,.<>?';
        
        const allCharacters = lowercase + uppercase + numbers + symbols;
        
        // Убедимся, что пароль содержит хотя бы одну букву, одну цифру и один символ
        const passwordArray = [
            lowercase[Math.floor(Math.random() * lowercase.length)],
            uppercase[Math.floor(Math.random() * uppercase.length)],
            numbers[Math.floor(Math.random() * numbers.length)],
            symbols[Math.floor(Math.random() * symbols.length)]
        ];
        
        // Заполняем оставшуюся длину пароля случайными символами
        for (let i = passwordArray.length; i < length; i++) {
            const randomChar = allCharacters[Math.floor(Math.random() * allCharacters.length)];
            passwordArray.push(randomChar);
        }
        
        // Перемешиваем массив пароля
        const password = passwordArray.sort(() => Math.random() - 0.5).join('');
        
        return password;
    }

    function Show()
    {
        alert(`Пароль выслан на почту: ${email}`);
        alert(`Новый пароль: ${generatePassword()}`);

    }

    const Button=()=>
    {
    if (ButtonEnabled){
return <button onClick={Show} className="bg-violet-500 w-[350px] h-[50px] rounded-[10px]  
absolute top-[340px] left-[75px] text-[25px] text-black  font-serif hover:bg-violet-400 cursor-pointer">Восстановить</button>
    }
    else
    {
         return <button onClick={Show} className="bg-violet-400 w-[350px] h-[50px] rounded-[10px]  
         absolute top-[340px] left-[75px] text-[25px] text-black font-serif cursor-not-allowed" disabled>Восстановить</button>
    }
}

    return (
<div className = "w-[500px]  h-[600px] bg-violet-300 ">
    {/* {
     <h1>{email}</h1>} */}
    <h1 className="text-[50px] absolute top-[120px] left-[60px] font-serif">Восстановление</h1>
    <h1 className="text-[50px] absolute top-[160px] left-[150px] font-serif">пароля</h1>
    
    {EmailErrorVisibility &&
    <h2 className=
    "text-[#e72511]  absolute top-[253px] left-[285px]"
    >Неверный e-mail</h2>
    }
    <h2 className="text-black font-serif text-[25px] absolute top-[240px] left-[65px]">E-MAIL</h2>
    <input onInput={Email} id="e-mail" type="text" className="bg-white w-[350px] h-[50px] rounded-[10px]  
    absolute top-[280px] left-[75px] text-[25px] text-black font-serif"></input>
    
   <Button/>
     
     <h3 className="text-indigo-500 absolute top-[400px] text-[25px] left-[225px] hover:text-indigo-400 cursor-pointer">
       <Link href="/sign-in">
        Вход
      </Link> </h3> 
     </div>);
  }
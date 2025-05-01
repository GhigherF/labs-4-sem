'use client'
import Link from 'next/link';
import { useState } from 'react';

let UserInfo={
    email:'',
    password:'',
    name:'',
}
export let UsersData=[UserInfo,UserInfo];

export default function  SignIn(){ 
    
    const [email,setEmail] = useState('');
    const [password,setPassword] = useState('');
    const [name,setName] = useState('');
    const [confirm,setConfirm] = useState('');


    const [EmailErrorVisibility,setEmailErrorVisibility] = useState(true);
    const [PasswordErrorVisibility,setPasswordErrorVisibility] = useState(true);
    const [NameErrorVisibility,setNameErrorVisibility] = useState(true);
    const [ConfirmErrorVisibility,setConfirmErrorVisibility] = useState(true);
    

    const [EmailEnabled,setEmailEnable]=useState(false);
    const [passwordEnabled,setPasswordEnable]=useState(false);
    const [nameEnabled,setNameEnable]=useState(false);
    const [confirmEnabled,setConfirmEnable]=useState(false);
    
function Show()
{
    let message=null;
    UsersData.forEach(element => {
        if (element.email==email) message = "Аккаунт с таким E-mail уже существует"; else
        if (element.name==name) message = "Аккаунт с таким именем уже существует";
    });
    if (message!=null) alert(message)
        else{
alert("Успешная регистрация");
UserInfo={
    email:email,
    password:password,
    name:name,
}
UsersData.push(UserInfo);
        }
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

    const Name=(event)=>
      {
          setName(event.target.value);
          const regex=/^(?! )[A-Za-zА-Яа-яЁё_]{2,50}(?<! )$/;
          regex.test(event.target.value)?setNameErrorVisibility(false):setNameErrorVisibility(true);
          regex.test(event.target.value)?setNameEnable(true):setNameEnable(false);
      }   

      const Confirm=(event)=>
        {
            setConfirm(event.target.value);
            if (event.target.value==password)
            {
                setConfirmErrorVisibility(false);
                setConfirmEnable(true);
            }
            else 
            {
                setConfirmErrorVisibility(true);
                setConfirmEnable(false);
            }
        }   
  
    


      const Button=()=>
        {
        if (EmailEnabled&&passwordEnabled&&nameEnabled&&confirmEnabled){
    return <button onClick={Show} className="bg-violet-500 w-[350px] h-[50px] rounded-[10px]  
    absolute top-[490px] left-[75px] text-[25px] text-black  font-serif hover:bg-violet-400 cursor-pointer">Регистрация</button>
        }
        else
        {
             return <button onClick={Show} className="bg-violet-400 w-[350px] h-[50px] rounded-[10px]  
             absolute top-[490px] left-[75px] text-[25px] text-black font-serif cursor-not-allowed" disabled>Регистрация</button>
        }
    }


    return (<div className = "w-[500px]  h-[600px] bg-violet-300 ">
    <h1 className="text-[55px] absolute top-[0px] left-[80px] font-serif">Регистрация</h1>
    
    {NameErrorVisibility&&
    <h2 className="text-[#e72511] absolute top-[93px] left-[295px]">Неверное имя</h2>}
    <h2 className="text-black font-serif text-[25px] absolute top-[80px] left-[65px]">Имя</h2>
    <input onInput={Name} id="e-mail" type="text" className="bg-white w-[350px] h-[50px] rounded-[10px]  
    absolute top-[120px] left-[75px] text-[25px] text-black font-serif" ></input>
    
    {EmailErrorVisibility &&
    <h2 className="text-[#e72511] absolute top-[195px] left-[285px]">Неверный e-mail</h2>}
    <h1 className="text-black font-serif text-[25px] absolute top-[180px] left-[65px]">E-MAIL</h1>
    <input onInput={Email} id="password"  className=" t bg-white w-[350px] h-[50px] rounded-[10px]  
    absolute top-[220px] left-[75px] text-[25px] text-black font-serif" ></input>
    

    {PasswordErrorVisibility&&  
    <h2 className="text-[#e72511] absolute top-[285px] left-[275px]">Неверный пароль</h2>}
    <h1 className="text-black font-serif text-[25px] absolute top-[270px] left-[65px]">Пароль</h1>
    <input onInput={Password} id="password" type="password" className=" t bg-white w-[350px] h-[50px] rounded-[10px]  
    absolute top-[310px] left-[75px] text-[25px] text-black font-serif" ></input>
    
    {ConfirmErrorVisibility&&
    <h2 className="text-[#e72511] absolute top-[375px] left-[275px]">Пароли не совпадают</h2>}
    <h1 className="text-black font-serif text-[25px] absolute top-[360px] left-[65px]">Подтверждение</h1>
    <input onInput={Confirm} id="password" type="password" className=" t bg-white w-[350px] h-[50px] rounded-[10px]  
    absolute top-[400px] left-[75px] text-[25px] text-black font-serif" ></input>

    <Button/>
     
     <h3 className="text-indigo-500 absolute top-[550px] text-[17px] left-[145px] hover:text-indigo-400 cursor-pointer">
       <Link href="/sign-in">
        Уже есть аккаунт?Красава
      </Link> </h3> 
     </div>);
  }
export let answer:string="PUSTO";
export let flag:boolean=false;
let sign:string="";
let text:string="";
let temp=false;

export function Clear():void
{
       document.querySelector("input")!.value="";
       answer="PUSTO";
       temp=false;
}
export function Digit(digit:number):void
{ 
   console.log(answer);
   if (flag)   
   {
       document.querySelector("input")!.value="";
       flag=false;
   }
   document.querySelector("input")!.value+=digit.toString();
}
export function isNum(digit:any):boolean
{
   return !isNaN(digit);
}

export function Plus()
{

   sign="+";
   if (answer=="PUSTO")
   {
       answer=document.querySelector("input")!.value;
       document.querySelector("input")!.value="";
   
   }
   else
   { answer=document.querySelector("input")!.value;} 
  flag=true;
  
}

export function Log(value:string):void
{
   if (temp==false)
   {
       temp=true
   }
   else
   {
      text+=String(answer)+value+document.querySelector("input")!.value+"="+
      eval(String(answer)+value+document.querySelector("input")!.value)+"                     ";
   document.querySelector("label")!.innerText=text; 
   }
}
export function Equals()
{
document.querySelector("input")!.value=eval(String(answer)+sign+document.querySelector("input")!.value);
}
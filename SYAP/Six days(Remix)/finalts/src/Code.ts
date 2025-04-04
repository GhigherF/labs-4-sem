export class Code
{
static gg():void
{
    alert(
        document.querySelector('input')!.value
    );
}
static new=false;
static Digit(a:string):void
{
if (document.querySelector('input')!.value.length==0&&(a=='/'||a=='*'))
{
return;
}
    if (Code.new)
    {
        document.querySelector('input')!.value='';
        Code.new=false;
    }   
     if ((a=='-'||a=='+'||a=='*'||a=='/')&&
     (
     document.querySelector('input')!.value[document.querySelector('input')!.value.length-1]=='+'||
     document.querySelector('input')!.value[document.querySelector('input')!.value.length-1]=='-'||
     document.querySelector('input')!.value[document.querySelector('input')!.value.length-1]=='*'||
     document.querySelector('input')!.value[document.querySelector('input')!.value.length-1]=='/'))
     {
     }
     else 
     {
    let temp:string =document.querySelector('input')!.value;
      temp+=a;   
    document.querySelector('input')!.value=temp;
     }
   
}

static Check() {
    const check = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '*', '/','.'];
    const val = document.querySelector('input')!.value;
    let temp = '';
    const kol = val.length;

    for (let i = 0; i < kol - 1; i++) {
        temp += val[i];
    }

    const last = val[kol - 1];
    if ((kol-1)==0)
    {
        if (last == '*'||last=='/') document.querySelector('input')!.value  = temp;
    }
    const predlast=val[kol-2];
    if (!check.includes(last)
        || (
        (last=='-'||last=='+'||last=='*'||last=='/')
        &&(predlast=='-'||predlast=='+'||predlast=='*'||predlast=='/')
    ))
    {
        document.querySelector('input')!.value  = temp;
    }
}

static Calculus() {
    const inputElement = document.querySelector('input');
    if (!inputElement) return;
    let expression = inputElement.value;
    if (expression[0]==undefined)return;
    if (expression[expression.length-1]=='+'||expression[expression.length-1]=='-'
        ||expression[expression.length-1]=='*'||expression[expression.length-1]=='/')return
    try {
        let result = eval(expression);
        if (expression!=result)
        {
                 document.querySelector('p')!.innerHTML+=`<h4>${expression}=${result}<h4/>`;   
        }

        let temp = result.toString().split('.');
        let integerPart = temp[0];
        let decimalPart = temp[1] || '';

        if (decimalPart.length === 0) {
            inputElement.value = integerPart;
        } 
        
        else {
            if (integerPart.length > 6) {
                decimalPart = decimalPart.slice(0, 2);
            } else {
                decimalPart = decimalPart.slice(0, 5);
            }
            inputElement.value = integerPart + '.' + decimalPart;
        }

        Code.new = true;
    } catch (error) {
        inputElement.value = 'Error';
    }
}
static Clear()
{
    document.querySelector('input')!.value = '';
}
}

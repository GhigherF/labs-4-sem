//1
abstract class BaseUser {
    id: number;
    name: string;

    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }

    abstract getPermissions(): string; 
}

class Guest extends BaseUser {
    constructor(id: number, name: string) {
        super(id, name);
    }

    getPermissions(): string {
        return `["Просмотр контента"]`;
    }
}

class User extends BaseUser {
    constructor(id: number, name: string) {
        super(id, name);
    }

    getPermissions(): string {
        return `["Просмотр контента",
"Добавление комментариев",
"Удаление комментариев"
]`;
    }
}

class Admin extends BaseUser {
    constructor(id: number, name: string) {
        super(id, name);
    }

    getPermissions(): string {
        return `["Просмотр контента","Добавление комментариев",
"Удаление комментариев","Управление пользователями"]`;
    }
}

// Примеры использования
console.log("1:");
const guest = new Guest(1, "Аноним");
console.log(guest.getPermissions());
console.log("-----------------------");
const admin = new Admin(2, "Мария");
console.log(admin.getPermissions());
console.log("----------------------------------------------------------------");
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////

//2
interface IReport
{
    title:string;
    content:string;
    generate:()=>string;
}

class HTMLReport implements IReport
{
    title:string;
    content:string;
    constructor(title:string, content:string)
    {
        this.title = title;
        this.content = content;
    }
    generate():string
    {
        return `<h1> ${this.title}</h1><p> ${this.content}</p>`;
    }
}
class JSONReport implements IReport
{
    title:string;
    content:string;
    constructor(title:string, content:string)
    {
        this.title = title;
        this.content = content;
    }
    generate():string
    {
        return `{title:\"${this.title}\",content:\"${this.content}\"}`;
    }
}

const report1=new HTMLReport("Отчёт 1","Содержание отчёта");
console.log("2:");
console.log(report1.generate());
console.log("---");
const report2=new JSONReport("Отчёт 2", "Содержание отчёта");
console.log(report2.generate());
console.log("----------------------------------------------------------------");
///////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////

//3
class cache<T> {
    storage: Map<string, { value: T; expiry: number }> = new Map();

    add(key: string, value: T, ttl: number) {
        const expiry = Date.now() + ttl; 
        this.storage.set(key, { value, expiry });
    }

    clearExpired() {
        const now = Date.now();
        for (const [key, { expiry }] of this.storage) {
            if (expiry < now) {
                this.storage.delete(key); 
            }
        }
    }

    get(key: string): T | string {
        const entry = this.storage.get(key);
        if (entry && entry.expiry > Date.now()) {
            return entry.value; 
        }
        return "⎈☠︎𝕯𝖊𝖆𝖉☠︎⎈"; 
    }
}

// const cache1 = new cache<number>();
// cache1.add("price", 100,300);
// console.log("3:");
// console.log(cache1.get("price"));
// console.log("------");
// setTimeout(() => {
//     console.log(cache1.get("price"));
// },400);
// setTimeout(() => {
//     console.log("----------------------------------------------------------------");
// }, 400);




///////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////

//4
function createInstance<T>(cls: new (...args: any[]) => T, ...args: any[]):T
{
return new cls(...args);
}

class Product
{
    constructor(public name:string, public price:number){}
}
const p= createInstance(Product, "Телефон", 50000);
console.log("4:");  
console.log(p);
console.log("----------------------------------------------------------------");
///////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////

//5
type LogEntry = [Date,LogLevel,string];
enum LogLevel{
    INFO = "INFO",
    WARNING = "WARNING",
    ERROR = "ERROR",
}
function logEvent(event:LogEntry)
{
    console.log(`[${event[0].getFullYear()}-${event[0].getMonth()}-${event[0].getDay()}T${event[0].getHours()}:${event[0].getMinutes()}:${event[0].getSeconds()}] [${event[1]}]: ${event[2]}`);
}

logEvent([new Date(),LogLevel.INFO,"Система Запущена"]);

///////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////

//6
enum HTTPStatus
{
    OK=200,
    BAD_GETAWAY=400,
    NOT_FOUND=404,
    SHIT=500,
}

type ApiResponse<T> = [status:HTTPStatus,data:T|null,error?:string];

function sucess<T> (data:T):ApiResponse<T>
{
return [HTTPStatus.OK,data];
}

function error(message:string,status: HTTPStatus):ApiResponse<null>
{
    return[status,null,message];
}

const res1= sucess({user:"Андрей"});
console.log("6:");
console.log(res1);
console.log("-----------------------");

const res2 = error("Не найдено",HTTPStatus.NOT_FOUND);
console.log(res2);

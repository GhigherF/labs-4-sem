"use strict";
//1
class BaseUser {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}
class Guest extends BaseUser {
    constructor(id, name) {
        super(id, name);
    }
    getPermissions() {
        return `["Просмотр контента"]`;
    }
}
class User extends BaseUser {
    constructor(id, name) {
        super(id, name);
    }
    getPermissions() {
        return `["Просмотр контента",
"Добавление комментариев",
"Удаление комментариев"
]`;
    }
}
class Admin extends BaseUser {
    constructor(id, name) {
        super(id, name);
    }
    getPermissions() {
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
class HTMLReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        return `<h1> ${this.title}</h1><p> ${this.content}</p>`;
    }
}
class JSONReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        return `{title:\"${this.title}\",content:\"${this.content}\"}`;
    }
}
const report1 = new HTMLReport("Отчёт 1", "Содержание отчёта");
console.log("2:");
console.log(report1.generate());
console.log("---");
const report2 = new JSONReport("Отчёт 2", "Содержание отчёта");
console.log(report2.generate());
console.log("----------------------------------------------------------------");
///////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////
//3
class cache {
    constructor() {
        this.storage = new Map();
    }
    add(key, value, ttl) {
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
    get(key) {
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
function createInstance(cls, ...args) {
    return new cls(...args);
}
class Product {
    constructor(name, price) {
        this.name = name;
        this.price = price;
    }
}
const p = createInstance(Product, "Телефон", 50000);
console.log("4:");
console.log(p);
console.log("----------------------------------------------------------------");
var LogLevel;
(function (LogLevel) {
    LogLevel["INFO"] = "INFO";
    LogLevel["WARNING"] = "WARNING";
    LogLevel["ERROR"] = "ERROR";
})(LogLevel || (LogLevel = {}));
function logEvent(event) {
    console.log(`[${event[0].getFullYear()}-${event[0].getMonth()}-${event[0].getDay()}T${event[0].getHours()}:${event[0].getMinutes()}:${event[0].getSeconds()}] [${event[1]}]: ${event[2]}`);
}
logEvent([new Date(), LogLevel.INFO, "Система Запущена"]);
///////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////
//6
var HTTPStatus;
(function (HTTPStatus) {
    HTTPStatus[HTTPStatus["OK"] = 200] = "OK";
    HTTPStatus[HTTPStatus["BAD_GETAWAY"] = 400] = "BAD_GETAWAY";
    HTTPStatus[HTTPStatus["NOT_FOUND"] = 404] = "NOT_FOUND";
    HTTPStatus[HTTPStatus["SHIT"] = 500] = "SHIT";
})(HTTPStatus || (HTTPStatus = {}));
function sucess(data) {
    return [HTTPStatus.OK, data];
}
function error(message, status) {
    return [status, null, message];
}
const res1 = sucess({ user: "Андрей" });
console.log("6:");
console.log(res1);
console.log("-----------------------");
const res2 = error("Не найдено", HTTPStatus.NOT_FOUND);
console.log(res2);

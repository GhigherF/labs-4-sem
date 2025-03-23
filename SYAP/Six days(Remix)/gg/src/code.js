"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.flag = exports.answer = void 0;
exports.Clear = Clear;
exports.Digit = Digit;
exports.isNum = isNum;
exports.Plus = Plus;
exports.Log = Log;
exports.Equals = Equals;
exports.answer = "PUSTO";
exports.flag = false;
let sign = "";
let text = "";
let temp = false;
function Clear() {
    document.querySelector("input").value = "";
    exports.answer = "PUSTO";
    temp = false;
}
function Digit(digit) {
    console.log(exports.answer);
    if (exports.flag) {
        document.querySelector("input").value = "";
        exports.flag = false;
    }
    document.querySelector("input").value += digit.toString();
}
function isNum(digit) {
    return !isNaN(digit);
}
function Plus() {
    sign = "+";
    if (exports.answer == "PUSTO") {
        exports.answer = document.querySelector("input").value;
        document.querySelector("input").value = "";
    }
    else {
        exports.answer = document.querySelector("input").value;
    }
    exports.flag = true;
}
function Log(value) {
    if (temp == false) {
        temp = true;
    }
    else {
        text += String(exports.answer) + value + document.querySelector("input").value + "=" +
            eval(String(exports.answer) + value + document.querySelector("input").value) + "                     ";
        document.querySelector("label").innerText = text;
    }
}
function Equals() {
    document.querySelector("input").value = eval(String(exports.answer) + sign + document.querySelector("input").value);
}

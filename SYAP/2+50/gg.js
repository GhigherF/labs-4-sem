"use strict";
let Челики = [
    { id: 1, name: "Vasya", group: 1 },
    { id: 2, name: "Ivan", group: 1 },
    { id: 3, name: "Masha", group: 2 },
    { id: 4, name: "Petya", group: 2 },
    { id: 5, name: "Kira", group: 3 },
];
let car = {
    manufacturer: "manufacturer",
    model: 'model',
};
let car1 = {
    manufacturer: "manufacturer",
    model: 'model',
};
let car2 = {
    manufacturer: "manufacturer",
    model: 'model',
};
let arrayCars = [
    {
        cars: [car1, car2]
    }
];
const students = [
    { id: 1, name: 'Vasya', group: 10, marks: [{ subject: 'Math', mark: 8, done: 'done' }] },
    { id: 2, name: 'Ivan', group: 11, marks: [{ subject: 'Math', mark: 5, done: 'done' }] },
    { id: 3, name: 'Masha', group: 12, marks: [{ subject: 'Math', mark: 7, done: 'Ne done' }] },
];
const group = {
    students,
    studentFilter: (group) => students.filter(student => student.group === group),
    markFilter: (mark) => students.filter(student => student.marks.some(m => m.mark === mark)),
    deleteStudent: (id) => {
        const index = students.findIndex(student => student.id === id);
        if (index !== -1) {
            students.splice(index, 1);
        }
    },
    mark: 5,
    group: 10,
};
// Пример использования:
console.log(students);
const studentsInGroup8 = group.studentFilter(10);
console.log(studentsInGroup8);
const studentsWithMark5 = group.markFilter(5);
console.log(studentsWithMark5);
//group.deleteStudent(2); // Удаляет студента с id 2 (Ivan)
//console.log(students);

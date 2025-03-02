//1
interface Челик
{
    id:number;
    name:string;
    group:number;
}

let Челики:Array<Челик> =[
    {id:1,name:"Vasya",group:1},
    {id:2,name:"Ivan",group:1},
    {id:3,name:"Masha",group:2},
    {id:4,name:"Petya",group:2},
    {id:5,name:"Kira",group:3},
]
//////////////////////////////////////

//2
interface CarsType
{
    manufacturer:string;
    model:string;
}

let car:CarsType={
manufacturer : "manufacturer",
model : 'model',
};
/////////////////////////////////////

//3
interface ArrayCarsType
{
    cars:Array<CarsType>;
}
let car1:CarsType={
    manufacturer : "manufacturer",
    model : 'model',
    };
let car2:CarsType={
    manufacturer : "manufacturer",
    model : 'model',
    };

let arrayCars:Array<ArrayCarsType>=
[
    {
        cars:[car1,car2]
    }
]
/////////////////////////////////////////////////////

//4

type MarkFilterType = 1|2|3|4|5|6|7|8|9|10;
type DoneType = "done"|"Ne done";
type GroupFilterType = 1|2|3|4|5|6|7|8|9|10|11|12;

type MarkType ={
    subject:string;
    mark:MarkFilterType;
    done:DoneType;
}

type StudentType ={
    id:number;
    name:string;
    group:GroupFilterType;
    marks:Array<MarkType>;
}

type groupType ={
    students:Array<StudentType>;
    studentFilter :(group:number)=>Array<StudentType>;
    markFilter :(mark:number)=>Array<StudentType>;
    deleteStudent:(id:number)=>void;
    mark:MarkFilterType;
    group:GroupFilterType;
}

const students: Array<StudentType> = [
    { id: 1, name: 'Vasya', group: 10, marks: [{ subject: 'Math', mark: 8, done: 'done' }] },
    { id: 2, name: 'Ivan', group: 11, marks: [{ subject: 'Math', mark: 5, done: 'done' }] },
    { id: 3, name: 'Masha', group: 12, marks: [{ subject: 'Math', mark: 7, done: 'Ne done' }] },
];

const group: groupType = {
    students,
    studentFilter: (group: number) => students.filter(student => student.group === group),
    markFilter: (mark: number) => students.filter(student => student.marks.some(m => m.mark === mark)),
    deleteStudent: (id: number) => {
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
//group.deleteStudent(2); 
//console.log(students);

// async function FIRST()
// {
// await console.log("1:");
// await console.log("---------------");
// await  new Promise((resolve,reject)=>
// {
//     setTimeout(()=>
//         resolve(Math.floor(Math.random()*100)),
//         3000);
// })
// .then((result)=>console.log(result))
// .then(()=>console.log("---------------"));
// }



// async function SECOND()
// {
// await console.log("2:")
// await console.log("---------------");
// async function gg (delay)
// {
//     await  new Promise((resolve, reject)=>
//     {
//         setTimeout(()=>
//         {
//             resolve(Math.floor(Math.random()*100));
//         }, delay);
//     }).then((result)=>console.log(result))
// }

// Promise.all([gg(3000), gg(2000), gg(1000)])
// .then(()=>console.log("---------------"));
// }



// await FIRST();
// await SECOND();


//4
//
// let pr = new Promise ((res,rej)=>
// {
// rej('ku');
// }) 

// pr 
//     .then(()=>console.log(1))
//     .catch(()=>console.log(2))
//     .catch(()=>console.log(3))
//     .then(()=>console.log(4))
//     .then(()=>console.log(5));


//5
//

// new Promise ((res,rej)=>
// {
//     res(21);
// })
// .then((result)=>
// {
//     console.log(result);
//     return 21;
// })
// .then((result)=>console.log(result*2));


//6
//

async function gg()
{
    let pr = new Promise ((res, rej)=>
    {
        res(21);
    })
    let result = await pr;
    console.log(result);
    console.log(result*2);
}
gg();

//7
//
// let promise = new Promise((res,rej)=>
// {
//     res('resolved promise -1')
// })

// promise 
//     .then((res)=>
//     {
//             console.log("Resolved promise -2")
//             return "OK"
//     })
//     .then ((res)=>
//     {
//         console.log(res);
//     })

//8
//
// let promise = new Promise((res, rej)=>
// {
//     res('resolved promise -1')
// })

// promise
//     .then((res)=>
//     {
//         console.log(res)
//         return "OK"
//     })
//     .then ((res1)=>
//     {
//         console.log(res1);
//     })

//9
//
// let promise = new Promise((res, rej)=>
// {
//     res('resolved promise -1')
// })

// promise 
//     .then((res)=>
//     {
//         console.log(res)
//         return res
//     })
//     .then ((res1)=>
//     {
//         console.log("Reolved promise - 2");
//     })


//10
//
// let promise = new Promise((res, rej)=>
// {
//     res('resolved promise -1')
// })

// promise 
//     .then((res)=>
//     {
//         console.log(res)
//         return res
//     })
//     .then ((res1)=>
//     {
//         console.log(res1);
//     })

//11
//
// let promise = new Promise((res, rej)=>
// {
//     res('resolved promise -1')
// })

// promise
//     .then((res)=>
//     {
//         console.log(res)
//         return res
//     })
//     .then ((res1)=>
//     {
//         console.log(res1);
//     })


//12
//
// let pr = new Promise((res, rej)=>
// {
//     rej('ku')
// })

// pr
//     .then(()=>console.log(1))
//     .catch(()=>console.log(2))
//     .catch(()=>console.log(3))
//     .then(()=>console.log(4))
//     .then(()=>console.log(5))
   
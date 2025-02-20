//1
//////////////////////////////////////////////////////////////////////
function createPhoneNumber(arr: number[]): string {
    let phone: string = '(' + arr[0] + arr[1] + arr[2] + ') '+ 
     arr[3] + arr[4] + arr[5] + '-' + arr[6] + arr[7] + arr[8] + arr[9];
    return phone;
}    

 let test: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9,0];
 console.log("1:");
 console.log("---------------------------------");
console.log(createPhoneNumber(test));
console.log("---------------------------------");

//2
//////////////////////////////////////////////////////////////////////

class Challenge
{
    static solution(number:number)
    {
        if (number<0) {
            console.log("zero");
        }
        else 
        {
            let sum:number = 0;
            for (let i:number = 1;i<number;i++)
            {
             if (i%3==0)sum+=i;
             if (i%5==0)sum+=i;
             if (i%15==0)sum-=i;
            }
             console.log(sum);
        }
    }
}
console.log("2:");
console.log("---------------------------------");
Challenge.solution(10);
Challenge.solution(40);
Challenge.solution(-4);
console.log("---------------------------------");

//3
//////////////////////////////////////////////////////////////////////
let nums:number[]  = [1,2,3,4,5,6,7];
console.log("3:");
console.log("---------------------------------");
console.log(snake(nums,3));
console.log("---------------------------------");

function snake(nums: number[], sdvig: number): number[] {
    const newArr: number[] = new Array(nums.length);
    for (let i: number = 0; i < nums.length; i++) {
        const newIndex = (i + sdvig) % nums.length;
        newArr[newIndex] = nums[i];
    }
    return newArr;
}
//4
//////////////////////////////////////////////////////////////////////
console.log("4:");
console.log("---------------------------------");

let nums1_1:number[]=[1,3];
let nums1_2:number[]=[2];

let nums2_1:number[]=[1,2];
let nums2_2:number[]=[3,4];

let nums1=nums1_1.concat(nums1_2).sort((a,b)=>a-b);
let nums2=nums2_1.concat(nums2_2).sort((a,b)=>a-b);

console.log(median(nums1));
console.log(median);

function median(nums:number[]): number {
    if (nums.length%2==0) {
        return (nums[nums.length/2]+nums[nums.length/2-1])/2;
    }
    else {
        return nums[Math.floor(nums.length/2)];
    }
}
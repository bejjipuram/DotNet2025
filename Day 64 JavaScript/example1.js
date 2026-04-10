function calcVolume(len,width,height,other){
    return len*width*height*other;
}
const cdim=[15,20,30,50]
// let volume=calcVolume(cdim[0],cdim[1],cdim[2],cdim[3]);
// console.log("Volume of the box is "+volume);

/* 
Spread Operator(...):
*/
console.log("Volume of the box is "+calcVolume(...cdim));
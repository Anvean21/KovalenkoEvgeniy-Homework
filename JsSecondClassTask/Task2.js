// var someObj = {
//     width: 300,
//     height: 200,
//     title: "Object",
//      display(){
//         console.log("hello");
//     }
//   };

function GetObjectInfo(someObj){
    for (let key in someObj) {
        console.log("Key: " + key + " Value: " + someObj[key])
    }
}
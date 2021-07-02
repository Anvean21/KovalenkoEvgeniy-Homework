function GetArrayKeyValue(obj){
var result = Object.keys(obj).map((key) => [Number(key), obj[key]]);
console.log(result);
}
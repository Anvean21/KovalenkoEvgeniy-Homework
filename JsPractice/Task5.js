var printArea5 = document.querySelector("#fiveTaskOutput");

document.querySelector("#fiveTask").addEventListener("click", function() {
    let input = document.querySelector("#stringRU").value;
   printArea5.innerHTML = StringRu(input); 
});

function StringRu(inputString)  {
    if (inputString === '') {
        return "string is emtpy"
    }
    if (inputString === inputString.substring(0,2) === 'RU') 
    { return inputString;}
    else{
        return 'RU'+inputString;
    }
}
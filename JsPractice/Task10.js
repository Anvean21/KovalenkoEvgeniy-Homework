var printArea10 = document.querySelector("#tenTaskOutput");

document.querySelector("#tenTask").addEventListener("click", function() {
    let input = document.querySelector("#arrayMultiply").value;
    let numbersArray = ConverArrayToInt(input);
    printArea10.innerHTML = MaxNeighboursMultiply(numbersArray)
});

function ConverArrayToInt(array){
    let splittedArray = array.split(' ');
    let resultArray = [];

    for (const item of splittedArray) {
            resultArray.push(parseInt(item))
    }
    return resultArray;
}
function MaxNeighboursMultiply(array){
    let max = 0;
    let temp = [];

    for (let i = 0; i < array.length - 1; i++) 
    {
        let element = array[i] * array[i+1];

        if (element > max) 
        {
            max = element
            temp[0] = array[i]
            temp[1] = array[i + 1]
        }
    }

    return max + " = " + temp[0] + " * " + temp[1];
}
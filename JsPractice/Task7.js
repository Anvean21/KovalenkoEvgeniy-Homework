var printArea7 = document.querySelector("#sevenTaskOutput");

document.querySelector("#sevenTask").addEventListener("click", () => {
    let input = document.querySelector("#arrayNums").value;
    printArea7.innerHTML = FirstNumOfArray(input) 
});

function FirstNumOfArray (input) { 
    if (input[0] == '1' || input[input.length - 1] == '1') {
        return "Yes";
    }
    else {
        return "No";
    }
}

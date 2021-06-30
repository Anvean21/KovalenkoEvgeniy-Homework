var printArea11 = document.querySelector("#elevenTaskOutput");

document.querySelector("#elevenTask").addEventListener("click", () => {
    let input = document.querySelector("#arrayWithDuplicates").value.split(' ');
    printArea11.innerHTML = CustomDistinct(input);
});

function CustomDistinct(array) {
    let resultArray = [];
    for (const item of array) {
        if (resultArray.indexOf(item) === -1) {
            resultArray.push(item);
        }
    }
    return resultArray;
}
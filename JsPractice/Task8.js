var printArea8 = document.querySelector("#eightTaskOutput");

document.querySelector("#eightTask").addEventListener("click", function()  {
    let input = document.querySelector("#arrayLastElements").value.split(' ');
    let countOfLasts = document.querySelector("#countOfLasts").value;
    printArea8.innerHTML = LastElements(input,countOfLasts);
});

function LastElements(array,count){

    return count >= array.length ? array : array.splice(array.length - count,count)
}

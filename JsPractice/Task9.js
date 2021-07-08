var printArea9 = document.querySelector("#nineTaskOutput");

document.querySelector("#nineTask").addEventListener("click", function()  {
    let input = document.querySelector("#arrayElements").value.split(' ');
    let delimetr = document.querySelector("#delimetr").value;
    printArea9.innerHTML = input.join(delimetr);
});
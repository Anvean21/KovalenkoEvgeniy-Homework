var printArea12 = document.querySelector('#twelveTaskOutput');

document.querySelector("#twelveTask").addEventListener("click", () => {
    let input = document.querySelector("#Poligon").value;
    printArea12.innerHTML = GetSquaer(input);
});

function GetSquaer(number) {
    if (number === 0) {
        return 0;
    }
    let adding = 0;
    let square = 1;

    for (let i = 0; i < number; i++) {
        square += adding;
        adding+=4;
    }

    return square;
}

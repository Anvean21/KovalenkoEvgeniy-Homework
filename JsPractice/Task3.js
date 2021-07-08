var printArea3 = document.querySelector("#thirdTaskOutput");

let gameData = {
    guessednNum: undefined,
    min:0,
    max:20,
}
document.querySelector("#thirdTask").addEventListener("click", () => {
     let input = document.querySelector("#guessGame").value
    printArea3.innerHTML = GuessGame(input);
});

function GuessGame(inputNumber) {
    let number = parseInt(inputNumber);

    if (Number.isNaN(number)) {
        return "It is not a number.";
    }

    if (gameData.guessednNum === undefined) {
        gameData.guessednNum = Math.floor(Math.random() * (gameData.max - gameData.min) + gameData.min);
    }
    if (inputNumber < gameData.guessednNum) {
        return "More";
    }
    else if (inputNumber > gameData.guessednNum) {
        return "Low";
    }
    else {
    gameData.guessednNum = undefined;
    return "Win";
    }
}
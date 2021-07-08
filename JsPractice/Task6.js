var printArea6 = document.querySelector("#sixTaskOutput");

document.querySelector("#sixTask").addEventListener("click", function() {
    let input = document.querySelector("#vowels").value;
    printArea6.innerHTML = GetVowelsCount(input);
});

function GetVowelsCount(inputString){
    let vowels = 'euioay';
    let count = 0;
    for (let i = 0; i < inputString.length; i++) {
        if (vowels.indexOf(inputString.charAt(i))!== -1) {
            count++;
        }
    }
    return count;
}
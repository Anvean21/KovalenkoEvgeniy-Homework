var printArea2 = document.querySelector("#secondTaskOutput");

document.querySelector("#secondTask").addEventListener("click", function () {
     printArea2.innerHTML = GetNewYearSunday(2014, 2050)
    });

function GetNewYearSunday(start, end){
        let years = [];
    
        for (let i = parseInt(start); i <= parseInt(end); i++) {
    
            let date = new Date(i,0,1,0,0,0,0);
            if (date.getDay() == 0) {
                years.push(i);
            }
        }
        return years;
    }
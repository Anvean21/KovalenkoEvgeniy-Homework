class Validator{
    IsValid(inputValue){
        console.log("Ain`t realized");
    }
}

class EmailValidator extends Validator{
    IsValid(inputValue){``
        var regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (regex.test(inputValue)) {
        console.log("Correct Email");
    }
    else{
        console.log("Incorrect email");
    }
    }
}
class PhoneValidator extends Validator{
    IsValid(inputValue){
        var regex = /^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$/
        if (regex.test(inputValue)) {
            console.log("Correct phone number");
        }
        else{
            console.log("Incorrect phone number");
        }
    }
}

let email = new EmailValidator();
email.IsValid("emaildsdffds");
let validemail = new EmailValidator();
validemail.IsValid("anvean@gmail.com");


let phone = new PhoneValidator();
phone.IsValid("111");
let validphone = new PhoneValidator();
validphone.IsValid("+380(67)777-7-777");
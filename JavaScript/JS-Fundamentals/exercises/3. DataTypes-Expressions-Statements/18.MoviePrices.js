function calcTicketPrice(input) {
    let title = input[0].toLowerCase();
    let day = input[1].toLowerCase();

    let result = "";

    if(title === "the godfather"){
        switch(day){
            case "monday": result = "12";
                break;
            case "tuesday": result =  "10";
                break;
            case "wednesday": result = "15";
                break;
            case "thursday": result =  "12.50";
                break;
            case "friday": result =  "15";
                break;
            case "saturday": result =  "25";
                break;
            case "sunday": result =  "30";
                break;
            default: result = "error";
                break;
        }
    } else if(title === "schindler's list") {
        switch(day){
            case "monday": result = "8.50";
                break;
            case "tuesday": result = "8.50";
                break;
            case "wednesday": result = "8.50";
                break;
            case "thursday": result =  "8.50";
                break;
            case "friday": result = "8.50";
                break;
            case "saturday": result =  "15";
                break;
            case "sunday": result =  "15";
                break;
            default: result = "error";
                break;
        }
    } else if(title === "casablanca") {
        switch(day){
            case "monday": result = "8";
                break;
            case "tuesday": result = "8";
                break;
            case "wednesday": result = "8";
                break;
            case "thursday": result = "8";
                break;
            case "friday": result = "8";
                break;
            case "saturday": result =  "10";
                break;
            case "sunday": result =  "10";
                break;
            default: result = "error";
                break;
        }
    } else if(title === 'the wizard of oz'){
        switch(day){
            case "monday": result = "10";
                break;
            case "tuesday": result = "10";
                break;
            case "wednesday": result = "10";
                break;
            case "thursday": result =  "10";
                break;
            case "friday": result = "10";
                break;
            case "saturday": result =  "15";
                break;
            case "sunday": result =  "15";
                break;
            default: result = "error";
                break;
        }
    } else {
        result = "error";
    }

    console.log(result);
}

calcTicketPrice(["The Godfather", "Friday"]);
calcTicketPrice(["casablanca", "sunday"]);
calcTicketPrice(["Schindler's LIST", "monday"]);
calcTicketPrice(["SoftUni", "Nineday"]);
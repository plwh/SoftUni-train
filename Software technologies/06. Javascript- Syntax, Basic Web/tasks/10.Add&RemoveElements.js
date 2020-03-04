function addRemoveElements(input){
    
    var arr  = new Array();

    for(let i = 0; i < input.length; i++){

        let commands = input[i].split(" ");
        let command = commands[0];
        let number = Number(commands[1]);
        let index = Number(commands[1]);
        
        switch(command){
            case "add":
            arr.push(number);
            break;
            case "remove":
            if(index >= 0 && index < arr.length){
                arr.splice(index,1);
            }
            break;
        }
    }

    arr.forEach(element => {
        console.log(element);
    });
}

function multipleValuesForAKey(input){
    
    var dict = new Array();
    let result;

    for(let i = 0; i < input.length; i++){
        let keyValuePair = input[i].split(" ");
        let key = keyValuePair[0];
        let value = keyValuePair[1];

        if(value === undefined){
            result = dict[key];
            break;
        }

        if(dict[key] === undefined){
            dict[key] = [];
        }

        dict[key].push(value);
    }

    if(result === undefined){
        console.log("None");
    } else {
        console.log(result.join("\n"));
    }
}

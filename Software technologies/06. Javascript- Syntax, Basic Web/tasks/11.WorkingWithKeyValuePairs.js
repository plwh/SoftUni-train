function workingWithKeyValuePairs(input){
    
    var dict = new Array();
    let key;
    let value;

    for(let i = 0; i < input.length-1; i++){
        let keyValuePair = input[i].split(" ");
        key = keyValuePair[0];
        value = keyValuePair[1];
        dict[key] = value;
    }

    let targetKey = input[input.length-1];

    if(dict[targetKey] == undefined){
        console.log("None")
    } else {
        console.log(dict[targetKey]);
    }
}

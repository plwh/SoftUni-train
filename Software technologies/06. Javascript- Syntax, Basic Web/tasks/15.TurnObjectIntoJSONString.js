function turnObjectIntoJSONString (input){
        var obj = {};
    
        for(let i=0; i<input.length;i++){
            var keyValuePair = input[i].split(" -> ");
            let key = keyValuePair[0];
            let value = keyValuePair[1];

            if(value == Number(value)) value = Number(value);
            obj[key] = value;
        }
    
        console.log(JSON.stringify(obj));
}
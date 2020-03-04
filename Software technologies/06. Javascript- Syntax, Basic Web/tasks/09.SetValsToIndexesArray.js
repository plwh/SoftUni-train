function setValsToIndexesArray(input){
    
    let length = Number(input[0]);
    var arr  = new Array(length).fill(0);

    for(let i = 1; i < input.length; i++){

        var indexAndValue = input[i].split(" ");
        let arrIndex = Number(indexAndValue[0]);
        let value = Number(indexAndValue[indexAndValue.length-1]);

        arr[arrIndex] = value;
    }

    arr.forEach(element => {
        console.log(element);
    });
}


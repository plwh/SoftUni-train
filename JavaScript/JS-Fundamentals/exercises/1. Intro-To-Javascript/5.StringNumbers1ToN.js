function stringNumber1ToN(number){
    let result = '';

    for (let i=1; i<= parseInt(number); i++){
        result += i;
    }

    console.log(result);
}

stringNumber1ToN('11');
function binToDec(num) {
    let result = 0;

    for (let i=num.length - 1, j = 0; i>=0; i--, j++){
        result += num[i] * Math.pow(2, j);
    }

    console.log(result);
}

binToDec('00001001');
binToDec('11110000');
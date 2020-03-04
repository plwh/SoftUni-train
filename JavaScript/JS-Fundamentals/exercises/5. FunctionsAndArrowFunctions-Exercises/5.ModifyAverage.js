function modifyAverage(num) {
    let nToString = num.toString();
    let avg = calcAverage(nToString);

    while(avg <= 5) {
        nToString += "9";
        avg = calcAverage(nToString);
    }

    function calcAverage(input){
        let sum = 0;

        for(let i of input){
            sum += parseInt(i);
        }

        let calculatedAverage = sum / input.length;
        return calculatedAverage;
    }

    console.log(nToString);
}

modifyAverage(101);


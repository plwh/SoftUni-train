function checkValidity(input) {
    let x1 = input[0];
    let y1 = input[1];
    let x2 = input[2];
    let y2 = input[3];
    let cartesianX = 0;
    let cartesianY= 0;

    calcResult(x1, y1, 0, 0);
    calcResult(x2, y2, 0, 0);
    calcResult(x1, y1, x2, y2);

    function calcResult(x1, y1, x2, y2){
        let dist = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
        let isValid = Number.isInteger(dist);

        console.log(`{${x1}, ${x2}} to {${y1}, ${y2}} is ${(isValid)? "valid":"invalid"}`);
    }
}

checkValidity([2, 1, 1, 1]);
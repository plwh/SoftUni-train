function solve(input) {
    let rowSum = 0;
    let colSum = 0;

    let isMagic = true;

    for (let i = 0; i < input.length; i++){
        for (let j = 0; j < input[0].length; j++) {
            colSum += input[j][i];
            rowSum += input[i][j];
        }

        if(rowSum != colSum) {
            isMagic = false;
            break;
        }
    }

    console.log(isMagic);
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]);

solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]);
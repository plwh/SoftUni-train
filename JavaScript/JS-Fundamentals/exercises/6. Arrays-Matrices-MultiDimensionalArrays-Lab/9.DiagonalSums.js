function solve (matrix) {
    let mainDiagonalSum = 0;
    let secDiagonalSum = 0;

    for (let col = 0, mCounter = 0, sCounter = matrix.length - 1; col < matrix[0].length; col++, mCounter++, sCounter--){
        mainDiagonalSum += matrix[mCounter][col];
        secDiagonalSum += matrix [sCounter] [col];
    }

    console.log(mainDiagonalSum + " " + secDiagonalSum);
}

solve([[20, 40],
    [10, 60]]);

solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]);


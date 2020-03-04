function solve (matrix) {
    let result = 0;

    for (let row = 1; row < matrix.length - 1; row++) {
        for (let col = 1; col < matrix[0].length - 1; col++) {

            if(matrix[row][col] != " ") {
                if (matrix[row][col] == matrix[row - 1][col] && matrix[row - 1][col] != " ") {
                    matrix = changeCells(row, col, row - 1, col, matrix);
                }

                if (matrix[row][col] == matrix[row + 1][col] && matrix[row + 1][col] != " ") {
                    matrix = changeCells(row, col, row + 1, col, matrix);
                }

                if (matrix [row][col] == matrix[row][col - 1] && matrix[row][col - 1] != " ") {
                    matrix = changeCells(row, col, row, col - 1, matrix);
                }

                if (matrix [row][col] == matrix[row][col + 1] && matrix[row][col + 1] != " ") {
                    matrix = changeCells(row, col, row, col + 1, matrix);
                }
            }
        }
    }

    function changeCells(firstRow, firstCol, secondRow, secondCol, matrix)
    {
        matrix[firstRow][firstCol] = " ";
        matrix[secondRow][secondCol] = " ";

        result++;
        return matrix;
    }

    console.log(result);
}

solve([['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
);

solve([['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
);


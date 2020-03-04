function printFourSquareFigure(num){
    let isEven = num % 2 == 0;

    let rowsNum =  (isEven) ? num - 1 : num;
    let colsNum = num * 2 - 1;

    let result = "";
    for (let row = 0; row < rowsNum; row++) {
        for (let col = 0; col < colsNum; col++) {
            // print first, middle and last row
            if(row == 0 || row == parseInt(rowsNum/2) || row == rowsNum - 1) {
                if (col == 0 || col == num - 1 || col == colsNum - 1) {
                    result += "+";
                } else {
                    result += "-";
                }
            } else {
                // print rest of the rows
                if (col == 0 || col == num - 1 || col == colsNum - 1) {
                    result += "|";
                } else {
                    result += " ";
                }
            }
        }
        result += "\n";
    }

    console.log(result);
}

printFourSquareFigure(4);
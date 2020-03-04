function printSquare(num){
    let size = (num == null) ? 5 : num;
    let result = "";

    for (let i = 0; i < size; i++) {
        result += "*".repeat(size) + "\n";
    }

    console.log(result);
}

printSquare();
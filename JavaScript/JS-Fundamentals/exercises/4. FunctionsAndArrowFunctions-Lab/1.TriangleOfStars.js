function printTriangle(num){
    let result = "";

    for (let i=1; i <= num; i++){
        result += "*".repeat(i) + "\n";
    }

    for (let j= num - 1; j > 0; j--){
        result += "*".repeat(j) + "\n";
    }

    console.log(result);
}

printTriangle(5);
function solve (input) {
     let resultArr = new Array();
     let delimiter = input[input.length - 1];

     for(let i = 0; i < input.length - 1; i++) {
         resultArr.push(input[i]);
    }

    console.log(resultArr.join(delimiter));
}

solve(["One", "Two", "Three", "Four", "Five", "-"]);
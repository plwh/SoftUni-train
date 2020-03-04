function solve(input) {
    let numOfRotations = parseInt(input[input.length-1]);

    // remove last number from array
    input.splice(-1, 1);

    for (let i = 0; i < numOfRotations; i++){
        input.unshift(input[input.length - 1]);
        input.splice(-1, 1);
    }

    console.log(input.join(' '));
}

solve(['Banana', 'Orange', 'Coconut', 'Apple', '15']);
solve(['1', '2', '3', '4', '2']);
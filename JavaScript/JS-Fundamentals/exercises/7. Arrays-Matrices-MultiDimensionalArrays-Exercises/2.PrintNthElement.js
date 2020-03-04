function solve(input) {
    let step = parseInt(input[input.length-1]);

    for (let i = 0; i < input.length - 1; i += step){
        console.log(`${input[i]}\n`);
    }
}

solve(['5', '20', '31', '4', '20', '2']);
solve(['dsa', 'asd', 'test', 'tset', '2']);
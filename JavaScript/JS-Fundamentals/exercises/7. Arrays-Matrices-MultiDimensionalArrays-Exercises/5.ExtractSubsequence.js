function solve (input) {
    let result = new Array();
    let max = input[0];
    result.push(max);

    for (let i = 1; i < input.length; i++) {
        if (input[i] > max) {
            result.push(input[i]);
            max = input[i];
        }
    }

    console.log(result.join("\n"));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]);

console.log("\n");

solve ([20,
    3,
    2,
    15,
    6,
    1]);
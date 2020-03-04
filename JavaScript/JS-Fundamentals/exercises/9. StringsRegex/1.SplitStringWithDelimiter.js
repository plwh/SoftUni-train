function solve (input, delimiter) {
    let result = input.split(delimiter);

    console.log(result.join("\n"));
}

solve("One-Two-Three-Four-Five",
    "-");
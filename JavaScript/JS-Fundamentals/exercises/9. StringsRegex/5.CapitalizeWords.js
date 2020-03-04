function solve (input) {
    let result = input.split(" ");

    for (let i = 0; i < result.length; i++) {
        result[i] = result[i][0].toUpperCase() + result[i].substring(1);
    }

    console.log(result.join(" "));
}

solve("Was That Easy? Try This One For Size!");
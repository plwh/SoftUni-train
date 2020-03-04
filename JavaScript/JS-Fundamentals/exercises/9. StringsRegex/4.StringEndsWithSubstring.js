function solve(input, endString) {
    console.log((input.endsWith(endString))? "true" : "false");
}

solve("This sentence ends with fun?", "fun?");
solve("This is Houston, we have…", "We have…");
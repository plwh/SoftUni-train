function solve(input) {
    let items = {};

    for (let i of input) {
        let tokens = i.split(' : ');

        let key = tokens[0];
        let value = Number(tokens[1]);


        if(items[key] == undefined) {
            items[key] = value;
        }
    }

    let keys = Object.keys(items);
    keys.sort();
    let letter = '';

    for (let j of keys) {
        let firstLetter = j[0];
        if (firstLetter != letter) {
            letter = firstLetter;
            console.log(letter);
        }

        console.log(`  ${j}: ${items[j]}`);
    }
}

solve(["Appricot : 20.4",
    "Fridge : 1500",
    "TV : 1499",
    "Deodorant : 10",
    "Boiler : 300",
    "Apple : 1.25",
    "Anti-Bug Spray : 15",
    "T-Shirt : 10"]);
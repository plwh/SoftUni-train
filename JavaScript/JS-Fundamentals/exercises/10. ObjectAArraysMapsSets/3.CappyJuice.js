function solve (input) {
    let juiceArray = {};
    let bottleArray = {};

    for (let i of input) {
        let values = i.split(" => ");

        let key = values[0];
        let value = Number(values[1]);

        if (juiceArray[key] == undefined) {
            juiceArray[key] = value;
        } else {
            juiceArray[key] += value;
        }

        if(juiceArray[key] >= 1000) {
            while (juiceArray[key] >= 1000) {
                if (bottleArray[key] == undefined) {
                    bottleArray[key] = 1;
                } else {
                    bottleArray[key]++;
                }

                juiceArray[key] -= 1000;
            }
        }
    }
    console.log(JSON.stringify(bottleArray));
}

solve(["Orange => 2000",
    "Peach => 1432",
    "Banana => 450",
    "Peach => 600",
    "Strawberry => 549"]);

solve(["Kiwi => 234",
    "Pear => 2345",
    "Watermelon => 3456",
    "Kiwi => 4567",
    "Pear => 5678",
    "Watermelon => 6789"]);
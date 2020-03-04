function solve (input) {

    input.sort(function(a, b) {
        if(a.length < b.length) {
            return -1;
        } else if(b.length < a.length) {
            return 1;
        } else {
            if(a[0] < b[0]) {
                return -1;
            } else if(b[0] < a[0]) {
                return 1;
            } else {
                return 0;
            }
        }
    });


    console.log(input.join("\n"));
}

solve(["alpha", "beta", "gamma"]);


solve(["Isacc",
    "Theodor",
    "Jack",
    "Harrison",
    "George"
]);
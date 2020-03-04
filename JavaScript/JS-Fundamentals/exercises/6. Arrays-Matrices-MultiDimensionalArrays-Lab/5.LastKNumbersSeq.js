function solve (n, k) {
    let result = new Array();

    for (let i=1; i <= n; i++) {
        if (i > 1) {
            let numToAppend = 0;

            for (let j = result.length - 1, l = 1; j >= 0; j--, l++){
                if(l > k) {
                    break;
                }

                numToAppend += result[j];
            }

            result.push(numToAppend);
        } else {
            result.push(1);
        }
    }

    console.log(result.join(" "));
}

solve (6, 3);
solve (8, 2);
function solve (arr) {
    let resultArr = new Array();

    for (let i = 1; i < arr.length; i += 2) {
        resultArr.unshift(arr[i] * 2);
    }

    console.log(resultArr.join(" "));
}

solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7 , 3]);
function solve (arr) {
    let k = arr[0];

    let firstKNumbers = "";
    let lastKNumbers = "";

    for (let i = 1, j = arr.length - k; i <= k; i++, j++) {
        firstKNumbers += arr[i] + " ";
        lastKNumbers += arr[j] + " ";
    }

    console.log(firstKNumbers + "\n" + lastKNumbers);
}

solve([2, 7, 8, 9]);
solve([3, 6, 7, 8, 9]);
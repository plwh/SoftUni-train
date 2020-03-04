function solve (arr) {
    let resultArr = new Array();

    for (let i = 0; i < arr.length; i++) {
        if(arr[i] < 0) {
            resultArr.unshift(arr[i]);
        } else {
            resultArr.push(arr[i]);
        }
    }

    for (let i of resultArr) {
        console.log(`${i}\n`);
    }
}

solve([7, -2, 8, 9]);
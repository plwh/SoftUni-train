function solve (arr) {
    let result = "";

    for (let i = 0; i < 2; i++){
        let indexToRemove = findSmallestNumIndex(arr);
        result += arr.splice(indexToRemove, 1) + " ";
    }

    function findSmallestNumIndex (arr) {
        let min = arr[0];
        let resultIndex = 0;

        for (let i = 1; i < arr.length; i++) {
            if(arr[i] < min){
                min = arr[i];
                resultIndex = i;
            }
        }

        return resultIndex;
    }

    console.log(result);
}

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);
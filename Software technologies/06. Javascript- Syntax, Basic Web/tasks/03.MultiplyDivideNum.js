function multiplyDivideNum(nums){
    let N = Number(nums[0]);
    let X = Number(nums[1]);
    let result = 0;

    if(X >= N){
        result = N * X;
    } else {
        result = N / X;
    }

    return result;
}

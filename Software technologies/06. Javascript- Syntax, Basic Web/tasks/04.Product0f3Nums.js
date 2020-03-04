function productOf3Nums(nums){
    let num1 = Number(nums[0]);
    let num2 = Number(nums[1]);
    let num3 = Number(nums[2]);

    var numbers = [num1,num2,num3];
    let negCount = 0;
    let oneNumIsZero = false;

    numbers.forEach(element => {
        if(element == 0) oneNumIsZero = true;

        if(element < 0) negCount++;
    });

    if(negCount % 2 !=0 && oneNumIsZero == false){
        console.log("Negative");
    } else {
        console.log("Positive");
    }
}
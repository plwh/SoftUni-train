function calcCompoundInterest(nums) {
    let principal = nums[0];
    let interestRate = nums[1];
    let compoundingPeriod = nums[2];
    let timespan = nums[3];

    let compoundInterest = principal * Math.pow(1 + interestRate/(100*( 12/compoundingPeriod)), 12/compoundingPeriod * timespan);
    console.log(compoundInterest.toFixed(2));
}

calcCompoundInterest([1500, 4.3, 3, 6]);
function solveQuadraticEquation(nums) {
    var a = nums[0];
    var b = nums[1];
    var c = nums[2];
    var D = b * b - 4 * a * c;

    if (a === 0){
        console.log(" \"a cannot be zero");
        return;
    }

    if(D < 0){
        console.log("Equation has no real roots");
    } else if (D === 0) {
        console.log("There are two equal roots - x1=x2="+ (-b) / (2 * a));
    } else {
        console.log("There are two roots - x1=" + (-b + Math.sqrt(D))/(2 * a) + "; x2=" + (-b - Math.sqrt(D))/(2*a));
    }
}

solveQuadraticEquation([5, 2, 1]);
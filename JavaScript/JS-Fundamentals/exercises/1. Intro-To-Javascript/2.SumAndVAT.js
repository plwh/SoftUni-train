function sumAndVAT(num1, num2, num3){
    let sum = num1 + num2 + num3;
    let vat = sum * 0.20;
    let total = sum + vat;

    console.log("sum = " + sum);
    console.log("VAT = " + vat);
    console.log("total = " + total);
}

sumAndVAT(1.20, 2.60, 3.50);
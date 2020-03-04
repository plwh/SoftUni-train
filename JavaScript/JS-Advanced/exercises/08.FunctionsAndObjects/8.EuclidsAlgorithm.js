function calc(firstNum, secondNum) {
    if (firstNum == 0)
        return secondNum;

    return calc(secondNum % firstNum, firstNum);
}

console.log(calc(252, 105));
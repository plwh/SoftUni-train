function convertGradToDeg(input) {
    let grads = Number(input);
    grads = grads % 400;
    grads = grads < 0 ? 400 + grads : grads;

    let degrees = grads * 0.9;
    console.log(degrees);
}

convertGradToDeg(100);
convertGradToDeg(-50);
function convertImperial(num) {
    let feet = Math.floor(num / 12);
    let inches = num % 12;

    console.log(`${feet}' -${inches}"`);
}
convertImperial(36);
convertImperial(55);
convertImperial(11);
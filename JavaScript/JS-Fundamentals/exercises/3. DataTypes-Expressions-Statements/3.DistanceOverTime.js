function calcDistance(numbers) {
    let v1 = numbers[0] * 1000;
    let v2 = numbers[1] * 1000;
    let t = numbers[2] / 3600;

    let dist1 = v1 * t;
    let dist2 = v2 * t;

    console.log(Math.abs(dist1 - dist2));
}

calcDistance([0, 60, 3600]);
calcDistance([11, 10, 120]);
function calcDistBetweenTwoPoints3d(numbers){
    let x1 = numbers[0];
    let y1 = numbers[1];
    let z1 = numbers[2];

    let x2 = numbers[3];
    let y2 = numbers[4];
    let z2 = numbers[5];

    console.log(Math.sqrt(Math.pow(x1-x2, 2) + Math.pow(y1-y2,2)+Math.pow(z1-z2,2)));
}

calcDistBetweenTwoPoints3d([1, 1, 0, 5, 4, 0]);
calcDistBetweenTwoPoints3d([3.5, 0, 1, 0, 2, -1]);


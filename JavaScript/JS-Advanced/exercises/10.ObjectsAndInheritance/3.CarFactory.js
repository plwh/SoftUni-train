function assembleCar (requirements) {
    let car = {};

    car.model = requirements.model;

    let engines = [{power: 90, volume: 1800}, {power: 120, volume: 2400}, {power: 200, volume: 3500}];

    let bestEngine = engines[0];

    for (let i = 1; i < engines.length; i++){

        let distA = Math.abs(requirements.power - bestEngine.power);
        let distB = Math.abs(requirements.power - engines[i].power);

        if(distA > distB) {
            bestEngine = engines[i];
        }
    }

    car.engine = bestEngine;

    car.carriage = {
        type: requirements.carriage,
        color: requirements.color
    };

    let wheelsArray = [];

    for (let i = 0; i < 4; i++) {
        if (requirements.wheelsize % 2 == 0) {
            wheelsArray.push(requirements.wheelsize - 1);
        } else {
            wheelsArray.push(requirements.wheelsize);
        }
    }

    car.wheels = wheelsArray;

    return car;
}

console.log(assembleCar({ model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 }));

console.log(assembleCar({ model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17 }));
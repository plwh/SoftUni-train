function solve (input) {
    let cars = [];

    for (let i = 0; i < input.length; i++) {
        let args = input[i].split('|').filter(x => x !== '').map(x => x.trim());
        let brand = args[0];
        let model = args[1];
        let numOfCars = Number(args[2]);
        let car = cars.find(x => x.brand === brand);

        if(car === undefined){
            car = {brand: brand, models: new Array()};
            cars.push(car);
        }

        let carModel = car.models.find(x => x.model === model);

        if(carModel === undefined) {
            carModel = {model: model, numOfCars: 0};
            car.models.push(carModel);
        }

        carModel.numOfCars += numOfCars;
    }

    for (let car of cars) {
        console.log(car.brand);
        for (let carModel of car.models){
            console.log(`###${carModel.model} -> ${carModel.numOfCars}`);
        }
    }
}

solve(["Audi | Q7 | 1000",
    "Audi | Q6 | 100",
    "BMW | X5 | 1000",
    "BMW | X6 | 100",
    "Citroen | C4 | 123",
    "Volga | GAZ-24 | 1000000",
    "Lada | Niva | 1000000",
    "Lada | Jigula | 1000000",
    "Citroen | C4 | 22",
    "Citroen | C5 | 10"]);
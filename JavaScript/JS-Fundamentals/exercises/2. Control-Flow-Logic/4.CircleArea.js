function calcCircleArea(radius){
    let area = Math.PI * Math.pow(radius, 2);
    console.log(area);
    console.log(Math.round(area * 100) / 100);
}

calcCircleArea(5);
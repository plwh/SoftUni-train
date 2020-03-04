function filterByAge(minimumAge, aName, aAge, bName, bAge  ){
    let personA = { name: aName, age: aAge};
    let personB = { name: bName, age: bAge};

    if(personA.age >= minimumAge) console.log(personA);
    if(personB.age >= minimumAge) console.log(personB);
}

filterByAge(12, 'Ivan', 15, 'Asen', 9);
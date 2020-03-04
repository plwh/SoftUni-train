function storingObjects(inputArr){
    
    var dict = new Array();

    for(let input of inputArr)
    {
        let information = input.split(" -> ");
        dict.push({
            name: information[0],
            age: information[1],
            grade: information[2]
        });
    }

    dict.forEach(function(element) {
        console.log("Name: " + element.name);
        console.log("Age: " + element.age);
        console.log("Grade: " + element.grade);
    });
}